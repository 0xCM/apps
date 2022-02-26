//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;
    using static XedModels;

    public partial class XedDisasmSvc : AppService<XedDisasmSvc>
    {
        Symbols<IFormType> Forms;

        Symbols<IClass> Classes;

        XedRules Rules => Service(Wf.XedRules);

        XedPaths XedPaths => Service(Wf.XedPaths);

        WsProjects Projects => Service(Wf.WsProjects);

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

        public Index<XedDisasmSummary> EmitDisasmSummary(AsmEncodingDocs sources, FS.FilePath dst)
        {
            var paths = sources.Keys.ToArray().Sort();
            var recordcount = 0u;
            iter(sources.Values, src => recordcount += src.RowCount);
            var buffer = alloc<XedDisasmSummary>(recordcount);
            var counter = 0u;
            for(var i=0; i<paths.Length;i++)
            {
                sources.Find(skip(paths,i), out var encodings);
                var encoded = encodings.View;
                for(var j=0; j<encoded.Length; j++)
                {
                    ref var target = ref seek(buffer, counter++);
                    target = skip(encoded,j);
                }
            }
            var result = buffer.Sort();
            for(var i=0u; i<result.Length; i++)
                seek(result,i).Seq = i;

            TableEmit(@readonly(result), XedDisasmSummary.RenderWidths, dst);
            return result;
        }

        public Index<XedDisasmSummary> LoadDisasmSummaries(IProjectWs project)
        {
            const byte FieldCount = XedDisasmSummary.FieldCount;
            var src = Projects.AsmEncodingTable(project);
            var lines = slice(src.ReadNumberedLines().View,1);
            var count = lines.Length;
            var buffer = alloc<XedDisasmSummary>(count);
            var result = Outcome.Success;
            for(var i=0; i<count; i++)
            {
                var cells = text.trim(skip(lines,i).Content.Split(Chars.Pipe));
                if(cells.Length != FieldCount)
                {
                    result = (false, Tables.FieldCountMismatch.Format(cells.Length, FieldCount));
                    break;
                }

                ref var dst = ref seek(buffer,i);

                var j = 0;
                result = DataParser.parse(skip(cells, j++), out dst.Seq);
                result = DataParser.parse(skip(cells, j++), out dst.DocSeq);
                result = DataParser.parse(skip(cells, j++), out dst.OriginId);
                result = DataParser.parse(skip(cells, j++), out dst.OriginName);
                result = AsmParser.encid(skip(cells, j++), out dst.EncodingId);
                result = AsmParser.instid(skip(cells, j++), out dst.InstructionId);
                result = DataParser.parse(skip(cells, j++), out dst.IP);
                result = AsmParser.asmhex(skip(cells, j++), out dst.Encoded);
                result = DataParser.parse(skip(cells, j++), out dst.Size);
                result = AsmParser.expression(skip(cells, j++), out dst.Asm);
                result = DataParser.parse(skip(cells, j++), out dst.Source);
            }
            return buffer;
        }
        /// <summary>
        /// Transforms the source document into a sequence of blocks, each of which describe a single decoded instruction
        /// </summary>
        /// <param name="src">And xed-emitted disassemly file</param>
        public Index<DisasmLineBlock> ParseBlocks(FS.FilePath src)
            => XedDisasmOps.LoadLineBlocks(src);
    }
}