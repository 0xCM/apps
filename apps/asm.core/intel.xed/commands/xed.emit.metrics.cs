//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;

    partial class XedCmdProvider
    {
        [CmdOp("xed/emit/metrics")]
        Outcome EmitMetrics(CmdArgs args)
        {
            Rules.EmitRuleMetrics(CalcRuleCells());
            return true;
        }
    }
}