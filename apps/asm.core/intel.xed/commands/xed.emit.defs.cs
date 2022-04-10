//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static Datasets;
    using static core;

    partial class XedCmdProvider
    {
        [CmdOp("xed/emit/defs")]
        Outcome EmitDefs(CmdArgs args)
        {
            var rules = Xed.Rules.CalcRules();
            return true;
        }
    }
}