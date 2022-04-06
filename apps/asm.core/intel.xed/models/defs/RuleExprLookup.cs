//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public class RuleExprLookup : SortedLookup<RuleExprKey,CellDef>
        {
            public RuleExprLookup(Dictionary<RuleExprKey,CellDef> src)
                : base(src)
            {

            }

            public static implicit operator RuleExprLookup(Dictionary<RuleExprKey,CellDef> src)
                => new RuleExprLookup(src);
        }
    }
}