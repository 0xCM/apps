//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmCmd
    {
        [CmdOp(".etl")]
        Outcome RunRecordsEtl(CmdArgs args)
        {
            var data = LlvmEtl.Run();
            return true;
        }
    }
}