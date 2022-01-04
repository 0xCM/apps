//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using Asm;

    using static Root;
    using static core;
    using static XedModels;

    public partial class XedDisasmSvc : AppService<XedDisasmSvc>
    {
        Symbols<IFormType> Forms;

        Symbols<IClass> Classes;

        XedRules Rules => Service(Wf.XedRules);

        ConstLookup<OperandWidthType,OperandWidth> OperandWidths;

        public XedDisasmSvc()
        {
            Forms = Symbols.index<IFormType>();
            Classes = Symbols.index<IClass>();
        }

        protected override void OnInit()
        {
            var dst = dict<OperandWidthType, OperandWidth>();
            iter(Rules.LoadOperandWidths(), w => dst.TryAdd(w.Code, w));
            OperandWidths = dst;
        }

        OperandWidth OperandWidth(OperandWidthType type)
            => OperandWidths[type];

        public FS.Files DisasmSources(IProjectWs project)
            => project.OutFiles(FS.ext("xed.txt"));

        public FS.FilePath DisasmTable(IProjectWs project)
            => ProjectDb.ProjectData() + FS.file(string.Format("xed.disasm.{0}", project.Project), FS.Csv);

        public FS.FilePath DisasmCode(IProjectWs project)
            => ProjectDb.ProjectData() + FS.file(string.Format("xed.disasm.{0}", project.Name), FS.Asm);

        public FS.FolderPath DisasmDetailDir(IProjectWs project)
            => ProjectDb.ProjectData() + FS.folder(string.Format("{0}.{1}", project.Name, "xed.disasm.detail"));

        public FS.FilePath DisasmDetailTarget(IProjectWs project, FS.FileName file)
            => DisasmDetailDir(project) + FS.file(string.Format("{0}.details",file), FS.Txt);

        public Outcome ParseInstructions(ReadOnlySpan<DisasmLineBlock> src, out Index<DisasmInstruction> dst)
        {
            var count = src.Length;
            var result = Outcome.Success;
            dst = alloc<DisasmInstruction>(count);
            for(var i=0; i<count; i++)
            {
                result = ParseInstruction(skip(src,i), out dst[i]);
                if(result.Fail)
                    break;
            }
            return result;
        }

        void CollectAsmCode(IProjectWs project, ReadOnlySpan<AsmStatementEncoding> src)
        {
            using var unique = AsmCodeAllocation.create(src);
            var count = unique.Count;
            var dst = DisasmCode(project);
            var emitting = EmittingFile(dst);
            using var writer = dst.AsciWriter();
            for(var i=0; i<count; i++)
            {
                ref readonly var code = ref unique[i];
                var line = string.Format("{0,-80} ; {1}", code.Asm, code.Code);
                writer.WriteLine(line);
            }
            EmittedFile(emitting,count);
        }

        public Index<AsmStatementEncoding> Collect(IProjectWs project)
        {
            var result = Outcome.Success;
            var src = DisasmSources(project);
            var records = ParseEncodings(src);
            var count = src.Length;
            TableEmit(records.View, AsmStatementEncoding.RenderWidths, DisasmTable(project));
            CollectAsmCode(project, records);
            return records;
        }

        /// <summary>
        /// Transforms the source document into a sequence of blocks, each of which describe a single decoded instruction
        /// </summary>
        /// <param name="src">And xed-emitted disassemly file</param>
        public Index<DisasmLineBlock> ParseBlocks(FS.FilePath src)
            => XedDisasmOps.LoadBlocks(src);
    }
}