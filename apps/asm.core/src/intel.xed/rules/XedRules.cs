//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static core;
    using static XedRules.InstRulePartNames;

    [ApiHost]
    public partial class XedRules : AppService<XedRules>
    {
        const NumericKind Closure = UnsignedInts;

        Symbols<IClass> Classes;

        Symbols<CategoryKind> Categories;

        Symbols<ExtensionKind> Extensions;

        Symbols<OperandWidthType> OpWidthTypes;

        Symbols<XedDataType> DataTypes;

        Symbols<IsaKind> IsaKinds;

        Symbols<IFormType> Forms;

        Symbols<RuleOpName> OpKinds;

        Index<InstRulePart,string> PartNames;

        Index<PointerWidth> PointerWidths;

        Symbols<PointerWidthKind> PointerWidthSymbols;

        Symbols<VisibilityKind> Visibilities;

        Symbols<FieldType> FieldTypes;

        Symbols<RegFlag> Flags;

        Symbols<FlagActionKind> FlagActionKinds;


        XedInstDefParser InstDefParser;

        public XedRules()
        {
            Classes = Symbols.index<IClass>();
            Categories = Symbols.index<CategoryKind>();
            Extensions = Symbols.index<ExtensionKind>();
            Forms = Symbols.index<IFormType>();
            IsaKinds = Symbols.index<IsaKind>();
            OpWidthTypes = Symbols.index<OperandWidthType>();
            DataTypes = Symbols.index<XedDataType>();
            OpKinds = Symbols.index<RuleOpName>();
            PointerWidthSymbols = Symbols.index<PointerWidthKind>();
            PointerWidths = map(PointerWidthSymbols.View, s => (PointerWidth)s);
            Visibilities = Symbols.index<VisibilityKind>();
            FieldTypes = Symbols.index<FieldType>();
            FlagActionKinds = Symbols.index<FlagActionKind>();
            Flags = Symbols.index<RegFlag>();
            PartNames = new string[]{ICLASS,IFORM,ATTRIBUTES,CATEGORY,EXTENSION,FLAGS,PATTERN,OPERANDS,ISA_SET,COMMENT};
            InstDefParser = new(this);
        }

        XedPaths XedPaths => Service(Wf.XedPaths);

        OpCodePatterns DeriveOpCodeMaps()
            => Data(nameof(DeriveOpCodeMaps), () => new OpCodePatterns());

        public OpCodePatterns LoadOpCodeMaps()
            => DeriveOpCodeMaps();

        public Index<PointerWidthInfo> LoadPointerWidths()
            => Data(nameof(LoadPointerWidths), () => mapi(PointerWidths, (i,w) => w.ToRecord((byte)i)));

        public Index<OperandWidth> LoadOperandWidths()
            => Data(nameof(LoadOperandWidths), ParseOperandWidths);

        public Index<RuleTable> ParseEncRuleTables()
            => new RuleTableParser().Parse(XedPaths.DocSource(XedDocKind.EncRuleTable));

        public Index<RuleTable> ParseDecRuleTables()
            => new RuleTableParser().Parse(XedPaths.DocSource(XedDocKind.DecRuleTable));

        public Index<RuleTable> ParseEncDecRuleTables()
            => new RuleTableParser().Parse(XedPaths.DocSource(XedDocKind.EncDecRuleTable));

        public Index<InstDef> ParseEncInstDefs()
            => ParseInstDefs(XedPaths.DocSource(XedDocKind.EncInstDef));

        public Index<InstDef> ParseDecInstDefs()
            => ParseInstDefs(XedPaths.DocSource(XedDocKind.DecInstDef));

        public ReadOnlySpan<NonterminalKind> NonterminalKinds()
            => Symbols.index<NonterminalKind>().Kinds;

        Outcome ParseIClass(string src, out IClass dst)
            => Classes.ExprKind(src, out dst);

        Outcome ParseIsaKind(string src, out IsaKind dst)
            => IsaKinds.ExprKind(src, out dst);

        Outcome ParseCategory(string src, out Category dst)
        {
            dst = default;
            var result = Categories.ExprKind(src, out var kind);
            if(result)
                dst = kind;
            return result;
        }

        Outcome ParseAttribKinds(string src, out Index<AttributeKind> dst)
        {
            dst = attributes(src,Chars.Space);
            return true;
        }

        Outcome ParseExtension(string src, out Extension dst)
        {
            dst = default;
            var result = Extensions.ExprKind(src, out var kind);
            if(result)
                dst = kind;
            return result;
        }

        Outcome ParseIForm(string src, out IForm dst)
        {
            dst = default;
            Outcome result = Forms.ExprKind(src, out var kind);
            if(result)
                dst = kind;
            else
                result = (false, Msg.ParseFailure.Format(nameof(IFormType), src));
            return result;
        }

        public ConstLookup<string,OperandWidth> OperandWidths()
        {
            return Data(nameof(OperandWidths), Load);

            ConstLookup<string,OperandWidth> Load()
            {
                var widths = LoadOperandWidths();
                var dst = dict<string,OperandWidth>();
                var symbols = Symbols.index<OperandWidthType>();
                var count = widths.Length;
                for(var i=0; i<count; i++)
                {
                    ref readonly var src = ref widths[i];
                    var symbol = symbols[src.Code];
                    dst[symbol.Expr.Format()] = src;
                }
                return dst;
            }
        }

        static Symbols<FieldKind> FieldKinds;

        static Symbols<RuleMacroName> MacroNames;

        static XedRules()
        {
            FieldKinds = Symbols.index<FieldKind>();
            MacroNames = Symbols.index<RuleMacroName>();
        }

        static MsgPattern<string> StepParseFailed => "Failed to parse step from '{0}'";
    }
}