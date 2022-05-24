//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class WsCmdRunner : AppCmdService<WsCmdRunner,CmdShellState>, IWsCmdRunner<WsCmdRunner>
    {
        IProjectWs _Project;

        public new FileCatalog ProjectFiles {get; private set;}

        WsUnserviced Unserviced;

        protected override void Initialized()
        {
            Unserviced = WsUnserviced.create(Ws);
        }

        public void Project(IProjectWs ws)
        {
            _Project = Require.notnull(ws);
            ProjectFiles = FileCatalog.load(ws);
        }

        public IProjectWs Project()
            => Require.notnull(_Project);

        public void LoadProject(CmdArgs args)
            => LoadProjectSources(Ws.Project(arg(args,0).Value));

        public void RunCmd(string name)
        {
            var result = Dispatcher.Dispatch(name);
            if(result.Fail)
                Error(result.Message);
        }

        public FS.Files SourceFiles(IProjectWs ws, Subject? scope)
        {
            if(scope != null)
                return ws.SrcFiles(scope.Value.Format());
            else
                return ws.SrcFiles();
        }

        public Outcome RunScript(IProjectWs ws, CmdArgs args, ScriptId script, Subject? scope = null)
        {
            var result = Outcome.Success;
            if(args.Count != 0)
            {
                result = OmniScript.RunProjectScript(ws.Project, arg(args,0).Value, script, false, out _);
                return result;
            }

            var src = SourceFiles(ws, scope).View;
            if(result.Fail)
                return result;

            for(var i=0; i<src.Length; i++)
                RunProjectScript(ws, skip(src,i), script);

            return result;
        }

        public void RunCmd(string name, CmdArgs args)
            => Dispatcher.Dispatch(name, args);

        public void DispatchJobs(FS.FilePath src)
        {
            var lines = src.ReadNumberedLines(true);
            var count = lines.Count;
            for(var i=0; i<count; i++)
                Dispatch(Cmd.cmdspec(lines[i].Content));
        }

        public Outcome RunProjectScript(IProjectWs project, FS.FilePath path, ScriptId script)
        {
            var srcid = path.FileName.WithoutExtension.Format();
            OmniScript.RunProjectScript(project.Project, srcid, script, true, out var flows);
            for(var j=0; j<flows.Length; j++)
            {
                ref readonly var flow = ref skip(flows, j);
                Write(flow.Format());
            }
            return true;
        }

        public Outcome<Index<ToolCmdFlow>> RunScript(IProjectWs project, ScriptId scriptid, bool runexe = true, Action<ToolCmdFlow> receiver = null)
        {
            var result = OmniScript.RunProjectScript(project.Project, scriptid, true, out var flows);
            if(result)
            {
                var exeflow = default(ToolCmdFlow?);
                var count = flows.Length;
                if(count != 0)
                {
                    var data = alloc<ToolCmdFlow>(count);
                    for(var j=0; j<count; j++)
                    {
                        ref readonly var flow = ref skip(flows,j);
                        seek(data,j) = flow;
                        Status(flow.Format());
                        receiver?.Invoke(flow);
                        if(flow.TargetPath.FileName.Is(FS.Exe))
                            exeflow = flow;
                    }


                    TableEmit(@readonly(data), ToolCmdFlow.RenderWidths, Unserviced.ScriptFlowPath(project,scriptid));

                    if(runexe && exeflow != null)
                        RunExe(exeflow.Value);

                    return (true, data);
                }
                else
                    return true;
            }
            else
                return result;
        }

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

        public void RunJobs(string match)
        {
            var paths = ProjectDb.JobSpecs();
            var count = paths.Length;
            var counter = 0u;
            for(var i=0; i<count; i++)
            {
                ref readonly var path = ref paths[i];
                if(path.FileName.Format().StartsWith(match))
                {
                    var dispatching = Running(string.Format("Dispatching job {0} defined by {1}", counter, path.ToUri()));
                    DispatchJobs(path);
                    Ran(dispatching, string.Format("Dispatched job {0}", counter));
                    counter++;
                }
            }

            if(counter == 0)
            {
                Warn(string.Format("No jobs identified by '{0}'", match));
            }
        }

        bool LoadProjectSources(IProjectWs ws)
        {
            if(ws == null)
            {
                Error("Project unspecified");
                return false;
            }

            Project(ws);
            Status(LoadingSources.Format(ws.Project));

            var dir = ws.Home();
            if(dir.Exists)
                Files(ws.SrcFiles());
            else
            {
                Error(ProjectUndefined.Format(ws.Project));
                return false;
            }
            return true;
        }

        static MsgPattern<ProjectId> ProjectUndefined
            => "Project {0} undefined";

        static MsgPattern<ProjectId> LoadingSources
            => "Loading {0} sources";
    }
}