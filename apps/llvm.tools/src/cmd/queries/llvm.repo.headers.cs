//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmCmd
    {
        [CmdOp("llvm/repo/headers")]
        Outcome LlvmHeaders(CmdArgs args)
            => Flow(LlvmRepo.Files(FS.H));

        [CmdOp("llvm/repo/build/lib")]
        Outcome LLvmBuildLibs(CmdArgs args)
            => Flow(LlvmRepo.BuildOutput(FS.Lib));

        [CmdOp("llvm/repo/build/obj")]
        Outcome LLvmBuildObj(CmdArgs args)
            => Flow(LlvmRepo.BuildOutput(FS.Obj));
    }
}