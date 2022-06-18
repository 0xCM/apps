//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class WsScripts : WfSvc<WsScripts>
    {
        OmniScript OmniScript => Wf.OmniScript();

        public FS.FolderPath CleanOutDir(IWsProject project)
            => project.OutDir().Clear(true);

        public FS.Files SourceFiles(IWsProject src, Subject? scope)
        {
            if(scope != null)
                return src.SrcFiles(scope.Value.Format());
            else
                return src.SrcFiles();
        }

        public Outcome<Index<CmdFlow>> BuildAsm(IWsProject src)
            => RunBuildScripts(src, "build", "asm", false);

        public Outcome<Index<CmdFlow>> BuildScoped(IWsProject src, ScriptId script, string scope)
            => RunBuildScripts(src, script, scope, false);

        public Outcome<Index<CmdFlow>> BuildC(IWsProject src, bool runexe = false)
            => RunBuildScripts(src, "c-build", "c", runexe);

        public Outcome<Index<CmdFlow>> BuildCpp(IWsProject src, bool runexe = false)
            => RunBuildScripts(src, "cpp-build", "cpp", runexe);

        public Outcome<Index<CmdFlow>> RunBuildScripts(IWsProject project, ScriptId scriptid, Subject? scope, bool runexe)
            => RunBuildScripts(project, scriptid, scope, flow => HandleBuildResponse(flow, runexe));

        void RunExe(CmdFlow flow)
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

        void HandleBuildResponse(CmdFlow flow, bool runexe)
        {
            if(flow.TargetPath.FileName.Is(FS.Exe) && runexe)
                RunExe(flow);
        }

        public Outcome<Index<CmdFlow>> RunBuildScripts(IWsProject project, ScriptId scriptid, Subject? scope, Action<CmdFlow> receiver)
        {
            var result = Outcome<Index<CmdFlow>>.Success;
            var cmdflows = list<CmdFlow>();
            if(nonempty(scriptid))
            {
                var files = SourceFiles(project, scope);
                int length = files.Length;
                for(var i=0; i<length; i++)
                {
                    var path = files[i];
                    var srcid = path.FileName.WithoutExtension.Format();
                    result = OmniScript.RunScript(project, scriptid, srcid);
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
                Index<CmdFlow> records = cmdflows.ToArray();
                TableEmit(records.View, Flows.flow(project.Project));
                result = (true,records);
            }

            return result;
        }
    }
}