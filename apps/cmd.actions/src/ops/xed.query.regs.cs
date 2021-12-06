//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class GlobalCommands
    {
        [CmdOp("xed/query/regs")]
        Outcome XedRegs(CmdArgs args)
            => ShowSyms(Xed.Registers());
    }
}