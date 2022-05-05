//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedDisasm;
    using static XedOperands;
    using static XedRules;

    partial class XedCmdProvider
    {
        [CmdOp("xed/disasm/flow")]
        Outcome RunDisasmFlow(CmdArgs args)
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