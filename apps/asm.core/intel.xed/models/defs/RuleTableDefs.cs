//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public sealed class RuleTableDefs : ConstLookup<RuleTableName,RuleTable>
        {
            RuleTableDefs()
                : base(core.dict<RuleTableName,RuleTable>())
            {

            }

            public RuleTableDefs(Dictionary<RuleTableName,RuleTable> src)
                : base(src)
            {

            }

            public RuleTableDefs(RuleTable[] src)
                : base(src.Select(x => (x.Name, x)).ToDictionary())
            {

            }

            public static implicit operator RuleTableDefs(RuleTable[] src)
                => new RuleTableDefs(src);

            public static implicit operator RuleTableDefs(Index<RuleTable> src)
                => new RuleTableDefs(src);

            public static implicit operator RuleTableDefs(Dictionary<RuleTableName,RuleTable> src)
                => new RuleTableDefs(src);

            public static new RuleTableDefs Empty => new();
        }
   }
}