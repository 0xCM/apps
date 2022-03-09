//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public readonly struct DataFormatSpec
    {
        public readonly FormatKind Kind;

        public readonly DataWidth Width;

        public readonly SeqStyleKind SeqStyle;

        public readonly text7 Delimiter;

        [MethodImpl(Inline)]
        public DataFormatSpec(FormatKind kind, DataWidth width = 0, SeqStyleKind style = 0, string delimiter = EmptyString)
        {
            Kind = kind;
            Delimiter = delimiter;
            Width = width;
            SeqStyle = style;
        }

        public string Format(ReadOnlySpan<byte> src)
        {
            var dst = EmptyString;
            switch(Kind)
            {
                case FormatKind.SignedHex:
                    switch(Width)
                    {
                        case DataWidth.W8:
                            dst = FormatSignedHex(src, NativeSizeCode.W8);
                        break;
                        case DataWidth.W16:
                            dst = FormatSignedHex(src, NativeSizeCode.W16);
                        break;
                        case DataWidth.W32:
                            dst = FormatSignedHex(src, NativeSizeCode.W32);
                        break;
                        case DataWidth.W64:
                            dst = FormatSignedHex(src, NativeSizeCode.W64);
                        break;
                    }
                break;
            }
            return dst;
        }

        static string FormatSignedHex(ReadOnlySpan<byte> src, NativeSize size)
        {
            var data = slice(src ,0, size.ByteCount);
            var length = size.ByteCount;
            var dst = EmptyString;
            switch(size.Code)
            {
                case NativeSizeCode.W8:
                {
                    var value = @as<sbyte>(data);
                    if(value < 0)
                        dst = text.format("-{0}",(((byte)((~((byte)value) + 1))).FormatHex(zpad:false, uppercase:true)));
                    else
                        dst = ((byte)value).FormatHex(zpad:false, uppercase:true);
                }
                break;
                case NativeSizeCode.W16:
                {
                    var value = @as<short>(data);
                    if(value < 0)
                        dst = text.format("-{0}", ((ushort)((~((ushort)value) + 1))).FormatHex(zpad:false, uppercase:true));
                    else
                        dst = (((ushort)value).FormatHex(zpad:false, uppercase:true));
                }
                break;
                case NativeSizeCode.W32:
                {
                    var value = @as<int>(data);

                    if(value < 0)
                        dst = text.format("-{0}",((uint)((~((uint)value) + 1))).FormatHex(zpad:false, uppercase:true));
                    else
                        dst = (((uint)value).FormatHex(zpad:false, uppercase:true));
                }
                break;
                case NativeSizeCode.W64:
                {
                    var value = @as<long>(data);
                    if(value < 0)
                        dst = text.format("-{0}", ((ulong)((~((ulong)value) + 1))).FormatHex(zpad:false, uppercase:true));
                    else
                        dst = (((ulong)value).FormatHex(zpad:false, uppercase:true));

                }
                break;
            }
            return dst;
        }

        public enum FormatCode : byte
        {
            None,

            [Symbol("b1")]
            B1,

            [Symbol("b2")]
            B2,

            [Symbol("b3")]
            B3,

            [Symbol("b4")]
            B4,

            [Symbol("b5")]
            B5,

            [Symbol("b6")]
            B6,

            [Symbol("b7")]
            B7,

            [Symbol("b8")]
            B8,

            [Symbol("u2")]
            U2,

            [Symbol("u3")]
            U3,

            [Symbol("u4")]
            U4,

            [Symbol("u5")]
            U5,

            [Symbol("u6")]
            U6,

            [Symbol("u7")]
            U7,

            [Symbol("u8")]
            U8,

            [Symbol("u16")]
            U16,

            [Symbol("u32")]
            U32,

            [Symbol("u64")]
            U64,

            [Symbol("i2")]
            I2,

            [Symbol("i3")]
            I3,

            [Symbol("i4")]
            I4,

            [Symbol("i5")]
            I5,

            [Symbol("i6")]
            I6,

            [Symbol("i7")]
            I7,

            [Symbol("i8")]
            I8,

            [Symbol("i16")]
            I16,

            [Symbol("i32")]
            I32,

            [Symbol("i64")]
            I64,

            [Symbol("x2")]
            x2,

            [Symbol("x3")]
            x3,

            [Symbol("x4")]
            x4,

            [Symbol("x5")]
            x5,

            [Symbol("x6")]
            x6,

            [Symbol("x7")]
            x7,

            [Symbol("x8")]
            x8,

            [Symbol("x16")]
            x16,

            [Symbol("x32")]
            x32,

            [Symbol("x64")]
            x64,

            [Symbol("X2")]
            X2,

            [Symbol("X3")]
            X3,

            [Symbol("X4")]
            X4,

            [Symbol("X5")]
            X5,

            [Symbol("X6")]
            X6,

            [Symbol("X7")]
            X7,

            [Symbol("X8")]
            X8,

            [Symbol("X16")]
            X16,

            [Symbol("X32")]
            X32,

            [Symbol("X64")]
            X64,

            [Symbol("c7")]
            c7,

            [Symbol("c8")]
            c8,

            [Symbol("c16")]
            c16,
        }

        public enum SeqStyleKind : byte
        {
            Default,

            Adjacent,

            Delimited,
        }

        public enum DataWidth : byte
        {
            Default,

            W1 = 1,

            W2 = 2,

            W3 = 3,

            W4 = 4,

            W5 = 5,

            W6 = 6,

            W7 = 7,

            W8 = 8,

            W16 = 16,

            W32 = 32,

            W64 = 64
        }

        [Flags]
        public enum FormatKind : uint
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
}