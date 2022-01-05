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
        public ProjectCmdProvider()
        {
            _Files = FS.Files.Empty;
        }

        [CmdOp("project")]
        Outcome LoadProject(CmdArgs args)
        {
            var result = Outcome.Success;
            Project(Ws.Project(arg(args,0).Value));
            return result;
        }

        XedDisasmSvc XedDisasm => Service(Wf.XedDisasm);

        IntelXed Xed => Service(Wf.IntelXed);

        ProjectCollector ProjectCollector => Service(Wf.ProjectCollector);

        LlvmLlcSvc Llc => Service(Wf.LlvmLLc);

        LlvmMcSvc LlvmMc => Service(Wf.LlvmMc);

        DumpBin DumpBin => Service(Wf.DumpBin);

        FS.Files _Files;

        FS.Files Files()
            => _Files;

        FS.Files Files(FS.FileExt ext)
            => Files().Where(f => f.Ext == ext);

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
            Write(string.Format("Loading sources for {0}", project.Name));
            if(project == null)
                return (false, "Project unspecified");

            var outcome = Outcome.Success;
            var dir = project.Home();
            outcome = dir.Exists;
            if(outcome)
                Files(project.SrcFiles());
            else
                outcome = (false, UndefinedProject.Format(project.Project));
            return outcome;
        }

        static MsgPattern<ProjectId> UndefinedProject
            => "Undefined project:{0}";
    }
}
