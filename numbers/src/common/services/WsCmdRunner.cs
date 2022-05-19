//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class WsCmdRunner : AppCmdService<WsCmdRunner,CmdShellState>, ICmdRunner, IProjectProvider
    {
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

        IProjectWs _Project;

        [MethodImpl(Inline)]
        public IProjectWs Project()
            => _Project;

        [MethodImpl(Inline)]
        public IProjectWs Project(ProjectId id)
        {
            _Project = Ws.Project(id);
            return Project();
        }

        public Outcome LoadProject(CmdArgs args)
        {
            var result = Outcome.Success;
            SelectProject(Ws.Project(arg(args,0).Value));
            return result;
        }

        IProjectWs SelectProject(IProjectWs project)
        {
            _Project = project;
            LoadProjectSources();
            return Project();
        }

        Outcome LoadProjectSources()
        {
            var project = Project();
            Write(LoadingSources.Format(project.Project));
            if(project == null)
                return (false, "Project unspecified");

            var outcome = Outcome.Success;
            var dir = project.Home();
            outcome = dir.Exists;
            if(outcome)
                Files(project.SrcFiles());
            else
                outcome = (false, ProjectUndefined.Format(project.Project));
            return outcome;
        }

        static MsgPattern<ProjectId> ProjectUndefined
            => "Project {0} undefined";

        static MsgPattern<ProjectId> LoadingSources
            => "Loading {0} sources";
    }
}