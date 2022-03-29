//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        const string xed = "xed";

        [SymSource(xed)]
        public enum RuleOperator : byte
        {
            [Symbol("")]
            None,

            [Symbol("=")]
            Assign,

            [Symbol("!=")]
            CmpNeq,

            [Symbol("==")]
            CmpEq,
        }

        [SymSource(xed), DataWidth(2)]
        public enum ConstraintKind : byte
        {
            [Symbol("")]
            None,

            [Symbol("=")]
            Eq = RuleOperator.Assign,

            [Symbol("!=")]
            Neq = RuleOperator.CmpNeq,
        }
    }
}