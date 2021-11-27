//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;

    partial class AsmCmdService
    {
        [CmdOp(".respack-emit")]
        Outcome EmitRespPack(CmdArgs args)
        {
            var blocks = Wf.ApiHex().ReadBlocks();
            var dst = Ws.Project("gen").Subdir("respack");
            var hostres = Wf.ResPackEmitter().Emit(blocks.View, dst);
            return true;
        }
    }
}