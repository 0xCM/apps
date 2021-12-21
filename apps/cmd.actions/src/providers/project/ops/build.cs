//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using llvm;

    using static Root;
    using static ProjectScriptNames;

    partial class ProjectCmdProvider
    {
        [CmdOp("build/mc")]
        Outcome BuildMc(CmdArgs args)
            => ProjectScripts.RunScript(Project(), EmptyString, McBuild, "asm");

        [CmdOp("build/llc")]
        Outcome LlcBuild(CmdArgs args)
        {
            Llc.Build(Project());
            return true;
        }

        [CmdOp("build/c")]
        Outcome BuildCProj(CmdArgs args)
            => ProjectScripts.RunScript(Project(), EmptyString, CBuild, "c");

        [CmdOp("build/cpp")]
        Outcome BuildCpp(CmdArgs args)
            => ProjectScripts.RunScript(Project(), EmptyString, CppBuild, "cpp");

        [CmdOp("build/llc/sse")]
        Outcome LlcSse(CmdArgs args)
            => ProjectScripts.RunScript(Project(), EmptyString, LlcBuildSse);

        [CmdOp("build/llc/sse2")]
        Outcome LlcSse2(CmdArgs args)
            => ProjectScripts.RunScript(Project(), EmptyString, LlcBuildSse2);

        [CmdOp("build/llc/sse3")]
        Outcome LlcSse3(CmdArgs args)
            => ProjectScripts.RunScript(Project(), EmptyString, LlcBuildSse3);

        [CmdOp("build/llc/sse41")]
        Outcome LlcSse41(CmdArgs args)
            => ProjectScripts.RunScript(Project(), EmptyString, LlcBuildSse41);

        [CmdOp("build/llc/sse42")]
        Outcome LlcSse42(CmdArgs args)
            => ProjectScripts.RunScript(Project(), EmptyString, LlcBuildSse42);

        [CmdOp("build/llc/avx")]
        Outcome LlcAvx(CmdArgs args)
            => ProjectScripts.RunScript(Project(), EmptyString, LlcBuildAvx);

        [CmdOp("build/llc/avx2")]
        Outcome LlcAvx2(CmdArgs args)
            => ProjectScripts.RunScript(Project(), EmptyString, LlcBuildAvx2);

        [CmdOp("build/llc/avx512")]
        Outcome LlcAvx512(CmdArgs args)
            => ProjectScripts.RunScript(Project(), EmptyString, LlcBuildAvx512);
    }
}