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
            ProjectEtl.Collect(Project());
            return true;
        }

        [CmdOp(".collect-all")]
        Outcome CollectAll(CmdArgs args)
        {
            ProjectEtl.Collect();
            return true;
        }
    }
}