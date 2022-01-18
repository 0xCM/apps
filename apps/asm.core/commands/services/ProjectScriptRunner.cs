//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{

    using static core;

    public class ProjectScriptRunner : AppService<ProjectScriptRunner>
    {
        const string ErrorMarker = "error:";

        const string WarningMarker = "warning:";

        const string FlowsPattern = "{0}.flows";

        public void RunScripts(IProjectWs project, string cmdname, string cmdsrc, IFileFlowType flowtype, ICmdScriptBuilder builder)
        {
            project.Out().Delete();
            var runlog = project.Out() + FS.file(cmdname, FS.Log);
            var running = Running();
            var flowlog = project.Out() + FS.file(string.Format(FlowsPattern, cmdname), FS.Log);
            var eflows = EmittingFile(flowlog);
            var counter = 0u;

            using var flows = ProjectLog.open(project, string.Format(FlowsPattern, cmdname));

            void OnStatus(in string msg)
            {
                Write(msg, FlairKind.Status);
            }

            void OnError(in string msg)
            {
                if(text.contains(msg, ErrorMarker))
                    Write(msg, FlairKind.Error);
                else if(text.contains(msg, WarningMarker))
                    Write(msg, FlairKind.Warning);
            }

            void ExecCmd(CmdLine src)
            {
                OmniScript.Run(src, CmdVars.Empty, runlog, OnStatus, OnError, out var output);
                var responses = CmdResponse.parse(output.Where(x => !x.Contains(WarningMarker) && !x.Contains(ErrorMarker)));
                counter += (uint)responses.Length;
                iter(responses, r => flows.WriteLine(r.Format()));
            }

            iter(builder.BuildCmdLines(project, cmdsrc, flowtype), ExecCmd);

            EmittedFile(eflows, counter);
            Ran(running);
        }
    }
}