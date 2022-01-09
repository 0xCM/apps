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

        public void Collect(IProjectWs project)
        {
            var result = Outcome.Success;
            var src = XedPaths.DisasmSources(project);
            var sources = ParseDisasmSources(project);
            var paths = sources.Keys.ToArray().Sort();
            var recordcount = 0u;
            iter(sources.Values, src => recordcount += src.Encoded.Count);
            var buffer = alloc<AsmDocEncoding>(recordcount);
            var count = paths.Length;
            var counter = 0u;
            for(var i=0; i<count;i++)
            {
                sources.Find(skip(paths,i), out var encodings);
                var encoded = encodings.Encoded;
                for(var j=0; j<encoded.Count; j++)
                {
                    seek(buffer,counter++) = encoded[j];
                    seek(buffer,counter).Seq = counter;
                }
            }
            TableEmit(@readonly(buffer), AsmDocEncoding.RenderWidths, XedPaths.DisasmSummary(project));
            EmitDisasmDetails(project);
        }

        /// <summary>
        /// Transforms the source document into a sequence of blocks, each of which describe a single decoded instruction
        /// </summary>
        /// <param name="src">And xed-emitted disassemly file</param>
        public Index<DisasmLineBlock> ParseBlocks(FS.FilePath src)
            => XedDisasmOps.LoadBlocks(src);
    }
}