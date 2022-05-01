//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        [SymSource(xed), DataWidth(3,8)]
        public enum OperatorKind : byte
        {
            [Symbol(RuleOperator.EmptySym)]
            None,

            [Symbol(RuleOperator.EqSym)]
            Eq,

            [Symbol(RuleOperator.NeSym)]
            Ne,

            [Symbol(RuleOperator.AndSym)]
            And,

            [Symbol(RuleOperator.ImplSym)]
            Impl,
        }
    }
}