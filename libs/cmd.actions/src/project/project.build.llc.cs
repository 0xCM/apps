//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using llvm;

    partial class ProjectCmd
    {
        [CmdOp("project/build/llc")]
        void LlcBuild()
            => ProjectSvc.BuildLlc(Project(), LlvmSubtarget.Avx512);

        [CmdOp("project/build/llc-sse")]
        Outcome LlcSse(CmdArgs args)
            => ProjectSvc.BuildLlc(Project(), LlvmSubtarget.Sse);

        [CmdOp("project/build/llc-sse2")]
        Outcome LlcSse2(CmdArgs args)
            => ProjectSvc.BuildLlc(Project(), LlvmSubtarget.Sse2);

        [CmdOp("project/build/llc-sse3")]
        Outcome LlcSse3(CmdArgs args)
            => ProjectSvc.BuildLlc(Project(), LlvmSubtarget.Sse3);

        [CmdOp("project/build/llc-sse41")]
        Outcome LlcSse41(CmdArgs args)
            => ProjectSvc.BuildLlc(Project(), LlvmSubtarget.Sse41);

        [CmdOp("project/build/llc-sse42")]
        Outcome LlcSse42(CmdArgs args)
            => ProjectSvc.BuildLlc(Project(), LlvmSubtarget.Sse42);

        [CmdOp("project/build/llc-avx")]
        Outcome LlcAvx(CmdArgs args)
            => ProjectSvc.BuildLlc(Project(), LlvmSubtarget.Avx);

        [CmdOp("project/build/llc-avx2")]
        Outcome LlcAvx2(CmdArgs args)
            => ProjectSvc.BuildLlc(Project(), LlvmSubtarget.Avx2);

        [CmdOp("project/build/llc-avx512")]
        Outcome LlcAvx512(CmdArgs args)
            => ProjectSvc.BuildLlc(Project(), LlvmSubtarget.Avx512);

        [CmdOp("project/build+run/llc-avx512")]
        Outcome LlcAvx512BuildRun(CmdArgs args)
            => ProjectSvc.BuildLlc(Project(), LlvmSubtarget.Avx512);
    }
}