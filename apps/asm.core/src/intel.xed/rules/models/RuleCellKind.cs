//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules.RuleOperator;

    partial class XedRules
    {
        public enum RuleCellKind : ushort
        {
            None,

            Literal = 1,

            Nonterminal = 2,

            Assignment = 4,

            CmpEq = 8,

            CmpNeq = 16,

            BfSeg = 32,

            Bits = 64,

            Int = 128,

            Hex = 256,

            FieldValue = 512,
        }

        public static RuleOperator ruleop(RuleCellKind src)
        {
            if(src.Test(RuleCellKind.Assignment))
                return Assign;
            else if(src.Test(RuleCellKind.CmpEq))
                return CmpEq;
            else if(src.Test(RuleCellKind.CmpNeq))
                return CmpNeq;
            else
                return 0;
        }
    }
}