//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmCmd
    {
        [CmdOp(".collect")]
        Outcome Collect(CmdArgs args)
        {
            ProjectCollector.Collect(Project());
            return true;
        }

        [CmdOp(".collect-all")]
        Outcome CollectAll(CmdArgs args)
        {
            ProjectCollector.Collect();
            return true;
        }
    }
}