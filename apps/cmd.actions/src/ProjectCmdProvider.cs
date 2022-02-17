//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;
    using llvm;

    using static core;

    public partial class ProjectCmdProvider : AppCmdProvider<ProjectCmdProvider>
    {
        ProjectId DefaultProject;

        public ProjectCmdProvider()
        {
            _Files = FS.Files.Empty;
            DefaultProject = "mc.models";
        }

        protected override void OnInit()
        {
            Project(Ws.Project(DefaultProject));
        }

        XedDisasmSvc XedDisasm => Service(Wf.XedDisasm);

        IntelXed Xed => Service(Wf.IntelXed);

        ProjectManager Projects => Service(Wf.ProjectManager);

        WsProjects WsProjects => Service(Wf.WsProjects);

        LlvmLlcSvc Llc => Service(Wf.LlvmLLc);

        LlvmMcSvc LlvmMc => Service(Wf.LlvmMc);

        DumpBin DumpBin => Service(Wf.DumpBin);

        ClangSvc Clang => Service(Wf.Clang);

        LlvmObjDumpSvc ObjDump => Service(Wf.LlvmObjDump);

        CoffServices CoffServices => Service(Wf.CoffServices);

        IntelSdm Sdm => Service(Wf.IntelSdm);

        CgSvc CodeGen => Service(Wf.CodeGen);

        CodeBanks CodeBanks => Service(Wf.CodeBanks);

        FS.Files _Files;

        FS.Files Files()
            => _Files;

        FS.Files Files(FS.Files src, bool write =true)
        {
            _Files = src;
            if(write)
                iter(src, path => Write(path.ToUri()));
            return Files();
        }

        IProjectWs _Project;

        new IProjectWs Project()
            => _Project;

        IProjectWs Project(IProjectWs project)
        {
            _Project = project;
            LoadProjectSources();
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
    }
}