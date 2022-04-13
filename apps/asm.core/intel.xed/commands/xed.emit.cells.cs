//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedCmdProvider
    {
        [CmdOp("xed/emit/cells")]
        Outcome EmitRuleCells(CmdArgs args)
        {
            var rules = Xed.Rules.CalcRules();
            Xed.Rules.EmitCellSpecs(rules);

            return true;
        }
    }
}