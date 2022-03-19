//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public sealed class RuleTableDefs : ConstLookup<RuleSig,RuleTable>
        {
            RuleTableDefs()
                : base(core.dict<RuleSig,RuleTable>())
            {

            }

            public RuleTableDefs(Dictionary<RuleSig,RuleTable> src)
                : base(src)
            {

            }

            public RuleTableDefs(RuleTable[] src)
                : base(src.Select(x => (x.Sig, x)).ToDictionary())
            {

            }

            public static implicit operator RuleTableDefs(RuleTable[] src)
                => new RuleTableDefs(src);

            public static implicit operator RuleTableDefs(Index<RuleTable> src)
                => new RuleTableDefs(src);

            public static implicit operator RuleTableDefs(Dictionary<RuleSig,RuleTable> src)
                => new RuleTableDefs(src);

            public static new RuleTableDefs Empty => new();
        }
   }
}