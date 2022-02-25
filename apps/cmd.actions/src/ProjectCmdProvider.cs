//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;
    using llvm;

    using static core;

    public partial class ProjectCmdProvider : AppCmdProvider<ProjectCmdProvider>, IProjectProvider
    {
        AppDb AppDb => Service(Wf.AppDb);

        public ProjectCmdProvider()
        {

        }

        XedDisasmSvc XedDisasm => Service(Wf.XedDisasm);

        ProjectDataServices ProjectData => Service(Wf.ProjectData);

        WsProjects Projects => Service(Wf.WsProjects);

        LlvmMcSvc LlvmMc => Service(Wf.LlvmMc);

        LlvmObjDumpSvc LlvmObjDump => Service(Wf.LlvmObjDump);

        DumpBin DumpBin => Service(Wf.DumpBin);

        CoffServices CoffServices => Service(Wf.CoffServices);

        IntelSdm Sdm => Service(Wf.IntelSdm);

        IntelIntrinsicSvc IntelIntrinsics => Service(Wf.IntelIntrinsics);

        AsmFlowCommands AsmFlowCommands => Service(Wf.AsmFlowCommands);

        ICmdRunner Commands;

        public ProjectCmdProvider With(ICmdRunner runner)
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

        [CmdOp("project/sources")]
        protected Outcome ProjectSrcFiles(CmdArgs args)
        {
            if(args.Length == 0)
                Files(Project().SrcFiles());
            else
                Files(Project().SrcFiles(arg(args,0)));
            return true;
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