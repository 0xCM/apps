//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmCmd
    {
        [CmdOp("repo/headers")]
        Outcome LlvmHeaders(CmdArgs args)
            => Flow(LlvmRepo.Files(FS.H));

        [CmdOp("repo/defs")]
        Outcome LlvmDefs(CmdArgs args)
            => Flow(LlvmRepo.Files(FS.Def));

        [CmdOp("repo/build/lib")]
        Outcome LLvmBuildLibs(CmdArgs args)
            => Flow(LlvmRepo.BuildOutput(FS.Lib));

        [CmdOp("repo/build/obj")]
        Outcome LLvmBuildObj(CmdArgs args)
            => Flow(LlvmRepo.BuildOutput(FS.Obj));
    }
}