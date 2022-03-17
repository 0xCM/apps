//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public sealed class RuleTableDefs : ConstLookup<RuleSig,Rule>
        {
            RuleTableDefs()
                : base(core.dict<RuleSig,Rule>())
            {

            }

            public RuleTableDefs(Dictionary<RuleSig,Rule> src)
                : base(src)
            {

            }

            public RuleTableDefs(Rule[] src)
                : base(src.Select(x => (x.Sig, x)).ToDictionary())
            {

            }

            public static implicit operator RuleTableDefs(Rule[] src)
                => new RuleTableDefs(src);

            public static implicit operator RuleTableDefs(Dictionary<RuleSig,Rule> src)
                => new RuleTableDefs(src);

            public static new RuleTableDefs Empty => new();
        }
   }
}