//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmCmdProvider
    {
        [CmdOp("llvm/codegen")]
        Outcome GenCode(CmdArgs args)
        {
            LlvmCodeGen.Run();
            return true;
        }
    }
}