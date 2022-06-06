//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using llvm;

    using static core;
    using static llvm.LlvmSubtarget;

    partial class ProjectSvc
    {
        public Outcome<Index<ToolCmdFlow>> RunBuildScripts(IProjectWs project, ScriptId scriptid, Subject? scope, bool runexe)
            => Projects.RunBuildScripts(project, scriptid, scope, flow => HandleBuildResponse(flow, runexe));


        void RunExe(ToolCmdFlow flow)
        {
            var running = Running(string.Format("Executing {0}", flow.TargetPath.ToUri()));
            var result = OmniScript.Run(flow.TargetPath, CmdVars.Empty, quiet: true, out var response);
            if (result.Fail)
                Error(result.Message);
            else
            {
                for (var i=0; i<response.Length; i++)
                    Write(string.Format("exec >> {0}",skip(response, i).Content), FlairKind.StatusData);

                Ran(running, string.Format("Executed {0}", flow.TargetPath.ToUri()));
            }
        }

        public void HandleBuildResponse(ToolCmdFlow flow, bool runexe)
        {
            if(flow.TargetPath.FileName.Is(FS.Exe) && runexe)
                RunExe(flow);
        }
    }
}