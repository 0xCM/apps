//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class XedDb
    {
        public void EmitRuleSchema()
        {
            var src = RuleCells;
            exec(PllExec,
                () => EmitRuleMetrics(src),
                () => EmitTableDefs(src)
                );
        }
    }
}