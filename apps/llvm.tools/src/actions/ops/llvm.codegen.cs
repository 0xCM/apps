//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmCmdProvider
    {
        const string GenCodeCmd = "llvm/codegen";

        [CmdOp(GenCodeCmd)]
        Outcome GenCode(CmdArgs args)
        {
            LlvmCodeGen.Run();
            return true;
        }
    }
}