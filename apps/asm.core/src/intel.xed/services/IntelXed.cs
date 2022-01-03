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

    public sealed partial class IntelXed : AppService<IntelXed>
    {
        FS.FolderPath XedSources;

        FS.FolderPath XedTargets;

        bool Verbose {get;} = false;

        Symbols<FieldType> FieldTypes;

        Symbols<VisibilityKind> Visibilities;

        public IntelXed()
        {
            FieldTypes = Symbols.index<FieldType>();
            Visibilities = Symbols.index<VisibilityKind>();
        }

        protected override void OnInit()
        {
            XedSources = ProjectDb.Sources("intel/xed.primary");
            XedTargets = ProjectDb.Subdir("xed");
        }

        ApiMetadataService ApiMetadata => Service(Wf.ApiMetadata);

        public XedRules Rules => Service(Wf.XedRules);

        public XedDisasmSvc Disasm => Service(Wf.XedDisasm);

        public XedTool Tool => Service(Wf.XedTool);

        public Symbols<IClass> Classes()
            => Symbols.index<IClass>();

        public Symbols<IsaKind> IsaKinds()
            => Symbols.index<IsaKind>();

        public Symbols<ExtensionKind> IsaExtensions()
            => Symbols.index<ExtensionKind>();

        public Symbols<ChipCode> ChipCodes()
            => Symbols.index<ChipCode>();

        public Symbols<AttributeKind> Attributes()
            => Symbols.index<AttributeKind>();

        public Symbols<NonterminalKind> Nonterminals()
            => Symbols.index<NonterminalKind>();

        public Symbols<CategoryKind> Categories()
            => Symbols.index<CategoryKind>();

        public Symbols<IFormType> FormTypes()
            => Symbols.index<IFormType>();

        public Symbols<RegId> Registers()
            => Symbols.index<RegId>();

        public ReadOnlySpan<string> ClassNames()
            => Classes().Storage.Select(x => x.Expr.Text).ToArray();

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

        public Index<FieldDef> EmitFieldDefs()
        {
            var src = ParseFieldDefs();
            EmitFieldDefs(src);
            return src;
        }

        public XedInstructions EmitInstructions()
        {
            var src =  XedSources + FS.file("xed-tables", FS.Txt);
            var result = InstTableParser.Parse(src, out var inst);
            if(result)
            {
                TableEmit(inst.Descriptions, XedInstructions.InstInfo.RenderWidths, ProjectDb.TablePath<XedInstructions.InstInfo>("xed"));
                TableEmit(inst.Operands, XedInstructions.InstOperandInfo.RenderWidths,  ProjectDb.TablePath<XedInstructions.InstOperandInfo>("xed"));
                return inst;
            }
            else
            {
                Error(result.Message);
                return XedInstructions.Empty;
            }
        }

        public ReadOnlySpan<XedQueryResult> QueryCatalog(string monic, bool emit = true)
        {
            const string RenderPattern = "class:{0,-24} form:{1,-32} category:{2,-16} isa:{3,-16} ext:{4,-16} attribs:{5}";
            var src = LoadFormImports();
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
            var path = ProjectDb.Subdir("xed/queries") + FS.file(monic, FS.Csv);
            var records = dst.ViewDeposited();
            if(emit)
                TableEmit(records, XedQueryResult.RenderWidths, path);
            return records;
        }

        public void EmitCatalog()
        {
            XedTargets.Clear(true);
            EmitChipMap();
            ImportForms();
            EmitTokens();
            EmitInstructions();
            EmitIsaForms();
            EmitFieldDefs();
            Rules.EmitCatalog();
        }

        FS.FilePath FieldDefSource()
            => XedSources + FS.file("all-fields", FS.Txt);

        FS.FilePath FormSourcePath()
            => XedSources + FS.file("xed-idata", FS.Txt);

        FS.FilePath ChipSourcePath()
            => XedSources + FS.file("xed-cdata", FS.Txt);

        FS.FilePath IsaFormsPath(ChipCode chip)
            => XedTargets + FS.folder("isaforms") + FS.file(string.Format("xed.isa.{0}", chip), FS.Csv);

        FS.FilePath ChipMapCatalogPath()
            => XedTargets + FS.file("xed.chipmap", FS.Csv);

        FS.FilePath FormCatalogPath()
            => XedTargets + FS.file(Tables.identify<XedFormImport>().Format(), FS.Csv);

        FS.FilePath FieldDefsPath()
            => XedTargets + Tables.filename<FieldDef>();

        const char CommentMarker = Chars.Hash;

        const char FieldDelimiter = Chars.Space;

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