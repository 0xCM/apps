//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        public readonly struct RegProductionRule
        {
            public readonly RuleTable Rule;

            [MethodImpl(Inline)]
            public RegProductionRule(RuleTable rule)
            {
                Rule = rule;
            }
        }
    }
}