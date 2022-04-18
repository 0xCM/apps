//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Hex
    {
        [MethodImpl(Inline), Op]
        public static byte combine(HexDigitValue lo, HexDigitValue hi)
            => (byte)((byte)hi << 4 | (byte)lo);

        public static Outcome parse64u(string src, out ulong dst)
            => HexParser.parse64u(src, out dst);

        public static Outcome parse32u(string src, out uint dst)
            => HexParser.parse32u(src, out dst);

        public static Outcome parse16u(string src, out ushort dst)
            => HexParser.parse16u(src, out dst);

        public static Outcome parse8u(string src, out byte dst)
            => HexParser.parse8u(src, out dst);

        public static Outcome parse(string src, out BinaryCode dst)
            => HexParser.parse(src, out dst);

        /// <summary>
        /// Parses a nibble
        /// </summary>
        /// <param name="c">The source character</param>
        [MethodImpl(Inline), Op]
        public static bool parse(AsciCode src, out byte dst)
            => HexParser.parse(src, out dst);

        /// <summary>
        /// Parses a nibble
        /// </summary>
        /// <param name="src">The source character</param>
        [MethodImpl(Inline), Op]
        public static bool parse(char src, out byte dst)
            => HexParser.parse(src, out dst);

        [MethodImpl(Inline), Op]
        public static bool parse(char c0, char c1, out byte dst)
            => HexParser.parse(c0, c1, out dst);

        [Op]
        public static Outcome<uint> parse(ReadOnlySpan<char> src, Span<byte> dst)
            => HexParser.parse(src, dst);

        [Op]
        public static Outcome parse(ReadOnlySpan<AsciCode> src, out ulong dst)
            => HexParser.parse(src, out dst);

        [Op]
        public static Outcome parse(ReadOnlySpan<AsciCode> src, out Hex16 dst)
            => HexParser.parse(src, out dst);

        [Op]
        public static Outcome parse(ReadOnlySpan<AsciCode> src, out Hex32 dst)
            => HexParser.parse(src, out dst);

        [Op]
        public static Outcome parse(ReadOnlySpan<AsciCode> src, out Hex64 dst)
            => HexParser.parse(src, out dst);

        [Op]
        public static Outcome<uint> parse(ReadOnlySpan<AsciCode> src, ref uint i, Span<byte> dst)
            => HexParser.parse(src, ref i, dst);

        [MethodImpl(Inline), Op]
        public static bool parse(AsciCode src, out HexDigitValue dst)
            => HexParser.parse(src, out dst);

        [MethodImpl(Inline), Op]
        public static bool parse(char src, out HexDigitValue dst)
            => HexParser.parse(src, out dst);

        [Op]
        public static bool parse(AsciCharSym src, out HexDigitValue dst)
            => HexParser.parse(src, out dst);
    }
}