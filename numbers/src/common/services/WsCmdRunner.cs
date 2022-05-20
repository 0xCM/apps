//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class WsCmdRunner : AppCmdService<WsCmdRunner,CmdShellState>, IWsCmdRunner<WsCmdRunner>
    {
        IProjectWs _Project;

        public WsCmdRunner()
        {
            ProjectSelected += ws => {
            };
        }

        public event Action<IProjectWs> ProjectSelected;

        public void Project(IProjectWs ws)
        {
            _Project = Require.notnull(ws);
            ProjectSelected.Invoke(ws);
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

        public void RunCmd(string name, CmdArgs args)
            => Dispatcher.Dispatch(name, args);

        public void DispatchJobs(FS.FilePath src)
        {
            var lines = src.ReadNumberedLines(true);
            var count = lines.Count;
            for(var i=0; i<count; i++)
                Dispatch(Cmd.cmdspec(lines[i].Content));
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