//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedDisasm;
    using static XedMachine;
    using static XedModels;

    partial class XedCmdProvider
    {

        [CmdOp("xed/check/forms")]
        Outcome CheckForms(CmdArgs args)
        {
            var parts = FormSyntax.parts();
            iteri(parts, (i,part) => Write(string.Format("{0,-3} | {1}", i, part.Format())));

            return true;
        }

        [CmdOp("xed/check/disasm")]
        Outcome EmitBreakdowns(CmdArgs args)
        {
            var context = Context();
            var sources = XedDisasm.sources(context);
            var patterns = Xed.Rules.CalcInstPatterns();
            iter(sources, src => Drill(context,src),true);
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
            }
        }
    }
}