//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Root;

    using llvm;

    partial class ProjectCmdProvider
    {
        [CmdOp("llc/build")]
        Outcome LlcBuild(CmdArgs args)
        {
            Llc.Build(Project());
            return true;
        }

        [CmdOp("llc/build/sse")]
        Outcome LlcSse(CmdArgs args)
            => Llc.Build(Project(), SubtargetKind.Sse);

        [CmdOp("llc/build/sse2")]
        Outcome LlcSse2(CmdArgs args)
            => Llc.Build(Project(), SubtargetKind.Sse2);

        [CmdOp("llc/build/sse3")]
        Outcome LlcSse3(CmdArgs args)
            => Llc.Build(Project(), SubtargetKind.Sse3);

        [CmdOp("llc/build/sse41")]
        Outcome LlcSse41(CmdArgs args)
            => Llc.Build(Project(), SubtargetKind.Sse41);

        [CmdOp("llc/build/sse42")]
        Outcome LlcSse42(CmdArgs args)
            => Llc.Build(Project(), SubtargetKind.Sse42);

        [CmdOp("llc/build/avx")]
        Outcome LlcAvx(CmdArgs args)
            => Llc.Build(Project(), SubtargetKind.Avx);

        [CmdOp("llc/build/avx2")]
        Outcome LlcAvx2(CmdArgs args)
            => Llc.Build(Project(), SubtargetKind.Avx2);

        [CmdOp("llc/build/avx512")]
        Outcome LlcAvx512(CmdArgs args)
            => Llc.Build(Project(), SubtargetKind.Avx512);

        [CmdOp("llc/build+run/avx512")]
        Outcome LlcAvx512BuildRun(CmdArgs args)
            => Llc.Build(Project(), SubtargetKind.Avx512, true);
    }
}