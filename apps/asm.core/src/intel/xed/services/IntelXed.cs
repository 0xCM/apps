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
        FS.FolderPath XedSources;

        FS.FolderPath XedTargets;

        protected override void OnInit()
        {
            XedSources = Ws.Project("db").Subdir("sources") + FS.folder("intel/xed.primary");
            XedTargets = Ws.Project("db").Subdir("xed");
        }

        public ReadOnlySpan<TextLine> SummaryLines(ReadOnlySpan<XedDisasmBlock> src)
        {
            var dst = list<TextLine>();
            var count = src.Length;
            for(var i=0; i<count; i++)
            {
                var lines = skip(src,i).Lines;
                var lcount = lines.Count;
                for(var j=0; j<lcount; j++)
                {
                    ref readonly var line = ref lines[j];
                    if(j == lcount-1)
                        dst.Add(line);
                }
            }
            return dst.ViewDeposited();
        }

        public ReadOnlySpan<AsmExpr> Expressions(ReadOnlySpan<XedDisasmBlock> src)
        {
            const string Marker = "YDIS:";
            var dst = list<AsmExpr>();
            foreach(var block in src)
            {
                foreach(var line in block.Lines)
                {
                    var i = text.index(line.Content,"YDIS:");
                    if(i >= 0)
                        dst.Add(text.trim(text.right(line.Content, i + Marker.Length)));
                }
            }
            return dst.ViewDeposited();
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

        public ReadOnlySpan<string> ClassNames()
            => Classes().Storage.Select(x => x.Expr.Text).ToArray();

        public Outcome LoadChipMap(out XedChipMap dst)
            => ParseChipMap(ChipSourcePath(), out dst);

        bool Verbose {get;} = false;

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

            var dst = IsaCatalogPath(code);
            TableEmit(matches.ViewDeposited(), XedFormImport.RenderWidths, dst);
            return result;
        }

        public ReadOnlySpan<XedFormImport> LoadForms()
        {
            var src = FormCatalogPath();
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

                outcome = parse(line, out var row);
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

        public ReadOnlySpan<XedQueryResult> QueryCatalog(string monic, bool emit = true)
        {
            const string RenderPattern = "class:{0,-24} form:{1,-32} category:{2,-16} isa:{3,-16} ext:{4,-16} attribs:{5}";
            var src = LoadForms();
            var types = FormTypes();
            var cats = Categories();
            var _isa = IsaKinds();
            var classes = Classes();
            var extensions = IsaExtensions();
            var count = src.Length;
            var dst = list<XedQueryResult>();
            for(var i=0; i<count; i++)
            {
                ref readonly var form = ref skip(src,i);
                ref readonly var @class = ref classes[form.Class];
                if(@class == null)
                    continue;

                ref readonly var type = ref types[form.Form];
                if(type == null)
                    continue;

                ref readonly var isa = ref _isa[form.IsaKind];
                ref readonly var ext = ref extensions[form.Extension];
                ref readonly var cat = ref cats[form.Category];

                if(@class.Expr.Format().StartsWith(monic, StringComparison.InvariantCultureIgnoreCase))
                {
                    var result = XedQueryResult.Empty;
                    result.SearchPattern = monic;
                    result.Class = @class.Kind;
                    result.Form = type.Kind;
                    result.Isa = isa.Kind;
                    result.Extension = ext.Kind;
                    result.Attributes = form.Attributes;
                    dst.Add(result);
                }
            }
            var path = Ws.Project("db").Subdir("xed/queries") + FS.file(monic, FS.Csv);
            var records = dst.ViewDeposited();
            if(emit)
                TableEmit(records, XedQueryResult.RenderWidths, path);
            return records;
        }

        public Index<XedFormSource> LoadFormSources()
        {
            var src = FormSourcePath();
            var tableid = Tables.identify<XedFormSource>();
            var flow = Running(string.Format("Loading form sources from {0}", src.ToUri()));
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

        public Index<XedDisasmBlock> ParseDisasmBlocks(FS.FilePath src)
            => XedDisassemblyParser.create(Wf).ParseDisasmBlocks(src);

        public void EmitCatalog()
        {
            XedTargets.Clear();
            EmitChipMap();
            EmitFormCatalog();
            EmitTokens();
            EmitFormOperands();
        }

        public void EmitFormOperands()
        {
            var aspects = EmitOperandKinds();
            var partition = Partition(aspects);
            EmitOperands(partition);
        }

        public Outcome EmitChipMap()
        {
            const string RowFormat = "{0,-12} | {1,-24} | {2}";

            var outcome = LoadChipMap(out var map);
            if(outcome.Fail)
                Error(outcome.Message);
            else
            {
                var dst = ChipMapCatalogPath();
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

        void EmitOperands(ReadOnlySpan<XedFormOperands> src)
        {
            var path = OperandCatalogPath();
            var flow = EmittingTable<XedFormOperands>(path);
            var count = Tables.emit(src, XedFormOperands.RenderWidths, path);
            EmittedTable(flow, count);
        }

        public void EmitTokens()
        {
            Service(Wf.ApiMetadata).EmitApiTokens("xed", "xed");
        }

        ReadOnlySpan<XedFormOperand> ComputeDistinctOperands()
        {
            var types = Symbols.index<IFormType>();
            var count = types.Count;
            var forms = types.View;
            var distinct = hashset<XedFormOperand>();
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

        ReadOnlySpan<XedFormOperands> PartitionOperands()
        {
            var types  = Symbols.index<IFormType>();
            var classes = Symbols.index<IClass>();
            var count = types.Count;
            var buffer = alloc<XedFormOperands>(count);
            ref var dst = ref first(buffer);
            var flow = Wf.Running(Msg.PartitioningIForms.Format(count));
            var forms = types.View;
            for(ushort i=0; i<count; i++)
                Partition(classes, i, skip(forms,i), ref seek(dst,i));
            Wf.Ran(flow, Msg.PartitionedIForms.Format(count));
            return buffer;
        }

        ReadOnlySpan<XedFormOperands> Partition(Index<XedOperandKind> src)
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
                        Wf.Error(NotFound.Format(a));
                }
            }
            return parts;
        }

        Outcome ParseChipMap(FS.FilePath src, out XedChipMap dst)
        {
            dst = default;
            var flow = Wf.Running(string.Format("Parsing {0}", src.ToUri()));
            var chip = ChipCode.None;
            var chips = dict<ChipCode,ChipIsaKinds>();
            using var reader = src.LineReader(TextEncodingKind.Asci);
            while(reader.Next(out var line))
            {
                if(line.StartsWith(Chars.Hash))
                    continue;

                var i = line.Index(Chars.Colon);
                if(i != -1)
                {
                    if(Verbose)
                        Wf.Row(line);

                    var name = line.Left(i).Trim();
                    if(blank(name))
                        continue;

                    if(Enums.parse<ChipCode>(name, out chip))
                    {
                        if(!chips.TryAdd(chip, new ChipIsaKinds(chip)))
                            return (false, DuplicateChipCode.Format(chip));
                    }
                    else
                        return (false, ChipCodeNotFound.Format(name));
                }
                else
                {
                    var kinds = line.Content.SplitClean(Chars.Tab).Trim().Select(x => Enums.parse<IsaKind>(x,IsaKind.None)).Where(x => x != 0).Array();
                    chips[chip].Add(kinds);
                    if(chips.TryGetValue(chip, out var entry))
                        entry.Add(kinds);
                }
            }

            var allChips = ChipCodes().Kinds.ToArray();
            var count = allChips.Length;
            Wf.Ran(flow, string.Format("Parsed {0} chip codes", count));

            var buffer = new Index<ChipCode,IsaKinds>(alloc<IsaKinds>(count));
            for(var i=0; i<count; i++)
            {
                var _code = (ChipCode)i;
                if(chips.TryGetValue(_code, out var entry))
                    buffer[_code] = entry.Kinds;
                else
                    buffer[_code] = XedModels.IsaKinds.Empty;
            }
            dst = new XedChipMap(allChips,buffer);
            return true;
        }

        Index<XedOperandKind> EmitOperandKinds()
        {
            var duplicates = dict<Hash32,uint>();
            var distinct = ComputeDistinctOperands();
            var count = (uint)distinct.Length;
            var buffer = alloc<XedOperandKind>(count);
            var dst = OperandKindsCatalogPath();
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

        public void EmitFormCatalog()
        {
            var src = LoadFormSources().View;
            var dst = FormCatalogPath();
            var emitting = EmittingTable<XedFormImport>(dst);
            var formatter = Tables.formatter<XedFormImport>(XedFormImport.RenderWidths);
            var count = src.Length;
            var result = Outcome.Success;
            var rows = list<XedFormImport>();
            using var writer = dst.Writer();
            writer.WriteLine(formatter.FormatHeader());
            for(var i=z16; i<count; i++)
            {
                result = parse(skip(src,i), i, out var import);
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
            EmittedTable(emitting,count);
        }

        void EmitSymbols<K>()
            where K : unmanaged, Enum
        {
            var name = string.Format("xed.{0}", typeof(K).Name.ToLower());
            var src = Symbols.index<K>().View;
            var count = src.Length;
            if(count != 0)
            {
                var dst = XedTargets + FS.file(name,FS.Csv);
                var flow = Wf.EmittingFile(dst);
                using var writer = dst.Writer();
                writer.WriteLine(Symbols.header());
                for(var i=0; i<count; i++)
                    writer.WriteLine(skip(src,i));
                Wf.EmittedFile(flow, count);
            }
        }

        void Partition(in Symbols<IClass> classes, ushort index, IFormType src, ref XedFormOperands dst)
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

         FS.FilePath OperandCatalogPath()
            => Tables.path<XedFormOperands>(XedTargets);

        FS.FilePath IsaCatalogPath(ChipCode chip)
            => XedTargets + FS.file(string.Format("xed.isa.{0}", chip), FS.Csv);

        FS.FilePath ChipMapCatalogPath()
            => XedTargets + FS.file("xed.chipmap", FS.Csv);

        FS.FilePath OperandKindsCatalogPath()
            => XedTargets + FS.file(Tables.identify<XedOperandKind>().Format(), FS.Csv);

        FS.FilePath FormCatalogPath()
            => XedTargets + FS.file(Tables.identify<XedFormImport>().Format(), FS.Csv);

        FS.FilePath SymTablePath(string id)
            => XedTargets + FS.file(string.Format("xed.{0}", id),FS.Csv);

        const char CommentMarker = Chars.Hash;

        const char FieldDelimiter = Chars.Space;

        static Outcome parse(TextLine src, out XedFormImport dst)
        {
            const char Delimiter = Chars.Pipe;

            dst = default;
            var result = Tables.cells(src, Delimiter, XedFormImport.FieldCount, out var cells);
            if(result.Fail)
                return result;
            var j=0;

            result = DataParser.parse(skip(cells,j++), out dst.Index);
            if(result.Fail)
                return result;

            result = DataParser.eparse(skip(cells,j++), out IFormType ft);
            if(result.Fail)
                return result;
            else
                dst.Form = ft;

            result = DataParser.eparse(skip(cells,j++), out dst.Class);
            if(result.Fail)
                return result;

            result = DataParser.eparse(skip(cells,j++), out dst.Category);
            if(result.Fail)
                return result;

            result = DataParser.eparse(skip(cells,j++), out dst.IsaKind);
            if(result.Fail)
                return result;

            result = DataParser.eparse(skip(cells,j++), out dst.Extension);
            if(result.Fail)
                return result;

            dst.Attributes = attributes(skip(cells,j++));

            return result;
        }

        static AttributeKind[] attributes(string src)
        {
            var parts = src.SplitClean(Chars.Colon).ToReadOnlySpan();
            var count = parts.Length;
            if(count == 0)
                return default;

            var counter = 0u;
            var dst = span<AttributeKind>(count);
            for(var i=0; i<count; i++)
            {
                var result = DataParser.eparse(skip(parts,i), out seek(dst,i));
                if(result)
                {
                    counter++;
                }
                else
                    return default;
            }
            return slice(dst,0,counter).ToArray();
        }

        static Outcome parse(in XedFormSource src, ushort seq, out XedFormImport dst)
        {
            var result = Outcome.Success;
            dst.Index = seq;
            result = DataParser.eparse(src.Class, out dst.Class);
            result = DataParser.eparse(src.Extension, out dst.Extension);
            result = DataParser.eparse(src.Category, out dst.Category);
            result = DataParser.eparse(src.Form, out IFormType ft);
            dst.Form = ft;
            result = DataParser.eparse(src.IsaSet, out dst.IsaKind);
            dst.Attributes = Z0.seq.index(Chars.Colon, 0, attributes(src.Attributes));
            return true;
        }

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

        static MsgPattern<ChipCode> DuplicateChipCode => "Duplicate chip code {0}";

        static MsgPattern<string> ChipCodeNotFound => "Code for chip {0} not found";

        static MsgPattern<object> NotFound => "{0} not found";

        static MsgPattern<Count,FS.FileUri> EmittedQueryResults
            => "Directed {0} query result rows to {1}";
   }
}