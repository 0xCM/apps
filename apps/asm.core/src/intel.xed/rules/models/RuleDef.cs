//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    partial class XedRules
    {
        public readonly struct RuleDef
        {
            public readonly RulePatternInfo Pattern;

            public readonly Index<RuleOperand> Operands;

            [MethodImpl(Inline)]
            public RuleDef(RulePatternInfo pattern, RuleOperand[] ops)
            {
                Pattern = pattern;
                Operands = ops;
            }
        }
    }
}