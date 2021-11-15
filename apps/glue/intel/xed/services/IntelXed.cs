//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Linq;

    using static Root;
    using static core;
    using static XedModels;

    public sealed class IntelXed : AppService<IntelXed>
    {
        public static ReadOnlySpan<XedDataset> datasets()
        {
            var src = typeof(XedDatasetKind).LiteralFields().ToReadOnlySpan();
            var count = src.Length;
            var buffer = alloc<XedDataset>(count);
            ref var dst = ref first(buffer);
            for(var i=0; i<count; i++)
                seek(dst,i) = new XedDataset(skip(src,i));
            return buffer;
        }

        FS.FolderPath XedTables;

        FS.FolderPath XedSources;

        XedParsers Parsers;

        protected override void OnInit()
        {
            var project = Ws.Project("intel.docs");
            var root = project.Subdir("sources");
            XedTables = root + FS.folder("intel.xed");
            XedSources =root + FS.folder("xed.primary");
            Parsers = Wf.XedParsers();
        }

        public Symbols<IClass> Classes()
            => Symbols.index<IClass>();

        public Symbols<IsaKind> IsaKinds()
            => Symbols.index<IsaKind>();

        public Symbols<PointerWidth> PointerWidths()
            => Symbols.index<PointerWidth>();

        public Symbols<Extension> IsaExtensions()
            => Symbols.index<Extension>();

        public Symbols<ChipCode> ChipCodes()
            => Symbols.index<ChipCode>();

        public Symbols<AttributeKind> Attributes()
            => Symbols.index<AttributeKind>();

        public Symbols<Category> Categories()
            => Symbols.index<Category>();

        public Symbols<OperandKind> OperandKinds()
            => Symbols.index<OperandKind>();

        public Symbols<IFormType> FormTypes()
            => Symbols.index<IFormType>();

        public Symbols<RegId> Registers()
            => Symbols.index<RegId>();

        public Index<SymLiteralRow> SymLiterals()
        {
            var src = typeof(XedModels).GetNestedTypes().Enums();
            return Symbols.literals(src);
        }

        public ReadOnlySpan<string> ClassNames()
            => Classes().Storage.Select(x => x.Expr.Text).ToArray();

        public Outcome LoadChipMap(out ChipMap dst)
            => Parsers.ParseChipMap(ChipSourcePath(), out dst);

        public const string intelxed = "intel.xed";

        static MsgPattern<Count,FS.FileUri> EmittedQueryResults
            => "Directed {0} query result rows to {1}";

        public Outcome EmitIsa(string chip)
        {
            var result = Outcome.Success;
            var symbols = ChipCodes();
            if(!symbols.Lookup(chip, out var code))
                return (false, string.Format("Chip '{0}' not found", chip));

            result = LoadChipMap(out var map);
            if(result.Fail)
                return result;

            var kinds = map[code].ToHashSet();
            var matches = list<XedFormImport>();
            var forms = LoadForms();
            var count = forms.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var form = ref skip(forms,i);
                if(kinds.Contains(form.IsaKind))
                    matches.Add(form);
            }

            var dst = Ws.Tables().TablePath<XedFormImport>(intelxed, code.Kind.ToString());
            var formatter = Tables.formatter<XedFormImport>();
            var rows = Tables.emit(matches.ViewDeposited(), XedFormImport.RenderWidths, dst);
            Write(EmittedQueryResults.Format(rows,dst));
            return result;
        }

        public ReadOnlySpan<XedFormImport> LoadForms()
        {
            var src = Ws.Tables().TablePath<XedFormImport>("intel.xed");
            var counter = 0u;
            var outcome = Outcome.Success;
            var dst = list<XedFormImport>();
            using var reader = src.AsciReader();
            reader.ReadLine();
            while(!reader.EndOfStream)
            {
                var line = reader.ReadLine(counter);

                if(line.StartsWith(CommentMarker))
                    continue;

                if(line.IsEmpty)
                    continue;

                outcome = Parsers.ParseFormImport(line, out var row);
                if(outcome)
                    dst.Add(row);
                else
                {
                    Wf.Error(outcome.Message);
                    break;
                }

                counter++;
            }
            if(outcome)
                return dst.ViewDeposited();
            else
                return default;
        }

        public Index<XedFormSource> LoadFormSources()
        {
            var src = FormSourcePath();
            var flow = Wf.Running(Tables.processing(Tables.identify<XedFormSource>(),src));
            using var reader = src.Utf8Reader();
            var counter = 0u;
            var header = alloc<string>(XedFormSource.FieldCount);
            var succeeded = true;
            var records = list<XedFormSource>();
            while(!reader.EndOfStream)
            {
                var line = reader.ReadLine(counter);

                if(line.StartsWith(CommentMarker))
                    continue;

                if(line.IsEmpty)
                    continue;

                if(counter==0)
                {
                    var outcome = ParseSourceHeader(line,header);
                    if(!outcome)
                    {
                        Wf.Error(outcome.Message);
                        succeeded = false;
                        break;
                    }
                }
                else
                {
                   var dst = new XedFormSource();
                   var outcome = ParseSummary(line, out dst);
                   if(outcome)
                   {
                       records.Add(dst);
                   }
                   else
                   {
                        Wf.Error(outcome.Message);
                        succeeded = false;
                        break;
                   }
                }

                counter++;
            }

            if(succeeded)
                Wf.Ran(flow, Tables.imported(counter, src));

            return records.ToArray();
        }

        public void EmitCatalog()
        {
            EmitChipMap(XedTables);
            EmitForms(XedTables);
            EmitSymCatalog(XedTables);
            var aspects = EmitOperandKinds(XedTables);
            var partition = Partition(aspects);
        }

        public Outcome EmitChipMap(FS.FolderPath dir)
        {
            const string RowFormat = "{0,-12} | {1,-24} | {2}";

            var outcome = LoadChipMap(out var map);
            if(outcome.Fail)
                Error(outcome.Message);
            else
            {
                var dst = ChipMapTablePath(dir);
                var emitting = Wf.EmittingFile(dst);
                var counter = 0u;
                var writer = dst.AsciWriter();
                writer.WriteLine(string.Format(RowFormat, "Sequence", "ChipCode", "Isa"));
                var kinds = map.Kinds;
                var codes = map.Chips;
                foreach(var code in codes)
                {
                    var mapped = map[code];
                    foreach(var kind in mapped)
                        writer.WriteLine(string.Format(RowFormat, counter++ , code, kind));
                }
                Wf.EmittedFile(emitting,counter);
            }

            return outcome;
        }

        public void EmitSymCatalog(FS.FolderPath dir)
        {
            EmitSymIndex(dir);
            EmitSymbols<AddressWidth>(dir);
            EmitSymbols<AttributeKind>(dir);
            EmitSymbols<Category>(dir);
            EmitSymbols<ChipCode>(dir);
            EmitSymbols<CpuidBit>(dir);
            EmitSymbols<EASZ>(dir);
            EmitSymbols<EFlag>(dir);
            EmitSymbols<EncodingGroup>(dir);
            EmitSymbols<EOSZ>(dir);
            EmitSymbols<Extension>(dir);
            EmitSymbols<FlagAction>(dir);
            EmitSymbols<IClass>(dir);
            EmitSymbols<IFormType>(dir);
            EmitSymbols<IsaKind>(dir);
            EmitSymbols<Mode>(dir);
            EmitSymbols<OpModeKind>(dir);
            EmitSymbols<Nonterminal>(dir);
            EmitSymbols<OpCodeMap>(dir);
            EmitSymbols<OperandAction>(dir);
            EmitSymbols<LookupKind>(dir);
            EmitSymbols<OperandTypeKind>(dir);
            EmitSymbols<OperandKind>(dir);
            EmitSymbols<OperandVisibility>(dir);
            EmitSymbols<OperandWidthType>(dir);
            EmitSymbols<PointerWidth>(dir);
            EmitSymbols<RegId>(dir);
            EmitSymbols<RegRole>(dir);
            EmitSymbols<SAMode>(dir);
            EmitSymbols<SizeIndicator>(dir);
        }

        public void EmitTables(FS.FolderPath dst)
        {
            EmitChipMap(dst);
            EmitForms(dst);
            EmitSymCatalog(dst);
            var aspects = EmitOperandKinds(dst);
            EmitOperands(Partition(aspects), dst);
        }

        void EmitOperands(ReadOnlySpan<FormOperands> src, FS.FolderPath dst)
        {
            var path = Tables.path<FormOperands>(dst);
            var flow = EmittingTable<FormOperands>(path);
            var count = Tables.emit(src, FormOperands.RenderWidths, path);
            EmittedTable(flow,count);
        }

        FS.FilePath EmitSymIndex(FS.FolderPath dir)
        {
            var dst = SymbolImportPath(dir);
            EmitSymIndex(dst);
            return dst;
        }

        Index<SymLiteralRow> EmitSymIndex(FS.FilePath dst)
        {
            var src = SymLiterals();
            var emitting = Wf.EmittingTable<SymLiteralRow>(dst);
            var count = Tables.emit(src.View, dst);
            Wf.EmittedTable(emitting,count);
            return src;
        }

        ReadOnlySpan<FormOperand> ComputeDistinctOperands()
        {
            var types = Symbols.index<IFormType>();
            var count = types.Count;
            var forms = types.View;
            var distinct = hashset<FormOperand>();
            var counter = 0u;
            for(ushort i=0; i<count; i++)
            {
                var form = skip(forms,i);
                var parts = @readonly(form.Kind.ToString().Split(Chars.Underscore));
                var kParts = parts.Length;
                if(kParts < 2)
                    continue;

                for(var j=1; j<kParts; j++)
                    if(distinct.Add(skip(parts,j)))
                        counter++;
            }

            return distinct.Array().Sort();
       }

        ReadOnlySpan<FormOperands> PartitionOperands()
        {
            var types  = Symbols.index<IFormType>();
            var classes = Symbols.index<IClass>();
            var count = types.Count;
            var buffer = alloc<FormOperands>(count);
            ref var dst = ref first(buffer);
            var flow = Wf.Running(Msg.PartitioningIForms.Format(count));
            var forms = types.View;
            for(ushort i=0; i<count; i++)
                Partition(classes, i, skip(forms,i), ref seek(dst,i));
            Wf.Ran(flow, Msg.PartitionedIForms.Format(count));
            return buffer;
        }

        ReadOnlySpan<FormOperands> Partition(Index<XedOperandKind> src)
        {
            var aix = src.Select(x => (x.Value, x.Index)).ToDictionary();
            var parts = PartitionOperands();
            var count = parts.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var part = ref skip(parts,i);
                var pa = part.Specifiers.View;
                var ka = pa.Length;
                for(var j=0; j<ka; j++)
                {
                    ref readonly var a = ref skip(pa,j);
                    if(!aix.TryGetValue(a, out var index))
                        Wf.Error(string.Format("Index for {0} not found", a));
                }
            }
            return parts;
        }

        Index<XedOperandKind> EmitOperandKinds(FS.FolderPath dir)
        {
            var duplicates = dict<Hash32,uint>();
            var distinct = ComputeDistinctOperands();
            var count = (uint)distinct.Length;
            var buffer = alloc<XedOperandKind>(count);
            var dst = OperandKindImportPath(dir);
            var formatter = Tables.formatter<XedOperandKind>();
            var emitting = Wf.EmittingTable<XedOperandKind>(dst);
            using var writer = dst.Writer();
            writer.WriteLine(formatter.FormatHeader());
            for(var i=0u; i<count; i++)
            {
                ref var record = ref seek(buffer,i);
                ref readonly var aspect = ref skip(distinct,i);
                var value = aspect.Value;

                if(text.length(value) == 0)
                    continue;

                record.Index = i;
                record.Value = value;

                ref readonly var c = ref first(value);
                if(SymbolicQuery.digit(base16, c))
                    record.Name = string.Format("x{0}", value);
                else
                    record.Name = value;
                record.Hash = aspect.GetHashCode();

                if(duplicates.TryGetValue(record.Hash, out var dup))
                    duplicates[record.Hash] = ++dup;
                else
                    duplicates.Add(record.Hash, 0);

                writer.WriteLine(formatter.Format(record));
            }

            var perfect = !duplicates.Values.Array().AnyTest(x => x > 0);
            if(perfect)
                Wf.Status($"Hash Perfect");
            else
                Wf.Warn("Hash Imperfect");

            Wf.EmittedTable(emitting, count);
            return buffer;
        }

        ReadOnlySpan<XedFormImport> EmitForms(FS.FolderPath dir)
        {
            var src = LoadFormSources().View;
            var dst = dir + FS.file(Tables.identify<XedFormImport>().Format(), FS.Csv);
            var flow = Wf.EmittingTable<XedFormImport>(dst);
            var formatter = Tables.formatter<XedFormImport>(XedFormImport.RenderWidths);
            var count = src.Length;
            var result = Outcome.Success;
            var rows = list<XedFormImport>();
            using var writer = dst.Writer();
            writer.WriteLine(formatter.FormatHeader());
            for(var i=z16; i<count; i++)
            {
                result = Parsers.Parse(skip(src,i), i, out var import);
                if(result)
                {
                    import.Index = i;
                    writer.WriteLine(formatter.Format(import));
                    rows.Add(import);
                }
                else
                {
                    Error(result.Message);
                    break;
                }
            }

            return result ? rows.ViewDeposited() : default;
        }

        void EmitSymbols<K>(FS.FolderPath dir)
            where K : unmanaged, Enum
        {
            var name = string.Format("xed.{0}", typeof(K).Name.ToLower());
            var symbols = Symbols.index<K>().View;
            var path = dir + FS.file(name,FS.Csv);
            EmitSymbols(symbols, path);
        }

        void EmitSymbols<K>(ReadOnlySpan<Sym<K>> src, FS.FilePath dst)
            where K : unmanaged
        {
            var count = src.Length;
            if(count != 0)
            {
                var flow = Wf.EmittingFile(dst);
                using var writer = dst.Writer();
                writer.WriteLine(Symbols.header());
                for(var i=0; i<count; i++)
                    writer.WriteLine(skip(src,i));
                Wf.EmittedFile(flow, count);
            }
        }

        void Partition(in Symbols<IClass> classes, ushort index, IFormType src, ref FormOperands dst)
        {
            dst.Index = index;
            dst.Form = src;
            dst.Specifiers = array<string>();
            var candidates = span(src.ToString().Split(Chars.Underscore));
            if(candidates.Length <= 1)
                return;
            dst.Specifiers = slice(candidates,1).ToArray();
        }

        FS.FilePath FormSourcePath()
            => XedSources + FS.file("xed-idata", FS.Txt);

        FS.FilePath ChipSourcePath()
            => XedSources + FS.file("xed-cdata", FS.Txt);

        FS.FilePath ChipMapTablePath(FS.FolderPath dir)
            => dir + FS.file("xed.chip-map", FS.Csv);

        FS.FilePath SymbolImportPath(FS.FolderPath dir)
            => dir + FS.file("xed.symbols", FS.Csv);

        FS.FilePath OperandKindImportPath(FS.FolderPath dir)
            => dir + FS.file(Tables.identify<XedOperandKind>().Format(), FS.Csv);

        const char CommentMarker = Chars.Hash;

        const char FieldDelimiter = Chars.Space;

        static Outcome ParseSummary(TextLine src, out XedFormSource dst)
        {
            dst = default;
            var parts = src.Split(FieldDelimiter);
            var count = parts.Length;
            if(count != XedFormSource.FieldCount)
                return(false, $"Line splits into {count} parts, not {XedFormSource.FieldCount} as required");
            var i = 0;
            dst.Class = skip(parts,i++);
            dst.Extension = skip(parts,i++);
            dst.Category = skip(parts,i++);
            dst.Form = skip(parts,i++);
            dst.IsaSet = skip(parts,i++);
            dst.Attributes = skip(parts,i++);
            return true;
        }

        static Outcome ParseSourceHeader(TextLine src, Span<string> dst)
        {
            var parts = src.Split(FieldDelimiter);
            var count = parts.Length;
            if(count != XedFormSource.FieldCount)
                return(false, $"Line splits into {count} parts, not {XedFormSource.FieldCount} as required");

            for(var i=0; i<count; i++)
                seek(dst,i) = skip(parts,i);

            return true;
        }
   }
}