//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using llvm;
    using static llvm.LlvmSubtarget;

    public partial class ProjectSvc : AppCmdService<ProjectSvc>
    {
        WsScripts Scripts => Wf.WsScripts();

        AsmObjects AsmObjects => Wf.AsmObjects();

        XedDisasmSvc XedDisasm => Wf.XedDisasmSvc();

        CoffServices Coff => Wf.CoffServices();

        public FS.Files SynAsmSources(IWsProject src)
            => src.OutFiles(FileKind.SynAsm.Ext());

        public FS.Files McAsmSources(IWsProject src)
            => src.OutFiles(FileKind.McAsm.Ext());

        public FS.FilePath AsmSyntaxTable(ProjectId project)
            => Flows.table<AsmSyntaxRow>(project);

        public FS.FilePath AsmInstructionTable(ProjectId project)
            => Flows.table<AsmInstructionRow>(project);

        public Outcome<Index<CmdFlow>> BuildLlc(IWsProject project, LlvmSubtarget subtarget, bool runexe = false)
        {
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
            return Scripts.RunBuildScripts(project, FileKind.Llir, project.Script(scriptid), runexe);
        }
   }
}