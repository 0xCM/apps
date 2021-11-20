//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial class AsmCmdService
    {
        [CmdOp(".emit-xed-isa")]
        Outcome XedIsa(CmdArgs args)
            => Xed.EmitIsa(arg(args,0).Value);

        [CmdOp(".emit-xed-catalog")]
        Outcome XedEmit(CmdArgs args)
        {
            var result = Outcome.Success;
            Xed.EmitCatalog();
            return result;
        }
    }
}