//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedDisasm;
    using static XedMachine;
    partial class XedCmdProvider
    {
        MachineHost MachineHost => Service(Wf.XedMachinHost);

        [CmdOp("xed/check/disasm")]
        Outcome EmitBreakdowns(CmdArgs args)
        {
            var context = Context();
            var sources = XedDisasm.sources(context);
            var patterns = Xed.Rules.CalcInstPatterns();
            iter(sources, src => Drill(context,src),true);
            // var docs = Disasm.CalcDocs(context);
            // Disasm.EmitBreakdowns(context,docs);

            return true;
        }


        void Drill(WsContext context, in FileRef src)
        {
            var fields = XedDisasm.fields();
            using var machine = XedMachine.allocate(this);
            var data = XedDisasm.datafile(context, src);
            var summary = XedDisasm.summary(context, data);
            var detail = XedDisasm.detail(context, summary);
            ref readonly var blocks = ref detail.Blocks;
            for(var i=0; i<blocks.Count; i++)
            {
                ref readonly var block = ref blocks[i];
                XedDisasm.fields(block, ref fields);
                machine.Load(fields);
                ref readonly var inst = ref block.Instruction;
                ref readonly var id = ref block.InstId;
                ref readonly var ops = ref block.Ops;

                for(var j=0; j<ops.Count; j++)
                {
                    ref readonly var op = ref ops[j];
                }
            }
            // var buffer = text.buffer();
            // var _data = dst.Array().Sort();
            // iter(_data, d => buffer.AppendLine(d.Format()));
            // var target = context.Project.Datasets() + FS.folder("xed.disasm") + FS.file(string.Format(src.Path.FileName.WithoutExtension.Format() + ".formpatterns"),FS.Csv);
            // FileEmit(buffer.Emit(), _data.Length, target);

        }
        void CollectFields(Detail doc)
        {
            var status = cdict<string,string>();
            var name = doc.DataFile.Source.Path.FileName.WithoutExtension.Format();
            MachineHost.Run(true, machine =>
            {
                var dst = XedDisasm.fields();
                ref readonly var blocks = ref doc.Blocks;
                for(var i=0; i<blocks.Count; i++)
                {
                    ref readonly var block = ref blocks[i];

                    XedDisasm.fields(block, ref dst);

                    machine.Load(dst);
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