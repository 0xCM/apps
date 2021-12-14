//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmCmdProvider
    {
        const string InstPatternEmit = "llvm/emit/inst/patterns";

        [CmdOp(InstPatternEmit)]
        Outcome EmitInstPatterns(CmdArgs args)
        {
            DataEmitter.EmitInstPatterns();
            return true;
        }
    }
}