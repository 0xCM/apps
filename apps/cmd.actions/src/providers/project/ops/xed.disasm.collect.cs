//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ProjectCmdProvider
    {
        [CmdOp("xed/disasm/collect")]
        Outcome CollectXedDisasm(CmdArgs args)
        {
            XedDisasm.Collect(Project());
            return true;
        }
    }
}