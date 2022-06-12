//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class ProjectCmdService<T> : AppCmdService<T>, IProjectProvider
        where T : ProjectCmdService<T>, new()
    {
        IProjectWs _Project;

        [MethodImpl(Inline)]
        public IProjectWs Project()
            => _Project;

        protected void LoadProject(IProjectWs project)
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
            => LoadProject(Ws.Project(arg(args,0).Value));
    }
}