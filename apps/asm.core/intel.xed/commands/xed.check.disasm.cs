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
        [CmdOp("xed/check/disasm")]
        Outcome CheckDisasm(CmdArgs args)
        {
            var docs = XedDisasm.docs(Context()).Sort();

            iter(docs, CollectFields2, true);

            return true;
        }

        MachineHost MachineHost => Service(Wf.XedMachinHost);

        void CollectFields2(DisasmDetailDoc doc)
        {
            var status = cdict<string,string>();
            var name = doc.File.Source.Path.FileName.WithoutExtension.Format();

            MachineHost.Run(true, machine =>
            {
                var fields = FieldBuffer.init();
                ref readonly var blocks = ref doc.Blocks;
                for(var i=0; i<blocks.Count; i++)
                {
                    ref readonly var block = ref blocks[i];
                    fields.Load(block);

                    var input = fields.AsmInfo;
                    machine.Load(fields);
                    var output = machine.AsmInfo;
                    if(input != output)
                    {
                        Error("State mismatch");
                        break;
                    }
                }

                status[name] = string.Format("{0,-8} | {1,-46} | {2,-8} | {3,-8} | {4,-8}",
                    machine.Id, name, doc.Seq, doc.File.Source.DocId, doc.File.LineCount);
            });

            var names = status.Keys.Sort();
            iter(names, name =>  Write(status[name]));
            MachineHost.Reset();
        }

        void CollectFields(DisasmDetailDoc doc)
        {
            var status = cdict<string,string>();
            var name = doc.File.Source.Path.FileName.WithoutExtension.Format();
            MachineHost.Run(true, machine =>
            {
                var fields = FieldBuffer.init();
                ref readonly var blocks = ref doc.Blocks;
                for(var i=0; i<blocks.Count; i++)
                {
                    ref readonly var block = ref blocks[i];
                    fields.Load(block);
                    machine.Load(fields);
                    machine.Capture.FormPatterns();
                }

                machine.Emitter.EmitFormPatterns(name);

                status[name] = string.Format("{0,-8} | {1,-46} | {2,-8} | {3,-8} | {4,-8}",
                    machine.Id, name, doc.Seq, doc.File.Source.DocId, doc.File.LineCount);
            });

            var names = status.Keys.Sort();
            iter(names, name =>  Write(status[name]));
            MachineHost.Reset();
        }
    }
}