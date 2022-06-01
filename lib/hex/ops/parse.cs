//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static HexFormatSpecs;
    using D = HexDigitFacets;
    using static core;

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

        [MethodImpl(Inline), Op]
        public static bool parse(LowerCased @case, AsciCode c, out HexDigitValue dst)
        {
            var result = false;
            if(scalar(c))
            {
                dst = (HexDigitValue)((HexDigitCode)c - D.MinScalarCode);
                result = true;
            }
            else if(lower(c))
            {
                dst = (HexDigitValue)((HexDigitCode)c - D.MinLetterCodeL + 0xa);
                result = true;
            }
            else
                dst = (HexDigitValue)byte.MaxValue;
            return result;
        }

        [MethodImpl(Inline), Op]
        public static bool parse(UpperCased @case, AsciCode c, out HexDigitValue dst)
        {
            var result = false;

            if(scalar(c))
            {
                dst = (HexDigitValue)((HexDigitCode)c - D.MinScalarCode);
                result = true;
            }
            else if(upper(c))
            {
                dst = (HexDigitValue)((HexDigitCode)c - D.MinLetterCodeU + 0xA);
                result = true;
            }
            else
                dst = (HexDigitValue)byte.MaxValue;
            return result;
        }

        [MethodImpl(Inline), Op]
        public static bool parse(LowerCased @case, char c, out HexDigitValue dst)
            => parse(@case, (AsciCode)c, out dst);

        [MethodImpl(Inline), Op]
        public static bool parse(UpperCased @case, char c, out HexDigitValue dst)
            => parse(@case, (AsciCode)c, out dst);

        [MethodImpl(Inline), Op]
        public static bool parse(UpperCased @case, AsciCode c, out byte dst)
        {
            var result = false;
            if(scalar(c))
            {
                dst = (byte)((byte)c - MinScalarCode);
                result = true;
            }
            else if(upper(c))
            {
                dst = (byte)((byte)c - MinCharCodeU + 0xA);
                result = true;
            }
            else
                dst = byte.MaxValue;

            return result;
        }

        [MethodImpl(Inline), Op]
        public static bool parse(LowerCased @case, AsciCode c, out byte dst)
        {
            var result = false;
            if(scalar(c))
            {
                dst = (byte)((byte)c - MinScalarCode);
                result = true;
            }
            else if(lower(c))
            {
                dst = (byte)((byte)c - MinCharCodeL + 0xa);
                result = true;
            }
            else
                dst = byte.MaxValue;
            return result;
        }

        /// <summary>
        /// Parses a nibble
        /// </summary>
        /// <param name="c">The source character</param>
        [MethodImpl(Inline), Op]
        public static bool parse(UpperCased @case, char c, out byte dst)
            => parse(@case, (AsciCode)c, out dst);

        /// <summary>
        /// Parses a nibble
        /// </summary>
        /// <param name="c">The source character</param>
        [MethodImpl(Inline), Op]
        public static bool parse(LowerCased @case, char c, out byte dst)
            => parse(@case, (AsciCode)c, out dst);

        [MethodImpl(Inline), Op]
        public static bool parse(UpperCased @case, char c0, char c1, out byte dst)
        {
            var result = parse(@case, c0, out byte d0);
            result &= parse(@case, c1, out byte d1);
            if(result)
                dst = (byte)((d0 << 4) | d1);
            else
                dst = 0;
            return result;
        }

        [MethodImpl(Inline), Op]
        public static bool parse(LowerCased @case, char c0, char c1, out byte dst)
        {
            var result = parse(@case, c0, out byte d0);
            result &= parse(@case, c1, out byte d1);
            if(result)
                dst = (byte)((d0 << 4) | d1);
            else
                dst = 0;
            return result;
        }

        [Op]
        public static bool parse(UpperCased @case, ReadOnlySpan<char> src, out BinaryCode dst)
        {
            var result = true;
            var count = src.Length;
            dst = BinaryCode.Empty;
            var size = count/2;
            if(count % 2 != 0)
                return false;
            var buffer = alloc<byte>(size);
            for(int i=0, j=0; i<count; i+=2, j++)
            {
                result = parse(@case, skip(src,i), skip(src, i+1), out seek(buffer, j));
                if(!result)
                    break;
            }

            dst = buffer;
            return result;
        }

        [Op]
        public static bool parse(LowerCased @case, ReadOnlySpan<char> src, out BinaryCode dst)
        {
            var result = true;
            var count = src.Length;
            dst = BinaryCode.Empty;
            var size = count/2;
            if(count % 2 != 0)
                return false;
            var buffer = alloc<byte>(size);
            for(int i=0, j=0; i<count; i+=2, j++)
            {
                result = parse(@case, skip(src,i), skip(src, i+1), out seek(buffer, j));
                if(!result)
                    break;
            }

            dst = buffer;
            return result;
        }

        [Parser]
        public static bool parse(string src, out HexArray dst)
        {
            dst = HexArray.Empty;
            var l = text.index(src, Chars.LBracket);
            var r = text.index(src, Chars.RBracket);
            var i0 = 0;
            var i1 = 0;
            if(l < 0 || r < 0 || r <= l)
            {
                i0 = 0;
                i1 = src.Length - 1;
            }
            else
            {
                i0 = l + 1;
                i1 = r - 1;
            }

            var data =  text.segment(src, i0, i1);
            var cells = data.SplitClean(Chars.Comma).ToReadOnlySpan();
            var count = cells.Length;
            var buffer = alloc<byte>(count);
            ref var target = ref first(buffer);
            for(var i=0; i<count; i++)
            {
                ref readonly var cell = ref skip(cells,i);
                if(!HexParser.parse8u(cell, out seek(target,i)))
                    return false;
            }
            dst = buffer;
            return true;
        }
    }
}