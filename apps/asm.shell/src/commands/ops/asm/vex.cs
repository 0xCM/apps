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
            var segments = VexPrefixC4.segments();

            var vp0 = VexPrefixC4.define(byte.MaxValue, byte.MaxValue);
            Write(vp0.FormatSemantic());
            segments.Fill(vp0);
            Write(segments.ToBitstring());

            var vp1 = VexPrefixC4.init(VexRXB.L0_V0F38, VexM.x0F3A, bit.On, 0b1111, VexLengthCode.L1, VexOpCodeExtension.F3);
            Write(vp1.FormatSemantic());
            segments.Fill(vp1);
            Write(segments.ToBitstring());

            var vp2 = VexPrefixC4.define(0xe3, 0x69);
            Write(vp2.FormatSemantic());
            segments.Fill(vp2);
            Write(segments.ToBitstring());

            return true;
        }
    }
}
