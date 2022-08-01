//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Globalization;

    using static Msg;
    using static core;
    using static HexFormatSpecs;

    using X = HexDigitFacets;
    using D = HexDigitFacets;
    using V = HexDigitValue;
    using C = AsciCharSym;

    partial struct Hex
    {
        [Parser]
        public static bool parse(string src, out Hash8 dst)
        {
            var result = Hex8.parse(src, out var hex);
            dst = 0;
            if(result)
                dst = (byte)hex;
            return result;
        }

        [Parser]
        public static bool parse(string src, out Hash16 dst)
        {
            var result = Hex16.parse(src, out var hex);
            dst = 0;
            if(result)
                dst = (ushort)hex;
            return result;
        }

        [Parser]
        public static bool parse(string src, out Hash32 dst)
        {
            var result = Hex32.parse(src, out var hex);
            dst = 0;
            if(result)
                dst = (uint)hex;
            return result;
        }

        [Parser]
        public static bool parse(string src, out Hash64 dst)
        {
            var result = Hex64.parse(src, out var hex);
            dst = 0;
            if(result)
                dst = (ulong)hex;
            return result;
        }

        [MethodImpl(Inline), Op]
        public static byte combine(HexDigitValue lo, HexDigitValue hi)
            => (byte)((byte)hi << 4 | (byte)lo);

        public static bool parse64u(string src, out ulong dst)
            => ulong.TryParse(clear(src), NumberStyles.HexNumber, null,  out dst);

        public static bool parse32u(string src, out uint dst)
            => uint.TryParse(clear(src), NumberStyles.HexNumber, null,  out dst);

        public static bool parse16u(string src, out ushort dst)
            => ushort.TryParse(clear(src), NumberStyles.HexNumber, null, out dst);

        public static bool parse8u(string src, out byte dst)
            => byte.TryParse(clear(src), NumberStyles.HexNumber, null, out dst);

        public static bool parse8i(string src, out sbyte dst)
            => sbyte.TryParse(clear(src), NumberStyles.HexNumber, null, out dst);

        public static bool parse16i(string src, out short dst)
            => short.TryParse(clear(src), NumberStyles.HexNumber, null, out dst);

        public static bool parse32i(string src, out int dst)
            => int.TryParse(clear(src), NumberStyles.HexNumber, null, out dst);

        public static bool parse64i(string src, out long dst)
            => long.TryParse(clear(src), NumberStyles.HexNumber, null, out dst);

        public static bool parse8u(ReadOnlySpan<char> src, out byte dst)
            => byte.TryParse(clear(src), NumberStyles.HexNumber, null,  out dst);

        public static bool parse16u(ReadOnlySpan<char> src, out ushort dst)
            => ushort.TryParse(clear(src), NumberStyles.HexNumber, null,  out dst);

        public static bool parse32u(ReadOnlySpan<char> src, out uint dst)
            => uint.TryParse(clear(src), NumberStyles.HexNumber, null,  out dst);

        public static bool parse64u(ReadOnlySpan<char> src, out ulong dst)
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
        /// <param name="src">The source character</param>
        [MethodImpl(Inline), Op]
        public static bool parse(char src, out byte dst)
            => parse((AsciCode)src, out dst);

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
        public static bool parse(ReadOnlySpan<AsciCode> src, out ulong dst)
        {
            var lead = recover<AsciCode,byte>(src);
            var _offset = System.Text.Encoding.ASCII.GetString(lead);
            return ulong.TryParse(_offset, System.Globalization.NumberStyles.HexNumber, null, out dst);
        }

        [Op]
        public static bool parse(ReadOnlySpan<AsciCode> src, out Hex16 dst)
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
        public static bool parse(ReadOnlySpan<AsciCode> src, out Hex32 dst)
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
        public static bool parse(ReadOnlySpan<AsciCode> src, out Hex64 dst)
        {
            dst = default;
            var lead = recover<AsciCode,byte>(src);
            var _offset = System.Text.Encoding.ASCII.GetString(lead);
            var result = ulong.TryParse(_offset, System.Globalization.NumberStyles.HexNumber, null, out var n);
            if(result)
                dst = n;
            return result;
        }

        [MethodImpl(Inline)]
        static bool whitespace(AsciCode src)
            => SQ.contains(AsciCodes.whitespace(), src);

        [MethodImpl(Inline)]
        static bool whitespace(char src)
            => whitespace((AsciCode)src);

        [MethodImpl(Inline)]
        static bool separator(char src)
            => src == Chars.Comma;

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
        public static bool parse(char src, out HexDigitValue dst)
            => parse((AsciCode)src, out dst);

        [Op]
        public static bool parse(AsciCharSym src, out HexDigitValue dst)
        {
            switch(src)
            {
                case C.d0:
                    dst = V.x0;
                    break;
                case C.d1:
                    dst = V.x1;
                    break;
                case C.d2:
                    dst = V.x2;
                    break;
                case C.d3:
                    dst = V.x3;
                    break;
                case C.d4:
                    dst = V.x4;
                    break;
                case C.d5:
                    dst = V.x5;
                    break;
                case C.d6:
                    dst = V.x6;
                    break;
                case C.d7:
                    dst = V.x7;
                    break;
                case C.d8:
                    dst = V.x8;
                    break;
                case C.d9:
                    dst = V.x9;
                    break;
                case C.a:
                case C.A:
                    dst = V.A;
                    break;
                case C.b:
                case C.B:
                    dst = V.B;
                    break;
                case C.c:
                case C.C:
                    dst = V.C;
                    break;
                case C.d:
                case C.D:
                    dst = V.D;
                    break;
                case C.e:
                case C.E:
                    dst = V.E;
                    break;
                case C.f:
                case C.F:
                    dst = V.F;
                break;
                default:
                    dst = 0;
                    return false;
            }

            return true;
        }

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
                if(!parse8u(cell, out seek(target,i)))
                    return false;
            }
            dst = buffer;
            return true;
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

        [Op]
        public static bool code(string src, out BinaryCode dst)
        {
            var result = false;
            if(hexdata(src, out var code))
            {
                dst = code;
                result = true;
            }
            else
            {
                dst = BinaryCode.Empty;
            }
            return result;
        }       
    }
}