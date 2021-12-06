//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    partial class AsmCmdService
    {
        [CmdOp(".emit-xed-isa")]
        Outcome XedIsa(CmdArgs args)
            => Xed.EmitIsa(arg(args,0).Value);

    }
}