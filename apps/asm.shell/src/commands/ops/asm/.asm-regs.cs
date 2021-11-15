//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static AsmOperands;

    partial class AsmCmdService
    {
        [CmdOp(".asm-regs")]
        Outcome ShowAsmRegs(CmdArgs args)
        {
            var result = Outcome.Success;
            xmm r = AsmRegOps.xmm0;
            for(var i=0; i<32; i++)
            {
                Write(r++);
            }

            return result;
        }
    }
}