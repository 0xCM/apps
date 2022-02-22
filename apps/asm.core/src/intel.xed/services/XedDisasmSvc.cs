//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;
    using static XedModels;
    using static XedRecords;

    public partial class XedDisasmSvc : AppService<XedDisasmSvc>
    {
        Symbols<IFormType> Forms;

        Symbols<IClass> Classes;

        XedRules Rules => Service(Wf.XedRules);

        XedPaths XedPaths => Service(Wf.XedPaths);

        WsProjects Projects => Service(Wf.WsProjects);

        ConstLookup<OperandWidthType,OperandWidth> OperandWidths;

        CollectionEventReceiver EventReceiver;

        public XedDisasmSvc()
        {
            Forms = Symbols.index<IFormType>();
            Classes = Symbols.index<IClass>();
            EventReceiver = new();
        }

        protected override void OnInit()
        {
            var dst = dict<OperandWidthType, OperandWidth>();
            iter(Rules.LoadOperandWidths(), w => dst.TryAdd(w.Code, w));
            OperandWidths = dst;
        }

        OperandWidth OperandWidth(OperandWidthType type)
            => OperandWidths[type];

        void EmitDisasmSummary(AsmEncodingDocs sources, FS.FilePath dst)
        {
            var paths = sources.Keys.ToArray().Sort();
            var recordcount = 0u;
            iter(sources.Values, src => recordcount += src.RowCount);
            var buffer = alloc<AsmEncodingRow>(recordcount);
            var counter = 0u;
            for(var i=0; i<paths.Length;i++)
            {
                sources.Find(skip(paths,i), out var encodings);
                var encoded = encodings.View;
                for(var j=0; j<encoded.Length; j++)
                {
                    ref var target = ref seek(buffer, counter++);
                    target = skip(encoded,j);
                    target.Seq = counter;
                }
            }
            TableEmit(@readonly(buffer), AsmEncodingRow.RenderWidths, dst);
        }

        public void Collect(CollectionContext collect)
        {
            var result = Outcome.Success;
            var project = collect.Project;
            EmitDisasmSummary(CollectEncodingDocs(collect), Projects.XedDisasmSummary(project));
            CollectDisasmDetails(collect);
        }

        /// <summary>
        /// Transforms the source document into a sequence of blocks, each of which describe a single decoded instruction
        /// </summary>
        /// <param name="src">And xed-emitted disassemly file</param>
        public Index<DisasmLineBlock> ParseBlocks(FS.FilePath src)
            => XedDisasmOps.LoadLineBlocks(src);
    }
}