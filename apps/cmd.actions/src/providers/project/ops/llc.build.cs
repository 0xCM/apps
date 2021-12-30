//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Root;
    using static ProjectScriptNames;

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
            => ProjectScripts.RunScript(Project(), EmptyString, LlcBuildSse);

        [CmdOp("llc/build/sse2")]
        Outcome LlcSse2(CmdArgs args)
            => ProjectScripts.RunScript(Project(), EmptyString, LlcBuildSse2);

        [CmdOp("llc/build/sse3")]
        Outcome LlcSse3(CmdArgs args)
            => ProjectScripts.RunScript(Project(), EmptyString, LlcBuildSse3);

        [CmdOp("llc/build/sse41")]
        Outcome LlcSse41(CmdArgs args)
            => ProjectScripts.RunScript(Project(), EmptyString, LlcBuildSse41);

        [CmdOp("llc/build/sse42")]
        Outcome LlcSse42(CmdArgs args)
            => ProjectScripts.RunScript(Project(), EmptyString, LlcBuildSse42);

        [CmdOp("llc/build/avx")]
        Outcome LlcAvx(CmdArgs args)
            => ProjectScripts.RunScript(Project(), EmptyString, LlcBuildAvx);

        [CmdOp("llc/build/avx2")]
        Outcome LlcAvx2(CmdArgs args)
            => ProjectScripts.RunScript(Project(), EmptyString, LlcBuildAvx2);

        [CmdOp("llc/build/avx512")]
        Outcome LlcAvx512(CmdArgs args)
            => ProjectScripts.RunScript(Project(), EmptyString, LlcBuildAvx512);
    }
}