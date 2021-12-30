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
        [CmdOp("c/build")]
        Outcome BuildCProj(CmdArgs args)
            => ProjectScripts.RunScript(Project(), EmptyString, CBuild, "c");
    }
}