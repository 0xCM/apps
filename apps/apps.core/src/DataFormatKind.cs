//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Flags]
    public enum DataFormatKind : uint
    {
        Default = 0,

        Bit = 1,

        Decimal = 2,

        Hex = 4,

        Seq = 8,

        Char = 16,

        Asci = 32,

        Utf8 = 64,

        Unicode = 128,

        Signed = 256,

        Enum = 512,

        Identifier = 1024,

        Symbol = 2056,

        AsciChar = Asci | Char,

        AsciText = Asci | Char | Seq,

        Utf8Char = Utf8 | Char,

        Utf8Text = Utf8 | Char | Seq,

        UnicodeChar = Unicode | Char,

        UnicodeText = Unicode | Char | Seq,

        SignedDecimal = Signed | Decimal,

        SignedHex = Signed | Hex,

        BitSeq = Bit | Seq,

        DecimalSeq = Decimal | Seq,

        HexSeq = Hex | Seq,

        SignedDecimalSeq = Signed | Decimal | Seq,

        SignedHexSeq = Signed | Hex | Seq,

        EnumIdentifier = Enum | Identifier,

        EnumSymbol = Enum | Symbol,

        EnumValue = Enum | Decimal,

        EnumBitValue = Enum | Bit,

        EnumHexValue = Enum | Hex
    }
}