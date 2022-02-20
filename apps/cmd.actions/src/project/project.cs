//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ProjectCmdProvider
    {
        [CmdOp("project")]
        Outcome LoadProject(CmdArgs args)
        {
            var result = Outcome.Success;
            Project(Ws.Project(arg(args,0).Value));
            return result;
        }


        [CmdOp("project/build")]
        Outcome BuildProject(CmdArgs args)
        {
            var project = Project();
            var result = WsProjects.RunScript(project,ProjectScriptNames.Build);
            if(result.Fail)
                return result;

            Collect(project);

            return true;
        }
    }
}