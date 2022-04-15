//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedDisasm;

    partial class XedCmdProvider
    {
        [CmdOp("xed/check/disasm")]
        Outcome CheckDisasm(CmdArgs args)
        {
            var docs = XedDisasm.docs(Context()).Sort();

            iter(docs,CollectFields,true);

            return true;
        }

        void CollectFields(DisasmDetailDoc doc)
        {
            using var machine = XedMachine.allocate(Wf);
            var dst = FieldBuffer.init();
            ref readonly var blocks = ref doc.Blocks;
            for(var i=0; i<blocks.Count; i++)
                machine.Step(dst.Load(blocks[i]));

            ref readonly var file = ref doc.File;
            ref readonly var source = ref file.Source;
            ref readonly var path = ref source.Path;
            ref readonly var docid = ref source.DocId;
            var count = file.LineCount;
            Write(string.Format("{0,-8} | {1,-8} | {2,-8} | {3}", doc.Seq, docid, file.LineCount, path.ToUri()));
        }
    }
}