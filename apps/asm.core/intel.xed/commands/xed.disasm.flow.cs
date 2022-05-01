//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;
    using static core;
    using static XedRules;
    using static XedDisasm;

    partial class XedCmdProvider
    {
        [CmdOp("xed/disasm/flow")]
        Outcome EmitBreakdowns(CmdArgs args)
        {
            var context = Context();
            var flow = XedDisasm.flow(context);
            var targets = bag<ITarget>();
            var sources = XedDisasm.sources(context);
            iter(XedDisasm.sources(context), src => {
                var dst = XedDisasm.analyzer(this);
                flow.Run(src,dst);
                targets.Add(dst);
            }, true);

            return true;
        }
    }
}