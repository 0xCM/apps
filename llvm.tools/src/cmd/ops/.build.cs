//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static Root;
    using static ProjectScriptNames;

    partial class LlvmCmd
    {
        [CmdOp(".mc-build")]
        Outcome BuildMc(CmdArgs args)
            => ProjectScripts.RunScript(Project(), EmptyString, McBuild, "asm");

        [CmdOp(".c-build")]
        Outcome BuildCProj(CmdArgs args)
            => ProjectScripts.RunScript(Project(), EmptyString, CBuild, "c");

        [CmdOp(".cpp-build")]
        Outcome BuildCpp(CmdArgs args)
            => ProjectScripts.RunScript(Project(), EmptyString, CppBuild, "cpp");

        [CmdOp(".llc-sse")]
        Outcome LlcSse(CmdArgs args)
            => ProjectScripts.RunScript(Project(), EmptyString, LlcBuildSse);

        [CmdOp(".llc-sse2")]
        Outcome LlcSse2(CmdArgs args)
            => ProjectScripts.RunScript(Project(), EmptyString, LlcBuildSse2);

        [CmdOp(".llc-sse3")]
        Outcome LlcSse3(CmdArgs args)
            => ProjectScripts.RunScript(Project(), EmptyString, LlcBuildSse3);

        [CmdOp(".llc-sse41")]
        Outcome LlcSse41(CmdArgs args)
            => ProjectScripts.RunScript(Project(), EmptyString, LlcBuildSse41);

        [CmdOp(".llc-sse42")]
        Outcome LlcSse42(CmdArgs args)
            => ProjectScripts.RunScript(Project(), EmptyString, LlcBuildSse42);

        [CmdOp(".llc-avx")]
        Outcome LlcAvx(CmdArgs args)
            => ProjectScripts.RunScript(Project(), EmptyString, LlcBuildAvx);

        [CmdOp(".llc-avx2")]
        Outcome LlcAvx2(CmdArgs args)
            => ProjectScripts.RunScript(Project(), EmptyString, LlcBuildAvx2);

        [CmdOp(".llc-avx512")]
        Outcome LlcAvx512(CmdArgs args)
            => ProjectScripts.RunScript(Project(), EmptyString, LlcBuildAvx512);
    }
}