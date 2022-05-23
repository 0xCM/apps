//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmCmdProvider
    {
        [CmdOp("llvm/emit/classnames")]
        void EmitClassNames()
            => Query.FileEmit("llvm.classes.names", DataProvider.ClassNames().View);
    }
}