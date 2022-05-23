//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmCmdProvider
    {
        [CmdOp("llvm/emit/classlines")]
        void ClassLines(CmdArgs args)
            => Query.FileEmit("llvm.classes.lines", arg(args,0).Value, DataProvider.ClassLines(arg(args,0).Value));
    }
}