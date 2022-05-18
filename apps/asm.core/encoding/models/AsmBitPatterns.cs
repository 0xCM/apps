//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static BitPatterns;

    using P = AsmBitPatterns;

    [LiteralProvider]
    public readonly struct AsmBitPatterns
    {
        [Ignore]
        const string Join = "_";

        [Ignore]
        const string Sep = " ";

        public static readonly BpInfo Sib = pattern<P>(nameof(Sib), "ss iii bbb");

        public static readonly BpInfo ModRm = pattern<P>(nameof(ModRm), "mm rrr nnn");

        public static readonly BpInfo Rex = pattern<P>(nameof(Rex), "WRXB W R X B");

        public static readonly BpInfo VexC4 = pattern<P>(nameof(VexC4), "cccccccc R X B mmmmm W vvvv L pp");

        public static readonly BpInfo VexC5 = pattern<P>(nameof(VexC5), "cccccccc R vvvv L pp");

        [Ignore]
        const string Prefix1 = "qqqqqqqq";

        [Ignore]
        const string OcByte1 = "11111111";

        [Ignore]
        const string OcByte2 = "22222222";

        [Ignore]
        const string OcByte3 = "33333333";

        [Ignore]
        const string OcBytes = OcByte1 + Sep + OcByte2 + Sep + OcByte3;

        [Ignore]
        const string Disp1 = "dddddddd";

        [Ignore]
        const string Disp2 = Disp1 + Join +  Disp1;

        [Ignore]
        const string Disp4 = Disp2 + Join + Disp2;

        [Ignore]
        const string Imm1 = "iiiiiiii";

        [Ignore]
        const string Imm2 = Imm1 + Join + Imm1;

        [Ignore]
        const string Imm4 = Imm2 + Join + Imm2;

        //public const string EncodingLayout = Prefix1 + Sep + OcBytes + Sep + ModRm + Sep + Sib + Sep + Disp4 + Sep + Imm4;
    }
}