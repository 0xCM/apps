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

        bool Verbose {get;} = false;

        protected override void OnInit()
        {
            XedSources = Ws.Project("db").Subdir("sources") + FS.folder("intel/xed.primary");
            XedTargets = Ws.Project("db").Subdir("xed");
        }

        ApiMetadataService ApiMetadata => Service(Wf.ApiMetadata);

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

        public Symbols<OperandTypeKind> OperandKinds()
            => Symbols.index<OperandTypeKind>();

        public Symbols<IFormType> FormTypes()
            => Symbols.index<IFormType>();

        public Symbols<RegId> Registers()
            => Symbols.index<RegId>();

        public ReadOnlySpan<string> ClassNames()
            => Classes().Storage.Select(x => x.Expr.Text).ToArray();

        public Outcome LoadChipMap(out XedChipMap dst)
            => ParseChipMap(ChipSourcePath(), out dst);

        XedInstTableParser InstTableParser
            => Service(() => XedInstTableParser.create(Wf));

        public XedInstructions ParseInstructions()
        {
            var src =  XedSources + FS.file("xed-tables", FS.Txt);
            var result = InstTableParser.Parse(src, out var dst);
            if(result.Fail)
            {
                Error(result.Message);
                return XedInstructions.Empty;
            }
            else
            {
                return dst;
            }
        }

        public XedInstructions EmitInstructions()
        {
            var src =  XedSources + FS.file("xed-tables", FS.Txt);
            var result = InstTableParser.Parse(src, out var inst);
            if(result)
            {
                TableEmit(inst.Descriptions, XedInstructions.InstInfo.RenderWidths, ProjectDb.TablePath<XedInstructions.InstInfo>("xed"));
                TableEmit(inst.Operands, XedInstructions.InstOperand.RenderWidths,  ProjectDb.TablePath<XedInstructions.InstOperand>("xed"));
                return inst;
            }
            else
            {
                Error(result.Message);
                return XedInstructions.Empty;
            }
        }

        public Outcome EmitChipForms(ChipCode code)
        {
            var result = LoadChipMap(out var map);
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

        public Outcome EmitChipForms(string chip)
        {
            var result = Outcome.Success;
            var symbols = ChipCodes();
            if(!symbols.Lookup(chip, out var code))
                return (false, string.Format("Chip '{0}' not found", chip));

            return EmitChipForms(code);
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

                outcome = XedModels.parse(line, out var row);
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
                        Error(outcome.Message);
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
                        Error(outcome.Message);
                        succeeded = false;
                        break;
                   }
                }

                counter++;
            }

            if(succeeded)
                Ran(flow, Tables.imported(counter, src).ToString());

            return records.ToArray();
        }

        public Index<XedDisasmBlock> ParseDisasmBlocks(FS.FilePath src)
            => Service(Wf.XedDisassemblyParser).ParseDisasmBlocks(src);

        public void EmitCatalog()
        {
            XedTargets.Clear();
            EmitChipMap();
            EmitFormCatalog();
            EmitTokens();
            EmitInstructions();
            EmitChipForms();
        }

        public void EmitTokens()
        {
            ApiMetadata.EmitApiTokens("xed", "xed");
            ApiMetadata.EmitTokens<AttributeKind>(xed);
            ApiMetadata.EmitTokens<IClass>(xed);
            ApiMetadata.EmitTokens<LookupKind>(xed);
            ApiMetadata.EmitTokens<ChipCode>(xed);
            ApiMetadata.EmitTokens<Category>(xed);
            ApiMetadata.EmitTokens<NonterminalKind>(xed);
            ApiMetadata.EmitTokens<Extension>(xed);
            ApiMetadata.EmitTokens<IsaKind>(xed);
            ApiMetadata.EmitTokens<RegId>(xed);
            ApiMetadata.EmitTokens<EncodingGroup>(xed);
            ApiMetadata.EmitTokens<OperandTypeKind>(xed);
            ApiMetadata.EmitTokens<OpCodeMap>(xed);
            ApiMetadata.EmitTokens<OperandAction>(xed);
        }

        public void EmitChipForms()
        {
            EmitChipForms(ChipCode.I186);
            EmitChipForms(ChipCode.I286);
            EmitChipForms(ChipCode.I386);
            EmitChipForms(ChipCode.I486);
            EmitChipForms(ChipCode.PENTIUM);
            EmitChipForms(ChipCode.PENTIUM2);
            EmitChipForms(ChipCode.PENTIUM3);
            EmitChipForms(ChipCode.PENTIUM4);
            EmitChipForms(ChipCode.P4PRESCOTT);
            EmitChipForms(ChipCode.BROADWELL);
            EmitChipForms(ChipCode.SKYLAKE);
            EmitChipForms(ChipCode.CASCADE_LAKE);
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
                var emitting = EmittingFile(dst);
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
                EmittedFile(emitting,counter);
            }

            return outcome;
        }

        Outcome ParseChipMap(FS.FilePath src, out XedChipMap dst)
        {
            dst = default;
            var flow = Running(string.Format("Parsing {0}", src.ToUri()));
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
                    var kinds = line.Content.SplitClean(Chars.Tab).Trim().Select(x => Enums.parse<IsaKind>(x,IsaKind.INVALID)).Where(x => x != 0).Array();
                    chips[chip].Add(kinds);
                    if(chips.TryGetValue(chip, out var entry))
                        entry.Add(kinds);
                }
            }

            var allChips = ChipCodes().Kinds.ToArray();
            var count = allChips.Length;
            Ran(flow, string.Format("Parsed {0} chip codes", count));

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
                result = XedModels.parse(skip(src,i), i, out var import);
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

        FS.FilePath FormSourcePath()
            => XedSources + FS.file("xed-idata", FS.Txt);

        FS.FilePath ChipSourcePath()
            => XedSources + FS.file("xed-cdata", FS.Txt);

        FS.FilePath IsaCatalogPath(ChipCode chip)
            => XedTargets + FS.file(string.Format("xed.isa.{0}", chip), FS.Csv);

        FS.FilePath ChipMapCatalogPath()
            => XedTargets + FS.file("xed.chipmap", FS.Csv);

        FS.FilePath FormCatalogPath()
            => XedTargets + FS.file(Tables.identify<XedFormImport>().Format(), FS.Csv);

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

        static MsgPattern<ChipCode> DuplicateChipCode => "Duplicate chip code {0}";

        static MsgPattern<string> ChipCodeNotFound => "Code for chip {0} not found";
   }
}