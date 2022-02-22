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

        Dictionary<string,string> BuildJobNames {get;}
            = core.array(("mc.models", "mc/build"),
                        ("clang.models","clang/build/c"),
                        ("llvm.models","llc/build")
            ).ToDictionary();


        [CmdOp("project/build")]
        Outcome BuildProject(CmdArgs args)
        {
            var project = Project();
            var name = project.Name;
            if(BuildJobNames.TryGetValue(name, out var job))
            {

            }


            // var result = WsProjects.RunScript(project,ProjectScriptNames.Build);
            // if(result.Fail)
            //     return result;

            // Collect(project);

            return true;
        }

        [CmdOp("project/clean")]
        Outcome CleanProject(CmdArgs args)
        {
            var project = Project();
            Status(string.Format("Cleared {0}", WsProjects.CleanOutDir(project)));
            return true;
        }
    }
}