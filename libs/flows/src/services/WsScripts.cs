//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class WsScripts : AppService<WsScripts>
    {
        OmniScript OmniScript => Wf.OmniScript();

        AppSvcOps AppSvc => Wf.AppSvc();

        public FS.FolderPath CleanOutDir(IProjectWs project)
            => project.OutDir().Clear(true);

        public FS.Files SourceFiles(IProjectWs src, Subject? scope)
        {
            if(scope != null)
                return src.SrcFiles(scope.Value.Format());
            else
                return src.SrcFiles();
        }

        public Outcome<Index<ToolCmdFlow>> BuildAsm(IProjectWs src)
            => RunBuildScripts(src, "build", "asm", false);

        public Outcome<Index<ToolCmdFlow>> BuildScoped(IProjectWs src, ScriptId script, string scope)
            => RunBuildScripts(src, script, scope, false);

        public Outcome<Index<ToolCmdFlow>> BuildC(IProjectWs src, bool runexe = false)
            => RunBuildScripts(src, "c-build", "c", runexe);

        public Outcome<Index<ToolCmdFlow>> BuildCpp(IProjectWs src, bool runexe = false)
            => RunBuildScripts(src, "cpp-build", "cpp", runexe);

        public Outcome<Index<ToolCmdFlow>> RunBuildScripts(IProjectWs project, ScriptId scriptid, Subject? scope, bool runexe)
            => RunBuildScripts(project, scriptid, scope, flow => HandleBuildResponse(flow, runexe));

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

        void HandleBuildResponse(ToolCmdFlow flow, bool runexe)
        {
            if(flow.TargetPath.FileName.Is(FS.Exe) && runexe)
                RunExe(flow);
        }

        public Outcome<Index<ToolCmdFlow>> RunBuildScripts(IProjectWs project, ScriptId scriptid, Subject? scope, Action<ToolCmdFlow> receiver)
        {
            var result = Outcome<Index<ToolCmdFlow>>.Success;
            var cmdflows = list<ToolCmdFlow>();
            if(nonempty(scriptid))
            {
                var files = SourceFiles(project, scope);
                int length = files.Length;
                for(var i=0; i<length; i++)
                {
                    var path = files[i];
                    var srcid = path.FileName.WithoutExtension.Format();
                    result = OmniScript.RunScript(project.Project, scriptid, srcid);
                    if(result)
                    {
                        cmdflows.AddRange(result.Data);
                        foreach(var flow in result.Data)
                        {
                            Status(flow.Format());
                            receiver?.Invoke(flow);
                        }
                    }
                }
            }
            else
                result = (false, "Script specification unknown");

            if(cmdflows.Count != 0)
            {
                Index<ToolCmdFlow> records = cmdflows.ToArray();
                AppSvc.TableEmit(records.View, WsApi.flow(project.Project));
                result = (true,records);
            }

            return result;
        }
    }
}