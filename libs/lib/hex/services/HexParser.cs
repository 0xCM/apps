//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Globalization;

    using static core;
    using static HexFormatSpecs;
    using static Msg;

    using X = HexDigitFacets;
    using C = AsciCharSym;
    using D = HexDigitValue;

    using static Hex;

    [ApiHost]
    public readonly struct HexParser
    {
        public static Outcome parse8i(string src, out sbyte dst)
            =>sbyte.TryParse(clear(src), NumberStyles.HexNumber, null,  out dst);

        public static Outcome parse8u(string src, out byte dst)
            => byte.TryParse(clear(src), NumberStyles.HexNumber, null,  out dst);

        public static Outcome parse16i(string src, out short dst)
            => short.TryParse(clear(src), NumberStyles.HexNumber, null,  out dst);

        public static Outcome parse16u(string src, out ushort dst)
            => ushort.TryParse(clear(src), NumberStyles.HexNumber, null,  out dst);

        public static Outcome parse32i(string src, out int dst)
            => int.TryParse(clear(src), NumberStyles.HexNumber, null,  out dst);

        public static Outcome parse32u(string src, out uint dst)
            => uint.TryParse(clear(src), NumberStyles.HexNumber, null,  out dst);

        public static Outcome parse64i(string src, out long dst)
            => long.TryParse(clear(src), NumberStyles.HexNumber, null,  out dst);

        public static Outcome parse64u(string src, out ulong dst)
            => ulong.TryParse(clear(src), NumberStyles.HexNumber, null,  out dst);

        public static Outcome parse8i(ReadOnlySpan<char> src, out sbyte dst)
            =>sbyte.TryParse(clear(src), NumberStyles.HexNumber, null,  out dst);

        public static Outcome parse8u(ReadOnlySpan<char> src, out byte dst)
            => byte.TryParse(clear(src), NumberStyles.HexNumber, null,  out dst);

        public static Outcome parse16i(ReadOnlySpan<char> src, out short dst)
            => short.TryParse(clear(src), NumberStyles.HexNumber, null,  out dst);

        public static Outcome parse16u(ReadOnlySpan<char> src, out ushort dst)
            => ushort.TryParse(clear(src), NumberStyles.HexNumber, null,  out dst);

        public static Outcome parse32i(ReadOnlySpan<char> src, out int dst)
            => int.TryParse(clear(src), NumberStyles.HexNumber, null,  out dst);

        public static Outcome parse32u(ReadOnlySpan<char> src, out uint dst)
            => uint.TryParse(clear(src), NumberStyles.HexNumber, null,  out dst);

        public static Outcome parse64i(ReadOnlySpan<char> src, out long dst)
            => long.TryParse(clear(src), NumberStyles.HexNumber, null,  out dst);

        public static Outcome parse64u(ReadOnlySpan<char> src, out ulong dst)
            => ulong.TryParse(clear(src), NumberStyles.HexNumber, null,  out dst);

        public static Outcome parse(string src, out BinaryCode dst)
        {
            var result = Outcome.Success;
            var count = text.length(src);
            dst = BinaryCode.Empty;
            if(count % 2 != 0)
                return (false, UnevenNibbles.Format(src));
            var size = count/2;
            var buffer = alloc<byte>(size);
            var input = span(src);
            for(int i=0, j=0; i<count; i+=2, j++)
            {
                result = parse(skip(input,i), skip(input, i+1), out seek(buffer, j));
                if(result.Fail)
                {
                    dst = BinaryCode.Empty;
                    return result;
                }
            }

            dst = buffer;
            return true;
        }

        /// <summary>
        /// Parses a nibble
        /// </summary>
        /// <param name="c">The source character</param>
        [MethodImpl(Inline), Op]
        public static bool parse(AsciCode c, out byte dst)
        {
            if(scalar(c))
            {
                dst = (byte)((byte)c - MinScalarCode);
                return true;
            }
            else if(upper(c))
            {
                dst = (byte)((byte)c - MinCharCodeU + 0xA);
                return true;
            }
            else if(lower(c))
            {
                dst = (byte)((byte)c - MinCharCodeL + 0xa);
                return true;
            }
            dst = byte.MaxValue;
            return false;
        }

        /// <summary>
        /// Parses a nibble
        /// </summary>
        /// <param name="c">The source character</param>
        [MethodImpl(Inline), Op]
        public static bool parse(char c, out byte dst)
            => parse((AsciCode)c, out dst);

        [MethodImpl(Inline), Op]
        public static bool parse(char c0, char c1, out byte dst)
        {
            if(parse(c0, out byte d0) && parse(c1, out byte d1))
            {
                dst = (byte)((d0 << 4) | d1);
                return true;
            }
            dst = 0;
            return false;
        }

        [Op]
        public static Outcome<uint> parse(ReadOnlySpan<char> src, Span<byte> dst)
        {
            var counter = 0u;
            var input = src;

            var j = text.index(src, Chars.x);
            var k = text.index(src, Chars.h);

            if(j > 0)
                input = right(input,j);
            if(k > 0)
                input = left(input, k);

            var hi = byte.MaxValue;
            for(var i=0; i<input.Length; i++)
            {
                ref readonly var c = ref skip(input,i);
                if(whitespace(c) || fence(c) || separator(c))
                    continue;

                if(parse(c, out HexDigitValue d))
                {
                    if(hi == byte.MaxValue)
                        hi = (byte)d;
                    else
                    {
                        var lo = (byte)d;
                        seek(dst, counter++) = Bytes.or(Bytes.sll(hi,4), lo);
                        hi = byte.MaxValue;
                    }
                }
                else
                    return false;
            }
            return (true,counter);
        }

        [Op]
        public static uint data(ReadOnlySpan<char> src, uint offset, Span<byte> dst)
        {
            var counter = offset;
            var count = (uint)src.Length;
            ref var target = ref first(dst);
            var hi = byte.MaxValue;
            for(var i=0; i<count; i++)
            {
                ref readonly var c = ref skip(src,i);
                if(whitespace(c) || fence(c) || separator(c))
                    continue;

                if(parse(c, out HexDigitValue d))
                {
                    if(hi == byte.MaxValue)
                        hi = (byte)d;
                    else
                    {
                        var lo = (byte)d;
                        seek(target, counter++) = Bytes.or(Bytes.sll(hi,4), lo);
                        hi = byte.MaxValue;
                    }
                }
                else
                {
                    count = 0;
                    break;
                }
            }
            return offset - counter;
        }

        [Op]
        public static Outcome parse(ReadOnlySpan<AsciCode> src, out ulong dst)
        {
            var lead = recover<AsciCode,byte>(src);
            var _offset = System.Text.Encoding.ASCII.GetString(lead);
            return ulong.TryParse(_offset, System.Globalization.NumberStyles.HexNumber, null, out dst);
        }

        [Op]
        public static Outcome parse(ReadOnlySpan<AsciCode> src, out Hex16 dst)
        {
            dst = default;
            var lead = recover<AsciCode,byte>(src);
            var _offset = System.Text.Encoding.ASCII.GetString(lead);
            var result = ushort.TryParse(_offset, System.Globalization.NumberStyles.HexNumber, null, out var n);
            if(result)
                dst = n;
            return result;
        }

        [Op]
        public static Outcome parse(ReadOnlySpan<AsciCode> src, out Hex32 dst)
        {
            dst = default;
            var lead = recover<AsciCode,byte>(src);
            var _offset = System.Text.Encoding.ASCII.GetString(lead);
            var result = uint.TryParse(_offset, System.Globalization.NumberStyles.HexNumber, null, out var n);
            if(result)
                dst = n;
            return result;
        }

        [Op]
        public static Outcome parse(ReadOnlySpan<AsciCode> src, out Hex64 dst)
        {
            dst = default;
            var lead = recover<AsciCode,byte>(src);
            var _offset = System.Text.Encoding.ASCII.GetString(lead);
            var result = ulong.TryParse(_offset, System.Globalization.NumberStyles.HexNumber, null, out var n);
            if(result)
                dst = n;
            return result;
        }

        [Op]
        public static Outcome<uint> parse(ReadOnlySpan<AsciCode> src, ref uint i, Span<byte> dst)
        {
            var i0 = i;
            var counter = 0u;
            var count = src.Length;
            ref var target = ref first(dst);
            var hi = byte.MaxValue;
            var lo = byte.MaxValue;
            for(var j=0; j<count; j++,i++)
            {
                ref readonly var c = ref skip(src,j);
                if(whitespace(c) || specifier(c))
                    continue;

                if(parse(c, out HexDigitValue d))
                {
                    if(hi == byte.MaxValue)
                        hi = (byte)d;
                    else
                    {
                        lo = (byte)d;
                        seek(target, counter++) = Bytes.or(Bytes.sll(hi,4), lo);
                        hi = byte.MaxValue;
                        lo = byte.MaxValue;
                    }
                }
                else
                    return false;
            }
            return (true, counter);
        }

        [MethodImpl(Inline), Op]
        public static bool parse(AsciCode c, out HexDigitValue dst)
        {
            if(scalar(c))
            {
                dst = (HexDigitValue)((HexDigitCode)c - X.MinScalarCode);
                return true;
            }
            else if(upper(c))
            {
                dst = (HexDigitValue)((HexDigitCode)c - X.MinLetterCodeU + 0xA);
                return true;
            }
            else if(lower(c))
            {
                dst = (HexDigitValue)((HexDigitCode)c - X.MinLetterCodeL + 0xa);
                return true;
            }
            dst = (HexDigitValue)byte.MaxValue;
            return false;
        }

        [MethodImpl(Inline), Op]
        public static bool parse(char c, out HexDigitValue dst)
            => parse((AsciCode)c, out dst);

        [Op]
        public static bool parse(AsciCharSym src, out HexDigitValue dst)
        {
            switch(src)
            {
                case C.d0:
                    dst = D.x0;
                    break;
                case C.d1:
                    dst = D.x1;
                    break;
                case C.d2:
                    dst = D.x2;
                    break;
                case C.d3:
                    dst = D.x3;
                    break;
                case C.d4:
                    dst = D.x4;
                    break;
                case C.d5:
                    dst = D.x5;
                    break;
                case C.d6:
                    dst = D.x6;
                    break;
                case C.d7:
                    dst = D.x7;
                    break;
                case C.d8:
                    dst = D.x8;
                    break;
                case C.d9:
                    dst = D.x9;
                    break;
                case C.a:
                case C.A:
                    dst = D.A;
                    break;
                case C.b:
                case C.B:
                    dst = D.B;
                    break;
                case C.c:
                case C.C:
                    dst = D.C;
                    break;
                case C.d:
                case C.D:
                    dst = D.D;
                    break;
                case C.e:
                case C.E:
                    dst = D.E;
                    break;
                case C.f:
                case C.F:
                    dst = D.F;
                break;
                default:
                    dst = 0;
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Parses a space-delimited sequence of hex text
        /// </summary>
        /// <param name="src">The space-delimited hex</param>
        [Op]
        public static Outcome hexdata(string src, out byte[] dst)
        {
            try
            {
                dst = src.Trim().Split(Chars.Space).Select(x => byte.Parse(x, NumberStyles.HexNumber));
                return true;
            }
            catch(Exception e)
            {
                dst = sys.empty<byte>();
                return (e,$"Input:{src}");
            }
        }

        /// <summary>
        /// Parses a sequence of hex bytes, delimited by a space or comma
        /// </summary>
        /// <param name="src">The source</param>
        /// <param name="dst">The target</param>
        [Op]
        public static Outcome hexbytes(string src, out BinaryCode dst)
        {
            dst = BinaryCode.Empty;
            var result = Outcome.Success;
            if(empty(src))
                return result;

            var sep = delimiter(src);
            var parts = src.Replace(CharText.EOL, CharText.Space).SplitClean(sep).ToReadOnlySpan();
            var count = parts.Length;
            var buffer = alloc<byte>(count);
            ref var target = ref first(buffer);
            for(var i=0; i<count; i++)
            {
                ref readonly var part = ref skip(parts,i);
                result = parse8u(part, out seek(target,i));
                if(result.Fail)
                {
                    result = (false, Msg.HexParseFailure.Format(part));
                    return result;
                }
            }
            dst = buffer;
            return result;
        }

        [Op]
        public static Outcome<uint> hexbytes(string src, Span<byte> dst)
        {
            var size = 0u;
            var limit = (uint)dst.Length;
            var result = Outcome.Success;
            if(empty(src))
                return size;
            var sep = delimiter(src);
            var parts = src.Replace(CharText.EOL, CharText.Space).SplitClean(sep).ToReadOnlySpan();
            var count = src.Length;
            for(var i=0u; i<count && i<limit; i++)
            {
                ref readonly var part = ref skip(parts,i);
                result = parse8u(part, out seek(dst,i));
                if(result.Fail)
                    return (false,size);
                else
                    size++;
            }
            return size;
        }

        [MethodImpl(Inline)]
        static bit contains(ReadOnlySpan<AsciCode> src, AsciCode match)
        {
            var count = src.Length;
            for(var i=0; i<count; i++)
                if(match == skip(src,i))
                    return 1;
            return 0;
        }

        [MethodImpl(Inline)]
        static bit whitespace(AsciCode src)
            => contains(AsciCodes.whitespace(), src);

        [MethodImpl(Inline)]
        static bit whitespace(char src)
            => whitespace((AsciCode)src);

        [MethodImpl(Inline)]
        static bit separator(char src)
            => src == Chars.Comma;
    }
}