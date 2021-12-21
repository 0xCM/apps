//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ProjectCmdProvider
    {
        [CmdOp("projects/collect")]
        Outcome CollectAll(CmdArgs args)
        {
            ProjectCollector.Collect();
            return true;
        }
    }
}