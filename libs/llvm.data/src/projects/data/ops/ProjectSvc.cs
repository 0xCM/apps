//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public partial class ProjectSvc : AppService<ProjectSvc>
    {
        AppSvcOps AppSvc => Wf.AppSvc();

        WsProjects Projects => Wf.WsProjects();

        AsmObjects AsmObjects => Wf.AsmObjects();

        OmniScript OmniScript => Wf.OmniScript();

        XedDisasmSvc XedDisasm => Wf.XedDisasmSvc();

        CoffServices Coff => Wf.CoffServices();

        public Outcome<Index<ToolCmdFlow>> BuildAsm(IProjectWs project)
            => RunBuildScripts(project, "build", "asm", false);

        public Outcome<Index<ToolCmdFlow>> BuildScoped(IProjectWs project, ScriptId script, string scope)
            => RunBuildScripts(project, script, scope, false);

        public Outcome<Index<ToolCmdFlow>> BuildC(IProjectWs project, bool runexe = false)
            => RunBuildScripts(project, "c-build", "c", runexe);

        public Outcome<Index<ToolCmdFlow>> BuildCpp(IProjectWs project, bool runexe = false)
            => RunBuildScripts(project, "cpp-build", "cpp", runexe);

        public FS.Files SynAsmSources(IProjectWs project)
            => project.OutFiles(FileKind.SynAsm.Ext());

        public FS.Files McAsmSources(IProjectWs project)
            => project.OutFiles(FileKind.McAsm.Ext());

        public FS.FilePath AsmSyntaxTable(IProjectWs project)
            => Projects.Table<AsmSyntaxRow>(project);

        public FS.FilePath AsmInstructionTable(IProjectWs project)
            => Projects.Table<AsmInstructionRow>(project);
   }
}