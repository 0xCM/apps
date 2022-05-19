//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ProjectCmd
    {
        Dictionary<string,string> BuildCmdNames {get;}
            = core.array(("mc.models", "project/build/asm"),
                        ("clang.models","project/build/c"),
                        ("llvm.models","project/build/llc"),
                        ("canonical","project/build/builtins")
            ).ToDictionary();


        [CmdOp("project/build")]
        Outcome BuildProject(CmdArgs args)
        {
            var project = Project();
            if(BuildCmdNames.TryGetValue(project.Name, out var name))
            {
                Commands.RunCmd(name);
            }
            else
            {
                Warn(string.Format("No build job found for {0}", project.Name));
            }

            return true;
        }
    }
}