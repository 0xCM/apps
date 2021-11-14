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

        [CmdOp("repo/cpp")]
        Outcome LlvmCpp(CmdArgs args)
            => Flow(LlvmRepo.Files(FS.Cpp));

        [CmdOp("repo/defs")]
        Outcome LlvmDefs(CmdArgs args)
            => Flow(LlvmRepo.Files(FS.Def));

        [CmdOp("repo/inc")]
        Outcome LlvmInc(CmdArgs args)
            => Flow(LlvmRepo.Files(FS.Inc));

        [CmdOp("repo/table-defs")]
        Outcome LlvmTableDefs(CmdArgs args)
            => Flow(LlvmRepo.Files(FS.Td));

        [CmdOp("repo/build/headers")]
        Outcome LLvmBuildHeaders(CmdArgs args)
            => Flow(LlvmRepo.BuildOutput(FS.H));

        [CmdOp("repo/build/exe")]
        Outcome LLvmBuildTargets(CmdArgs args)
            => Flow(LlvmRepo.BuildOutput(FS.Exe));

        [CmdOp("repo/build/lib")]
        Outcome LLvmBuildLibs(CmdArgs args)
            => Flow(LlvmRepo.BuildOutput(FS.Lib));

        [CmdOp("repo/build/obj")]
        Outcome LLvmBuildObj(CmdArgs args)
            => Flow(LlvmRepo.BuildOutput(FS.Obj));

        [CmdOp("repo/build/inc")]
        Outcome LLvmBuildInc(CmdArgs args)
            => Flow(LlvmRepo.BuildOutput(FS.Inc));

        // [CmdOp("repo/llvm/test")]
        // Outcome LlvmTests(CmdArgs args)
        //     => Flow(LlvmRepo.BuildOutput(FS.ext(arg(args,0).Value)));

    }
}