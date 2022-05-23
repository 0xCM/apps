//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmCmd
    {
        [CmdOp("llvm/list/tools")]
        void ListExe()
            => Flow(LlvmRepo.BuildOutput(FS.Exe));
    }
}