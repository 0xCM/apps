//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using llvm;
    using static llvm.SubtargetKind;

    public partial class ProjectDataServices : AppService<ProjectDataServices>
    {
        AppSvcOps AppSvc => Wf.AppSvc();

        XedDisasmSvc XedDisasm => AsmRt.XedDisasm;

        WsProjects Projects => Service(Wf.WsProjects);

        AsmObjects AsmObjects => Service(Wf.AsmObjects);

        OmniScript OmniScript => Wf.OmniScript();

        AsmCmdRt AsmRt;

        public ProjectDataServices With(AsmCmdRt rt)
        {
            AsmRt = rt;
            return this;
        }

        public void Collect(IProjectWs project)
        {
            var context = WsContext.create(project);
            AsmObjects.CollectObjects(context);
            AsmObjects.CollectObjSyms(context);
            AsmObjects.CollectCoffData(context);
            CollectAsmSyntax(context);
            CollectMcInstructions(context);
            XedDisasm.Collect(context);
        }

        public Outcome<Index<ToolCmdFlow>> BuildAsm(IProjectWs project)
            => RunBuildScripts(project, "build", "asm", false);

        public Outcome<Index<ToolCmdFlow>> BuildLlc(IProjectWs project, SubtargetKind subtarget, bool runexe = false)
        {
            var result = Outcome.Success;
            var scriptid = subtarget switch
            {
                Sse => "llc-build-sse",
                Sse2 => "llc-build-sse2",
                Sse3 => "llc-build-sse3",
                Sse41 => "llc-build-sse41",
                Sse42 => "llc-build-sse42",
                Avx => "llc-build-avx",
                Avx2 => "llc-build-avx2",
                Avx512 => "llc-build-avx512",
                _ => EmptyString
            };

            return RunBuildScripts(project, scriptid, EmptyString,runexe);
        }

        public Outcome<Index<ToolCmdFlow>> BuildScoped(IProjectWs project, ScriptId script, string scope)
            => RunBuildScripts(project, script, scope, false);

        public Outcome<Index<ToolCmdFlow>> BuildC(IProjectWs project, bool runexe = false)
            => RunBuildScripts(project, "c-build", "c", runexe);

        public Outcome<Index<ToolCmdFlow>> BuildCpp(IProjectWs project, bool runexe = false)
            => RunBuildScripts(project, "cpp-build", "cpp", runexe);

        public Outcome<Index<ToolCmdFlow>> RunBuildScripts(IProjectWs project, ScriptId scriptid, Subject? scope, bool runexe)
            => Projects.RunBuildScripts(project, scriptid, scope, flow => HandleBuildResponse(flow, runexe));

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

        public void HandleBuildResponse(ToolCmdFlow flow, bool runexe)
        {
            if(flow.TargetPath.FileName.Is(FS.Exe) && runexe)
                RunExe(flow);
        }

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