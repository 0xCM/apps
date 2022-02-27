//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System.Linq;

    using static XedModels;

    [ApiHost]
    public sealed partial class IntelXed : AppService<IntelXed>
    {
        FS.FolderPath XedSources;

        FS.FolderPath XedTargets;

        bool Verbose {get;} = false;

        Symbols<FieldType> FieldTypes;

        Symbols<VisibilityKind> Visibilities;

        EnumParser<OperandWidthType> OpWidthParser;

        EnumParser<BaseTypeKind> BaseTypeParser;

        EnumParser<IClass> IClassParser;

        EnumParser<IsaKind> IsaKindParser;

        EnumParser<IFormType> IFormParser;

        Symbols<IClass> IClassSyms;

        Symbols<IsaKind> IsaKindSyms;

        Symbols<XedRegId> RegSyms;

        Symbols<ChipCode> ChipSyms;

        public IntelXed()
        {
            FieldTypes = Symbols.index<FieldType>();
            Visibilities = Symbols.index<VisibilityKind>();
            OpWidthParser = new();
            IClassParser = new();
            BaseTypeParser = new();
            IsaKindParser = new();
            IClassSyms = Symbols.index<IClass>();
            IsaKindSyms = Symbols.index<IsaKind>();
            RegSyms = Symbols.index<XedRegId>();
            ChipSyms = Symbols.index<ChipCode>();
        }

        protected override void OnInit()
        {
            XedSources = ProjectDb.Sources("intel/xed.primary");
            XedTargets = ProjectDb.Subdir("xed");
        }

        ApiMetadataService ApiMetadata => Service(Wf.ApiMetadata);

        XedPaths XedPaths => Service(Wf.XedPaths);

        public XedRules Rules => Service(Wf.XedRules);

        [Op]
        public bool WidthType(string src, out OperandWidthType dst)
            => OpWidthParser.Parse(src, out dst);

        [Op]
        public bool IClass(string src, out IClass dst)
            => IClassParser.Parse(src, out dst);

        [Op]
        public bool IsaKind(string src, out IsaKind dst)
            => IsaKindParser.Parse(src, out dst);

        [Op]
        public bool BaseType(string src, out BaseTypeKind dst)
            => BaseTypeParser.Parse(src, out dst);

        [Op]
        public bool IForm(string src, out IFormType dst)
            => IFormParser.Parse(src, out dst);

        [Op]
        public Symbols<IClass> Classes()
            => IClassSyms;

        [Op]
        public Symbols<IsaKind> IsaKinds()
            => IsaKindSyms;

        [Op]
        public Symbols<ExtensionKind> IsaExtensions()
            => Symbols.index<ExtensionKind>();

        [Op]
        public Symbols<ChipCode> ChipCodes()
            => ChipSyms;

        [Op]
        public Symbols<AttributeKind> Attributes()
            => Symbols.index<AttributeKind>();

        [Op]
        public Symbols<NonterminalKind> Nonterminals()
            => Symbols.index<NonterminalKind>();

        [Op]
        public Symbols<CategoryKind> Categories()
            => Symbols.index<CategoryKind>();

        [Op]
        public Symbols<IFormType> FormTypes()
            => Symbols.index<IFormType>();

        [Op]
        public Symbols<XedRegId> Registers()
            => RegSyms;

        public ReadOnlySpan<string> ClassNames()
            => Classes().Storage.Select(x => x.Expr.Text).ToArray();

        public void EmitCatalog()
        {
            XedTargets.Clear(true);
            EmitChipMap();
            ImportForms();
            EmitTokens();
            EmitIsaForms();
            Rules.EmitCatalog();
        }

        const char CommentMarker = Chars.Hash;

        const char FieldDelimiter = Chars.Space;

        static MsgPattern<ChipCode> DuplicateChipCode => "Duplicate chip code {0}";

        static MsgPattern<string> ChipCodeNotFound => "Code for chip {0} not found";
   }
}