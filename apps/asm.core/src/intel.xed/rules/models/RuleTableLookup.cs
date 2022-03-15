//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public sealed class RuleTableLookup : ConstLookup<RuleSig,RuleTable>
        {
            public RuleTableLookup(Dictionary<RuleSig,RuleTable> src)
                : base(src)
            {


            }

            public RuleTableLookup(RuleTable[] src)
                : base(src.Select(x => (x.Sig, x)).ToDictionary())
            {

            }

            public static implicit operator RuleTableLookup(RuleTable[] src)
                => new RuleTableLookup(src);

            public static implicit operator RuleTableLookup(Dictionary<RuleSig,RuleTable> src)
                => new RuleTableLookup(src);
        }
   }
}