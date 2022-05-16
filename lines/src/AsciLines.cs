//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.IO;

    using static core;

    using C = AsciCode;

    [ApiHost]
    public class AsciLines
    {
        /// <summary>
        /// Reads a <see cref='AsciLine{bytee}'/> from the data source
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="number">The current line count</param>
        /// <param name="i">The source-relative offset</param>
        /// <param name="dst">The target</param>
        [Op]
        public static uint line(string src, ref uint number, ref uint i, out AsciLine<byte> dst)
        {
            var i0 = i;
            dst = AsciLine<byte>.Empty;
            var max = src.Length;
            var length = 0u;
            var data = span(src);
            if(empty(src,i))
            {
                i+=2;
            }
            else
            {
                while(i++ < max - 1)
                {
                    if(SQ.eol(skip(data, i), skip(data, i + 1)))
                    {
                        length = i - i0;
                        dst = line(++number, text.asci(text.slice(src, i0, length)).Storage);
                        i+=2;
                        break;
                    }
                }
            }
            return length;
        }

        [MethodImpl(Inline)]
        public static AsciLine<T> line<T>(uint number, T[] src)
            where T : unmanaged
                => new AsciLine<T>(number, src);

        /// <summary>
        /// Reads a <see cref='AsciLine'/> from the data source
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="counter">The current line count</param>
        /// <param name="pos">The source-relative offset</param>
        /// <param name="dst">The target</param>
        [Op]
        public static uint line(ReadOnlySpan<AsciCode> src, ref uint number, ref uint i, out AsciLine dst)
        {
            var i0 = i;
            dst = default;
            var max = src.Length;
            var length = 0u;
            while(i++ < max - 1)
            {
                if(SQ.eol(skip(src, i), skip(src, i + 1)))
                {
                    length = i - i0;
                    dst = new AsciLine(i0, slice(src, i0, length));
                    ++number;
                    i+=2;
                    break;
                }
            }

            return length;
        }

        [MethodImpl(Inline), Op]
        public static AsciLine asci(ReadOnlySpan<byte> src, uint number, uint offset, uint length)
            => new AsciLine(offset, recover<AsciSymbol>(slice(src, offset, length)));

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

        [Op]
        public static uint render(in AsciLine src, ref uint i, Span<char> dst)
        {
            var i0 = i;
            if(src.IsNonEmpty)
                text.render(src.Codes, ref i, dst);
            return i - i0;
        }

        [Op]
        public static uint render<T>(in AsciLine<T> src, ref uint i, Span<char> dst)
            where T : unmanaged
        {
            var i0 = i;
            if(src.IsNonEmpty)
                text.render(recover<T,AsciCode>(src.View), ref i, dst);
            return i - i0;
        }

        [MethodImpl(Inline), Op]
        public static bool empty(ReadOnlySpan<byte> src, uint offset)
        {
            var last = src.Length - 1;
            if(offset < last - 1)
                return SQ.eol(skip(src, offset), skip(src, offset + 1));
            return true;
        }

        [MethodImpl(Inline), Op]
        public static bool empty(ReadOnlySpan<char> src, uint offset)
        {
            var last = src.Length - 1;
            if(offset < last - 1)
                return SQ.eol(skip(src, offset), skip(src, offset + 1));
            return true;
        }

        [MethodImpl(Inline), Op]
        public static bool empty(ReadOnlySpan<AsciCode> src, uint offset)
            => empty(recover<AsciCode,byte>(src), offset);


        public static ReadOnlySpan<string> lines(MemoryFile src)
        {
            using var reader = new StreamReader(src.Stream, leaveOpen:true);
            return lines(reader.ReadToEnd());
        }

        [Op]
        public static ReadOnlySpan<string> lines(string src, bool keepblank = false, bool trim = true)
        {
            var lines = list<string>();
            var lineNumber = 0u;
            using(var reader = new StringReader(src))
            {
                var next = reader.ReadLine();
                while(next != null)
                {
                    if(text.blank(next))
                    {
                        if(keepblank)
                        {
                            lines.Add(next);
                            ++lineNumber;
                        }
                    }
                    else
                    {
                        lines.Add(trim ? text.trim(next) : next);
                        ++lineNumber;
                    }

                    next = reader.ReadLine();
                }
            }
            return lines.ViewDeposited();
        }

        [Op]
        public static Outcome number(ReadOnlySpan<char> src, out uint j, out LineNumber dst)
        {
            j = 0;
            dst = default;
            var i = text.index(src,Chars.Colon);
            if(i == NotFound)
                return false;

            if(uint.TryParse(slice(src,0, i), out var n))
            {
                j = (uint)(i + 1);
                dst = n;
                return true;
            }

            return false;
        }

        [Op]
        public static Outcome number(ReadOnlySpan<byte> src, out uint j, out LineNumber dst)
        {
            j=0;
            dst = 0;
            const char Delimiter = Chars.Colon;
            const byte LastIndex = 8;
            const byte ContentLength = 9;

            var result = Outcome.Failure;
            var storage = CharBlock8.Null;
            var buffer = storage.Data;

            while(j++ <= LastIndex)
            {
                ref readonly var c = ref skip(src, j);
                if(Digital.test(base10, c))
                    seek(buffer, j) = (char)c;
                else if(c == Delimiter && j==LastIndex)
                {
                    result = uint.TryParse(buffer, out var n);
                    if(result)
                        dst = n;
                    break;
                }
                else
                    break;
            }
            return result;
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


        [MethodImpl(Inline), Op]
        public static uint lines<C>(string src, Span<text<C>> dst, bool keepblank = false, bool trim = true)
            where C : unmanaged, ICharBlock<C>
        {
            var k=0u;
            var capacity = (uint)dst.Length;
            using(var reader = new StringReader(src))
            {
                var next = reader.ReadLine();
                while(next != null && k<capacity)
                {
                    if(text.blank(next))
                        if(keepblank)
                            seek(dst,k++) = next;
                    else
                        seek(dst, k++) = trim ? text.trim(next) : next;
                    next = reader.ReadLine();
                }
            }
            return k;
        }

        [MethodImpl(Inline), Op]
        public static uint lines<K,B>(string src, Span<text<K,B>> dst, bool keepblank = false, bool trim = true)
            where B : unmanaged, IStorageBlock<B>
            where K : unmanaged
        {
            var k=0u;
            var capacity = (uint)dst.Length;
            using(var reader = new StringReader(src))
            {
                var next = reader.ReadLine();
                while(next != null && k<capacity)
                {
                    if(text.blank(next))
                        if(keepblank)
                            seek(dst,k++) = text<K,B>.load(next);
                    else
                        seek(dst, k++) = text<K,B>.load(trim ? text.trim(next) : next);
                    next = reader.ReadLine();
                }
            }
            return k;
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