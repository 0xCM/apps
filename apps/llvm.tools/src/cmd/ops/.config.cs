//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
     using static core;

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