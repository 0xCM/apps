//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using C = AsciCode;

    [ApiHost]
    public partial class AsciLines
    {
        [Op]
        public static string format(in AsciLine src)
        {
            Span<char> buffer = stackalloc char[src.RenderLength];
            var i=0u;
            render(src, ref i, buffer);
            return text.format(buffer);
        }

        [Op]
        public static string format<T>(in AsciLine<T> src)
            where T : unmanaged
        {
            Span<char> buffer = stackalloc char[src.RenderLength];
            var i=0u;
            render(src, ref i, buffer);
            return text.format(buffer);
        }

        /// <summary>
        /// Computes the maximum line length of the lines represented by asci-encoded bytes
        /// </summary>
        /// <param name="src"></param>
        [MethodImpl(Inline), Op]
        public static uint maxlength(ReadOnlySpan<byte> src)
        {
            var size = src.Length;
            var max = 0u;
            var current = 0u;
            for(var pos=0u; pos<size; pos++)
            {
                if(!SQ.eol(skip(src, pos), skip(src, pos + 1)))
                    current++;
                else
                {
                    if(current > max)
                        max = current;
                    current = 0;
                    pos++;
                }
            }
            return max;
        }

        /// <summary>
        /// Finds the length of the line of greatest length using the <see cref='SQ.eol(char, char)'/> test
        /// to partition the source
        /// </summary>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static uint maxlength(ReadOnlySpan<char> src)
        {
            var count = src.Length;
            var max = 0u;
            var current = 0u;
            for(var pos=0u; pos<count; pos++)
            {
                if(!SQ.eol(skip(src, pos), skip(src, pos + 1)))
                    current++;
                else
                {
                    if(current > max)
                        max = current;
                    current = 0;
                    pos++;
                }
            }
            return max;
        }


        [Op]
        public static int SkipWhitespace(ReadOnlySpan<C> src)
        {
            var count = src.Length;
            var i=0;
            while(i < count)
            {
                if(!SQ.whitespace(skip(src,i)))
                    return i;
                else
                    i++;
            }
            return NotFound;
        }

        [Op]
        public static bool parse(Base10 @base, ReadOnlySpan<C> src, out ushort dst)
        {
            var storage = CharBlock16.Null;
            var buffer = storage.Data;
            Asci.convert(src, buffer);
            return ScalarParser.parse(@base, buffer, out dst);
        }

        [Op]
        public static Outcome parse(Base10 @base, ReadOnlySpan<C> src, ref uint i, out ushort dst)
        {
            dst = default;
            var result = Outcome.Success;
            var input = slice(src,i);
            var length = input.Length;
            var digits = SQ.digits(n16, base10, input);
            if(digits.Length == 0)
                result = (false,"No digits found");
            else
            {
                result = parse(@base, digits, out dst);
                if(result.Ok)
                    i += (uint)digits.Length;
            }
            return result;
        }

        public static Outcome parse(Base10 @base, in AsciLine src, ref uint i, out ushort dst)
        {
            var i0 = i;
            var result = Outcome.Success;
            dst = default;
            var data = slice(src.Codes, i);
            var length = data.Length;
            for(; i<length; i++)
            {
                ref readonly var c = ref skip(data,i);
                if(SQ.whitespace(c))
                    continue;

                if(Digital.test(@base, c))
                {
                    result = parse(@base, slice(data,i), out dst);
                    break;
                }
            }
            return result;
        }
    }
}