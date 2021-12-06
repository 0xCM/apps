//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class GlobalCommands
    {
        [CmdOp("xed/emit/isa")]
        Outcome XedIsa(CmdArgs args)
            => Xed.EmitIsa(arg(args,0).Value);
    }
}