//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        [SymSource(xed)]
        public enum RuleOperator
        {
            [Symbol("")]
            None,

            [Symbol("=")]
            Eq,

            [Symbol("!=")]
            Neq,

            [Symbol(":=")]
            Assign
        }
    }
}