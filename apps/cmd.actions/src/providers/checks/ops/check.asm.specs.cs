//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static Root;
    using static core;
    using Asm;
    using Asm.Operands;

    using gp8 = Asm.AsmRegTokens.Gp8LoReg;
    using gp32 = Asm.AsmRegTokens.Gp32Reg;

    partial class CheckCmdProvider
    {
        // and r32, imm32 | 81 /4 id
        public static AsmSpec and(r32 a, imm32 b)
            => AsmSpecs.define(AsmMnemonicNames.and, AsmOcSpec.Empty, a, b);

        AsmOpCodes OpCodes => Service(Wf.AsmOpCodes);

        [CmdOp("check/asm/specs")]
        public Outcome CheckAsmSpecs(CmdArgs args)
        {
            //AsmOpCodes.define()
            const string Oc0 = "81 /4 id";
            const string Oc1 = "REX.W + 05 id";

            var asm0 = and(gp32.edx, 0xC1C1);
            var result = OpCodes.Parse(Oc0, out var oc0);
            if(result)
                Write(Require.equal(OpCodes.Format(oc0), Oc0));

            result = OpCodes.Parse(Oc1, out var oc1);
            if(result)
                Write(Require.equal(OpCodes.Format(oc1), Oc1));
            return result;
        }
    }
}