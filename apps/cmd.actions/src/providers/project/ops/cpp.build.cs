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
        [CmdOp("cpp/build")]
        Outcome BuildCpp(CmdArgs args)
            => ProjectScripts.RunScript(Project(), EmptyString, CppBuild, "cpp");
    }
}