//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ProjectCmdProvider
    {
        const string CollectXedDisasmCmd = "xed/disasm/collect";

        [CmdOp(CollectXedDisasmCmd)]
        Outcome CollectXedDisasm(CmdArgs args)
        {
            var records = XedDisasm.Collect(Project());
            return true;
        }
    }
}
