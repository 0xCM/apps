//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmCmd
    {
        [CmdOp(".codegen")]
        Outcome GenCode(CmdArgs args)
        {
            CodeGen.Run();
            return true;
        }

    }
}