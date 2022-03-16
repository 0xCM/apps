//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public sealed class RuleTableSet : ConstLookup<RuleSig,RuleTable>
        {
            RuleTableSet()
                : base(core.dict<RuleSig,RuleTable>())
            {

            }

            public RuleTableSet(Dictionary<RuleSig,RuleTable> src)
                : base(src)
            {

            }

            public RuleTableSet(RuleTable[] src)
                : base(src.Select(x => (x.Sig, x)).ToDictionary())
            {

            }

            public static implicit operator RuleTableSet(RuleTable[] src)
                => new RuleTableSet(src);

            public static implicit operator RuleTableSet(Dictionary<RuleSig,RuleTable> src)
                => new RuleTableSet(src);

            public static new RuleTableSet Empty => new();
        }
   }
}