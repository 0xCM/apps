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

        Symbols<IsaKind> IsaKinds;

        Index<InstRulePart,string> PartNames;

        Index<PointerWidth> PointerWidths;

        Symbols<VisibilityKind> Visibilities;

        Symbols<FieldType> FieldTypes;

        XedInstDefParser InstDefParser;

        public XedRules()
        {
            Categories = Symbols.index<CategoryKind>();
            IsaKinds = Symbols.index<IsaKind>();
            PointerWidths = map(PointerWidthKinds.View, s => (PointerWidth)s);
            Visibilities = Symbols.index<VisibilityKind>();
            FieldTypes = Symbols.index<FieldType>();
            PartNames = new string[]{ICLASS,IFORM,ATTRIBUTES,CATEGORY,EXTENSION,FLAGS,PATTERN,OPERANDS,ISA_SET,COMMENT};
            InstDefParser = new(this);
        }

        XedPaths XedPaths => Service(Wf.XedPaths);

        AppDb AppDb => Service(Wf.AppDb);

        public Index<PointerWidthInfo> CalcPointerWidths()
            => Data(nameof(CalcPointerWidths), () => mapi(PointerWidths.Where(x => x.Kind != 0), (i,w) => w.ToRecord((byte)i)));

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

        ConstLookup<string,OpWidth> LoadOpWidthsLookup()
        {
            return Data(nameof(LoadOpWidthsLookup), Load);

            ConstLookup<string,OpWidth> Load()
            {
                var widths = LoadOperandWidths();
                var dst = dict<string,OpWidth>();
                var symbols = Symbols.index<OperandWidthCode>();
                var count = widths.Length;
                for(var i=0; i<count; i++)
                    dst[symbols[widths[i].Code].Expr.Format()] = widths[i];
                return dst;
            }
        }

        static Symbols<FieldKind> FieldKinds;

        static Symbols<RuleMacroKind> MacroKinds;

        static Symbols<XedRegId> XedRegs;

        static Symbols<IClass> InstClasses;

        static Symbols<ConstraintKind> ConstraintKinds;

        static Symbols<NonterminalKind> Nonterminals;

        static Symbols<OperandWidthCode> OpWidthKinds;

        static Symbols<PointerWidthKind> PointerWidthKinds;

        static Symbols<RuleOpName> OpNames;

        static ConstLookup<RuleMacroKind,MacroSpec> MacroLookup;

        static XedRules()
        {
            FieldKinds = Symbols.index<FieldKind>();
            MacroKinds = Symbols.index<RuleMacroKind>();
            XedRegs = Symbols.index<XedRegId>();
            OpWidthKinds = Symbols.index<OperandWidthCode>();
            InstClasses = Symbols.index<IClass>();
            ConstraintKinds = Symbols.index<ConstraintKind>();
            Nonterminals = Symbols.index<NonterminalKind>();
            OpNames = Symbols.index<RuleOpName>();
            PointerWidthKinds = Symbols.index<PointerWidthKind>();
            MacroLookup = RuleMacros.lookup();
       }

        static XedRender Formatters = XedRender.create();

        static MsgPattern<string> StepParseFailed => "Failed to parse step from '{0}'";
    }
}