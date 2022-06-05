//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    public partial class ProjectCmd : AppCmdProvider<ProjectCmd>, IProjectProvider
    {
        ICmdRunner Commands;

        OmniScript OmniScript => Wf.OmniScript();

        IToolWs Tools => Service(Ws.Tools);

        public static ProjectCmd inject(ICmdRunner runner, ProjectCmd dst)
            => dst.With(runner);

        AsmObjects AsmObjects => Wf.AsmObjects();

        ProjectSvc ProjectSvc => Wf.ProjectSvc();

        WsProjects Projects => Wf.WsProjects();

        AsmRegSets Regs => Service(AsmRegSets.create);

        DumpBin DumpBin => Wf.DumpBin();

        CoffServices CoffServices => Service(Wf.CoffServices);

        AsmFlowCommands AsmFlows => Wf.AsmFlows();

        public ProjectCmd With(ICmdRunner runner)
        {
            Commands = runner;
            return this;
        }

        protected virtual void ProjectSelected(IProjectWs project)
        {

        }


        IProjectWs SelectProject(IProjectWs project)
        {
            _Project = project;
            LoadProjectSources();
            ProjectSelected(project);
            return Project();
        }

        Outcome LoadProjectSources()
        {
            var project = Project();
            Write(Msg.LoadingSources.Format(project.Project));
            if(project == null)
                return (false, "Project unspecified");

            var outcome = Outcome.Success;
            var dir = project.Home();
            outcome = dir.Exists;
            if(outcome)
                Files(project.SrcFiles());
            else
                outcome = (false, Msg.ProjectUndefined.Format(project.Project));
            return outcome;
        }

        [CmdOp("project")]
        protected Outcome LoadProject(CmdArgs args)
        {
            var result = Outcome.Success;
            SelectProject(Ws.Project(arg(args,0).Value));
            return result;
        }

        protected Outcome LoadProjectSources(IProjectWs ws)
        {
            var outcome = Outcome.Success;
            var dir = ws.Home();
            outcome = dir.Exists;
            if(outcome)
                Files(ws.SrcFiles());
            else
                outcome = (false, UndefinedProject.Format(ws.Project));
            return outcome;
        }

        protected Outcome LoadProjectSources(IProjectWs ws, Subject? scope)
        {
            Files(ProjectFiles(ws,scope));
            return true;
        }

        static MsgPattern<ProjectId> UndefinedProject
            => "Undefined project:{0}";

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
    }
}