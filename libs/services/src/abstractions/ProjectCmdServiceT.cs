//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public abstract class ProjectCmdService<T> : AppCmdService<T>, IProjectProvider
        where T : ProjectCmdService<T>, new()
    {
        IWsProject _Project;

        [MethodImpl(Inline)]
        public IWsProject Project()
            => _Project;

        ConcurrentDictionary<ProjectId,WsContext> _Context = new();

        protected WsContext Context()
        {
            var project = Project();
            return _Context.GetOrAdd(project.Id, _ => WsContext.load(project));
        }

        protected void LoadProject(IWsProject project)
        {
            if(project == null)
            {
                Error("Project unspecified");
                return;
            }

            _Project = project;
            var outcome = Outcome.Success;
            var dir = project.Home();
            outcome = dir.Exists;
            if(outcome)
                Files(project.SrcFiles());
            else
                outcome = (false, Msg.ProjectUndefined.Format(project.Project));
        }

        [CmdOp("project")]
        protected void LoadProject(CmdArgs args)
            => LoadProject(AppDb.DevProjects("llvm.models").Project(arg(args,0).Value));

        [CmdOp("project/home")]
        protected void ProjectHome()
            => Write(Context().Project.Home());

        [CmdOp("project/files")]
        protected void ProjectFiles(CmdArgs args)
        {
            if(args.Count != 0)
                iter(Context().Catalog.Entries(arg(args,0)), file => Write(file.Format()));
            else
                iter(Context().Catalog.Entries(), file => Write(file.Format()));
        }
    }
}