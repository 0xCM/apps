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

        Symbols<CategoryKind> Categories;

        Symbols<ExtensionKind> Extensions;

        Symbols<IsaKind> IsaKinds;

        Symbols<IFormType> Forms;

        Index<InstRulePart,string> PartNames;

        Index<PointerWidth> PointerWidths;

        Symbols<VisibilityKind> Visibilities;

        Symbols<FieldType> FieldTypes;

        Symbols<RegFlag> Flags;

        Symbols<FlagActionKind> FlagActionKinds;

        XedInstDefParser InstDefParser;

        public XedRules()
        {
            Categories = Symbols.index<CategoryKind>();
            Extensions = Symbols.index<ExtensionKind>();
            Forms = Symbols.index<IFormType>();
            IsaKinds = Symbols.index<IsaKind>();
            PointerWidths = map(PointerWidthKinds.View, s => (PointerWidth)s);
            Visibilities = Symbols.index<VisibilityKind>();
            FieldTypes = Symbols.index<FieldType>();
            FlagActionKinds = Symbols.index<FlagActionKind>();
            Flags = Symbols.index<RegFlag>();
            PartNames = new string[]{ICLASS,IFORM,ATTRIBUTES,CATEGORY,EXTENSION,FLAGS,PATTERN,OPERANDS,ISA_SET,COMMENT};
            InstDefParser = new(this);
        }

        XedPaths XedPaths => Service(Wf.XedPaths);

        XedParsers Parsers => Service(XedParsers.create);

        AppDb AppDb => Service(Wf.AppDb);

        OpCodeKinds CalcOpCodeKinds()
            => Data(nameof(CalcOpCodeKinds), () => new OpCodeKinds());

        public OpCodeKinds LoadOpCodeKinds()
            => CalcOpCodeKinds();

        public RuleOpParser OpParser => Service(RuleOpParser.create);

        public Index<PointerWidthInfo> LoadPointerWidths()
            => Data(nameof(LoadPointerWidths), () => mapi(PointerWidths, (i,w) => w.ToRecord((byte)i)));

        public Index<OpWidth> LoadOperandWidths()
            => Data(nameof(LoadOperandWidths), CalcOperandWidths);

        public ReadOnlySpan<NonterminalKind> NonterminalKinds()
            => Symbols.index<NonterminalKind>().Kinds;

        Outcome ParseIClass(string src, out IClass dst)
            => InstClasses.ExprKind(src, out dst);

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

        ConstLookup<string,OpWidth> LoadOpWidthsLookup()
        {
            return Data(nameof(LoadOpWidthsLookup), Load);

            ConstLookup<string,OpWidth> Load()
            {
                var widths = LoadOperandWidths();
                var dst = dict<string,OpWidth>();
                var symbols = Symbols.index<OperandWidthKind>();
                var count = widths.Length;
                for(var i=0; i<count; i++)
                    dst[symbols[widths[i].Code].Expr.Format()] = widths[i];
                return dst;
            }
        }

        static Symbols<FieldKind> FieldKinds;

        static Symbols<RuleMacroKind> MacroKinds;

        static Symbols<BCastKind> BCastKinds;

        static Symbols<ChipCode> ChipCodes;

        static Symbols<XedRegId> XedRegs;

        static Symbols<IClass> InstClasses;

        static Symbols<RuleOperator> RuleOps;

        static Symbols<DispExprKind> DispKinds;

        static Symbols<ConstraintKind> ConstraintKinds;

        static Symbols<NonterminalKind> Nonterminals;

        static Symbols<OpCodeIndex> OcKindIndex;

        static Symbols<OperandAction> OpActions;

        static Symbols<OperandWidthKind> OpWidthKinds;

        static Symbols<PointerWidthKind> PointerWidthKinds;

        static Symbols<ElementKind> DataTypes;

        static Symbols<RuleOpName> OpNames;

        static Symbols<OpVisiblity> Supressions;

        static Symbols<EncodingGroup> EncodingGroups;

        static ConstLookup<RuleMacroKind,MacroSpec> MacroLookup;

        static XedRules()
        {
            FieldKinds = Symbols.index<FieldKind>();
            MacroKinds = Symbols.index<RuleMacroKind>();
            BCastKinds = Symbols.index<BCastKind>();
            ChipCodes = Symbols.index<ChipCode>();
            XedRegs = Symbols.index<XedRegId>();
            OpWidthKinds = Symbols.index<OperandWidthKind>();
            InstClasses = Symbols.index<IClass>();
            RuleOps = Symbols.index<RuleOperator>();
            DispKinds = Symbols.index<DispExprKind>();
            ConstraintKinds = Symbols.index<ConstraintKind>();
            Nonterminals = Symbols.index<NonterminalKind>();
            OcKindIndex = Symbols.index<OpCodeIndex>();
            OpActions = Symbols.index<OperandAction>();
            OpNames = Symbols.index<RuleOpName>();
            PointerWidthKinds = Symbols.index<PointerWidthKind>();
            Supressions = Symbols.index<OpVisiblity>();
            DataTypes = Symbols.index<ElementKind>();
            EncodingGroups = Symbols.index<EncodingGroup>();
            MacroLookup = RuleMacros.lookup();
       }

        static XedFormatters Formatters = XedFormatters.create();

        static MsgPattern<string> StepParseFailed => "Failed to parse step from '{0}'";
    }
}