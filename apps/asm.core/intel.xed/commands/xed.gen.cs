//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedDisasm;
    using static XedMachine;
    using static XedRules;

    partial class XedCmdProvider
    {
        Index<DisasmSummaryDoc> CalcSummaries(WsContext context, bool pll = true)
        {
            var sources = XedDisasm.sources(context);
            var outdir = context.Project.Datasets() + FS.folder("xed.disasm");
            var dst = bag<DisasmSummaryDoc>();
            iter(sources, source => dst.Add(XedDisasm.summary(context,source)), pll);
            return dst.Array();
        }

        void EmitSummaries(WsContext context, Index<DisasmSummaryDoc> src, bool pll = true)
        {
            var outdir = context.Project.Datasets() + FS.folder("xed.disasm");
            iter(src, doc =>{
                ref readonly var origin = ref doc.Origin;
                var target = outdir + origin.Path.FileName.WithoutExtension + FS.ext("xed.disasm.summary.csv");
                TableEmit(doc.Rows.View, DisasmSummaryRow.RenderWidths, TextEncodingKind.Asci, target);
            },pll);
        }

        void EmitDetails(WsContext context, in FileRef origin, Index<DetailBlock> src)
        {
            var outdir = context.Project.Datasets() + FS.folder("xed.disasm");
            var target = outdir + origin.Path.FileName.WithoutExtension + FS.ext("xed.disasm.details.csv");
            var rows = src.Select(x => x.DetailRow);
            TableEmit(rows.View, DisasmSummaryRow.RenderWidths, TextEncodingKind.Asci, target);
        }

        ConstLookup<DisasmSummaryDoc,Index<DetailBlock>> CalcDetailBlocks(Index<DisasmSummaryDoc> src, bool pll = true)
        {
            var dst = cdict<DisasmSummaryDoc,Index<DetailBlock>>();
            iter(src, doc => dst.TryAdd(doc, XedDisasm.blocks(doc)), pll);
            return dst;
        }

        void EmitDetails(WsContext context, ConstLookup<DisasmSummaryDoc,Index<DetailBlock>> src, bool pll = true)
        {
            var outdir = context.Project.Datasets() + FS.folder("xed.disasm");
            iter(src.Keys, doc =>{
                ref readonly var origin = ref doc.Origin;
                var blocks = src[doc];
                var target = outdir + origin.Path.FileName.WithoutExtension + FS.ext("xed.disasm.details.csv");
                var buffer = text.buffer();
                XedDisasm.render(blocks, buffer);
                var emitting = EmittingFile(target);
                using var emitter = target.AsciEmitter();
                emitter.Write(buffer.Emit());
                EmittedFile(emitting, blocks.Count);
            },pll);
        }

        [CmdOp("xed/gen")]
        Outcome XedGen(CmdArgs args)
        {
            var context = Context();
            var summaries = CalcSummaries(context);
            var details = CalcDetailBlocks(summaries);
            EmitSummaries(context, summaries);
            EmitDetails(context, details);
            // var docs = details.Keys;
            // for(var i=0; i<docs.Length; i++)
            // {
            //     ref readonly var doc = ref skip(docs,i);
            //     var blocks = details[doc];
            //     Write(string.Format("{0,-8} | {1,-8} | {2}", i, blocks.Count, doc.Origin));
            // }

            // ref readonly var fields = ref XedFields.ByPosition;
            // var bits = fields[0,51];
            // var dst = BitVector64.Zero;
            // var set = FieldSet.create();
            // for(var i=z8; i<bits.Length; i++)
            // {
            //     ref readonly var field = ref skip(bits,i);
            //     Write(string.Format("{0,-8} | {1,-24} | {2}", field.Pos, field.Field, field.FieldSize));

            // }


            return true;
        }

    }
}