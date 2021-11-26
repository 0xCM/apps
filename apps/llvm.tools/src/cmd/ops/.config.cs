//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmCmd
    {
        [CmdOp(".config")]
        Outcome LlvmConfig(CmdArgs args)
        {
           var config = RecordEtl.ComputeConfig();
           return true;
        }
    }
}