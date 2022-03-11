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

        Index<InstRulePart,string> PartNames;

        Index<PointerWidth> PointerWidths;

        Symbols<VisibilityKind> Visibilities;

        Symbols<FieldType> FieldTypes;

        XedInstDefParser InstDefParser;

        public XedRules()
        {
            PointerWidths = map(PointerWidthKinds.View, s => (PointerWidth)s);
            Visibilities = Symbols.index<VisibilityKind>();
            FieldTypes = Symbols.index<FieldType>();
            PartNames = new string[]{ICLASS,IFORM,ATTRIBUTES,CATEGORY,EXTENSION,FLAGS,PATTERN,OPERANDS,ISA_SET,COMMENT};
            InstDefParser = new(this);
        }

        XedPaths XedPaths => Service(Wf.XedPaths);

        AppDb AppDb => Service(Wf.AppDb);

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

        static Symbols<ConstraintKind> ConstraintKinds;

        static Symbols<NonterminalKind> Nonterminals;

        static Symbols<OperandWidthCode> OpWidthKinds;

        static Symbols<PointerWidthKind> PointerWidthKinds;

        static ConstLookup<RuleMacroKind,MacroSpec> MacroLookup;

        static XedRules()
        {
            FieldKinds = Symbols.index<FieldKind>();
            MacroKinds = Symbols.index<RuleMacroKind>();
            OpWidthKinds = Symbols.index<OperandWidthCode>();
            ConstraintKinds = Symbols.index<ConstraintKind>();
            Nonterminals = Symbols.index<NonterminalKind>();
            PointerWidthKinds = Symbols.index<PointerWidthKind>();
            MacroLookup = RuleMacros.lookup();
       }

        static MsgPattern<string> StepParseFailed => "Failed to parse step from '{0}'";
    }
}