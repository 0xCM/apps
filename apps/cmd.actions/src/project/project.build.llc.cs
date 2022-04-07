//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using llvm;

    partial class ProjectCmdProvider
    {
        [CmdOp("project/build/llc")]
        Outcome LlcBuild(CmdArgs args)
        {
            var result = Projects.BuildLlc(Project(), SubtargetKind.Avx512, true);
            if(result)
            {
                var flows = result.Data;
            }
            return result;
        }

        [CmdOp("project/build/llc-sse")]
        Outcome LlcSse(CmdArgs args)
            => Projects.BuildLlc(Project(), SubtargetKind.Sse);

        [CmdOp("project/build/llc-sse2")]
        Outcome LlcSse2(CmdArgs args)
            => Projects.BuildLlc(Project(), SubtargetKind.Sse2);

        [CmdOp("project/build/llc-sse3")]
        Outcome LlcSse3(CmdArgs args)
            => Projects.BuildLlc(Project(), SubtargetKind.Sse3);

        [CmdOp("project/build/llc-sse41")]
        Outcome LlcSse41(CmdArgs args)
            => Projects.BuildLlc(Project(), SubtargetKind.Sse41);

        [CmdOp("project/build/llc-sse42")]
        Outcome LlcSse42(CmdArgs args)
            => Projects.BuildLlc(Project(), SubtargetKind.Sse42);

        [CmdOp("project/build/llc-avx")]
        Outcome LlcAvx(CmdArgs args)
            => Projects.BuildLlc(Project(), SubtargetKind.Avx);

        [CmdOp("project/build/llc-avx2")]
        Outcome LlcAvx2(CmdArgs args)
            => Projects.BuildLlc(Project(), SubtargetKind.Avx2);

        [CmdOp("project/build/llc-avx512")]
        Outcome LlcAvx512(CmdArgs args)
            => Projects.BuildLlc(Project(), SubtargetKind.Avx512);

        [CmdOp("project/build+run/llc-avx512")]
        Outcome LlcAvx512BuildRun(CmdArgs args)
            => Projects.BuildLlc(Project(), SubtargetKind.Avx512, true);
    }
}