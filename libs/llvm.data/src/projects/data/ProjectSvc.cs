//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using llvm;

    using static core;
    using static llvm.SubtargetKind;

    public partial class ProjectSvc : AppService<ProjectSvc>
    {
        AppSvcOps AppSvc => Wf.AppSvc();

        WsProjects Projects => Service(Wf.WsProjects);

        AsmObjects AsmObjects => Service(Wf.AsmObjects);

        OmniScript OmniScript => Wf.OmniScript();

        XedDisasmSvc XedDisasm => Wf.XedDisasmSvc();

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

            return RunBuildScripts(project, scriptid, EmptyString, runexe);
        }

        public Index<AsmSyntaxOps> CalcSyntaxOps(IProjectWs project)
        {
            var rows = LoadAsmSyntax(project);
            var count = rows.Count;
            var opLists = CalcAsmSyntaxOps(rows);
            var dst = alloc<AsmSyntaxOps>(count);
            Require.equal(count, opLists.Count);
            for(var i=0; i<count; i++)
                seek(dst,i) = new AsmSyntaxOps(rows[i],opLists[i]);
            return dst;
        }

        public void Collect(IProjectWs project)
        {
            var context = WsApi.context(project);
            AsmObjects.CollectObjects(context);
            AsmObjects.CollectObjSyms(context);
            AsmObjects.CollectCoffData(context);
            CollectAsmSyntax(context);
            CollectMcInstructions(context);
            XedDisasm.Collect(context);
        }

        CoffServices Coff => Wf.CoffServices();

        public void GenProjectObjects(IProjectWs project)
        {
            var context = WsApi.context(project);
            var catalog = context.Catalog;
            var files = catalog.Entries(FileKind.Obj, FileKind.O);
            var count = files.Count;
            var emitter = text.emitter();
            var offset = 0u;
            emitter.IndentLine(offset, "namespace Z0");
            emitter.IndentLine(offset, Chars.LBrace);
            offset += 4;
            emitter.IndentLineFormat(offset, "public readonly struct {0}", project.Name);
            emitter.IndentLine(offset, Chars.LBrace);
            offset += 4;
            for(var i=0; i<count; i++)
            {
                ref readonly var file = ref files[i];
                var code = dict<MemoryRange,BinaryCode>();
                var obj = Coff.LoadObj(file);
                var sections = Coff.CalcObjSections(context, file);
                for(var j=0; j<sections.Count; j++)
                {
                    ref readonly var section = ref sections[j];
                    if(section.SectionKind == CoffSectionKind.Text)
                    {
                        var range = new MemoryRange(section.RawDataAddress, section.RawDataSize);
                        code[range] = obj.Data;
                        var data = obj.Bytes(range);
                        var identifier = file.Path.FileName.WithoutExtension.Format().Replace(Chars.Dot, Chars.Underscore).Replace(Chars.Dash,Chars.Underscore);
                        var hex = data.FormatHex(Chars.Comma,true);
                        var gen = string.Format("public static ReadOnlySpan<byte> {0} = new byte[{1}]", identifier, (uint)section.RawDataSize);
                        var statement = gen + "{" + hex + "};";
                        emitter.IndentLine(offset, statement);
                        emitter.AppendLine();
                    }
                }
            }

            offset -= 4;
            emitter.IndentLine(offset, Chars.RBrace);

            offset -= 4;
            emitter.IndentLine(offset, Chars.RBrace);

            FileEmit(emitter.Emit(), count, ProjectDb.Logs() + FS.file(project.Name.Format(), FS.Cs));
        }

        public Outcome<Index<ToolCmdFlow>> BuildAsm(IProjectWs project)
            => RunBuildScripts(project, "build", "asm", false);

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