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

        XedPaths XedPaths => Service(Wf.XedPaths);

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
            var dst = XedPaths.DisasmCode(project);
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
            var src = XedPaths.DisasmSources(project);
            var records = ParseEncodings(src);
            var count = src.Length;
            TableEmit(records.View, AsmStatementEncoding.RenderWidths, XedPaths.DisasmTable(project));
            CollectAsmCode(project, records);
            EmitDisasmDetails(project);
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