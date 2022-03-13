//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public sealed class RuleTables : ConstLookup<RuleSig,RuleTable>
        {
            public RuleTables(Dictionary<RuleSig,RuleTable> src)
                : base(src)
            {


            }

            public RuleTables(RuleTable[] src)
                : base(src.Select(x => (x.Sig, x)).ToDictionary())
            {

            }

            public static implicit operator RuleTables(RuleTable[] src)
                => new RuleTables(src);

            public static implicit operator RuleTables(Dictionary<RuleSig,RuleTable> src)
                => new RuleTables(src);
        }
   }
}