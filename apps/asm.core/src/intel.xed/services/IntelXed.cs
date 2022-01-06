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


        XedPaths XedPaths => Service(Wf.XedPaths);

        public XedRules Rules => Service(Wf.XedRules);

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

        public Symbols<XedRegId> Registers()
            => Symbols.index<XedRegId>();

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

        public void EmitCatalog()
        {
            XedTargets.Clear(true);
            EmitChipMap();
            ImportForms();
            EmitTokens();
            EmitInstructions();
            EmitIsaForms();
            Rules.EmitCatalog();
        }

        const char CommentMarker = Chars.Hash;

        const char FieldDelimiter = Chars.Space;

        static MsgPattern<ChipCode> DuplicateChipCode => "Duplicate chip code {0}";

        static MsgPattern<string> ChipCodeNotFound => "Code for chip {0} not found";
   }
}