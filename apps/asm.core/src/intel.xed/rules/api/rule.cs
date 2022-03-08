//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        [MethodImpl(Inline), Op]
        public static RuleDef rule(RulePatternInfo pattern, params RuleOp[] ops)
            => new RuleDef(pattern,ops);
    }
}