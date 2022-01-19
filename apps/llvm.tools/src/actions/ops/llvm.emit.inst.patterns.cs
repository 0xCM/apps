//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmCmdProvider
    {
        [CmdOp("llvm/emit/inst/patterns")]
        Outcome EmitInstPatterns(CmdArgs args)
        {
            DataEmitter.EmitInstPatterns();
            return true;
        }
    }
}