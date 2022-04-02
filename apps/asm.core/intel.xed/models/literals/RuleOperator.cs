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
            [Symbol("<undefined>")]
            None,

            [Symbol("=")]
            Eq,

            [Symbol("!=")]
            Neq,
        }
    }
}