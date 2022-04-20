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
        MachineHost MachineHost => Service(Wf.XedMachinHost);

        [CmdOp("xed/emit/breakdowns")]
        Outcome EmitBreakdowns(CmdArgs args)
        {
            var context = Context();
            var docs = Disasm.CalcDocs(context);
            Disasm.EmitBreakdowns(context,docs);

            return true;
        }

        void CollectFields(Detail doc)
        {
            var status = cdict<string,string>();
            var name = doc.DataFile.Source.Path.FileName.WithoutExtension.Format();
            MachineHost.Run(true, machine =>
            {
                var fields = FieldBuffer.init();
                ref readonly var blocks = ref doc.Blocks;
                for(var i=0; i<blocks.Count; i++)
                {
                    ref readonly var block = ref blocks[i];

                    XedDisasm.fields(block, ref fields);

                    machine.Load(fields);
                    machine.Capture.FormPatterns();
                }

                machine.Emitter.EmitFormPatterns(name);

                status[name] = string.Format("{0,-8} | {1,-46} | {2,-8} | {3,-8} | {4,-8}",
                    machine.Id, name, doc.Seq, doc.DataFile.Source.DocId, doc.DataFile.LineCount);
            });

            var names = status.Keys.Sort();
            iter(names, name =>  Write(status[name]));
            MachineHost.Reset();
        }
    }
}