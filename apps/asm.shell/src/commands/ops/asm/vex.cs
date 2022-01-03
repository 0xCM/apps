//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{

    using static core;

    using static AsmPrefixCodes;

    partial class AsmCmdService
    {
        [CmdOp(".vex")]
        Outcome Vex(CmdArgs args)
        {
            var vp0 = VexPrefixC4.init(byte.MaxValue, byte.MaxValue);
            Write(vp0.FormatSemantic());

            var vp1 = VexPrefixC4.init(VexRXB.L0_V0F38, VexM.V0F3A, bit.On, 0b1111, VexLengthCode.L1, VexOpCodeExtension.F3);
            Write(vp1.FormatSemantic());

            var vp2 = VexPrefixC4.init(0xe3, 0x69);
            Write(vp2.FormatSemantic());

            return true;
        }
    }
}
