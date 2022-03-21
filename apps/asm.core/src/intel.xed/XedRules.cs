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

        static Index<InstRulePart,string> PartNames = new string[]{ICLASS,IFORM,ATTRIBUTES,CATEGORY,EXTENSION,FLAGS,PATTERN,OPERANDS,ISA_SET,COMMENT};

        Index<PointerWidth> PointerWidths;

        Symbols<VisibilityKind> Visibilities;

        Symbols<FieldType> FieldTypes;

        bool PllExec {get;} = true;

        public XedRules()
        {
            PointerWidths = map(PointerWidthKinds.View, s => (PointerWidth)s);
            Visibilities = Symbols.index<VisibilityKind>();
            FieldTypes = Symbols.index<FieldType>();
        }

        XedPaths XedPaths => Service(Wf.XedPaths);

        AppDb AppDb => Service(Wf.AppDb);

        public XedRuleTables RuleTables => Service(Wf.XedRuleTables);

        ConstLookup<string,OpWidth> LoadOpWidthsLookup()
        {
            return Data(nameof(LoadOpWidthsLookup), Load);

            ConstLookup<string,OpWidth> Load()
            {
                var widths = LoadOperandWidths();
                var dst = dict<string,OpWidth>();
                var symbols = Symbols.index<OpWidthCode>();
                var count = widths.Length;
                for(var i=0; i<count; i++)
                    dst[symbols[widths[i].Code].Expr.Format()] = widths[i];
                return dst;
            }
        }

        static Symbols<OpWidthCode> OpWidthKinds;

        static Symbols<PointerWidthKind> PointerWidthKinds;

        static XedRules()
        {
            OpWidthKinds = Symbols.index<OpWidthCode>();
            PointerWidthKinds = Symbols.index<PointerWidthKind>();
       }

        static MsgPattern<string> StepParseFailed => "Failed to parse step from '{0}'";
    }
}