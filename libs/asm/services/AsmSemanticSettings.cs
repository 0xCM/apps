//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static RP;

    public readonly struct AsmSemanticDefaults
    {
        public const byte OpKindPad  = 20;

        public const byte SeqDigitPad = 2;

        public const byte InstructionCountPad = 3;

        public const byte OffsetAddrPad = 12;

        public const byte AddressPad = 16;

        public const byte SizePad = 5;

        public const byte InstructionWidth = 80;

        public const string InstructionSep = Dash80;

        public const byte SubColPad = 10;

        public const byte ColSepWidth = 3;

        public const byte Counter = 4;

        public const byte CounterPad = 1;

        public const byte SectionWidth = AddressPad + OffsetAddrPad + InstructionWidth + Counter + SizePad + CounterPad + ColSepWidth;

        public const string ColSep = " | ";

        public const string SpecifierSep = ColSep;

        public const string EncodingSep = ColSep;

        public static string SectionSep
            => new string(Chars.Dash, SectionWidth);
    }
}