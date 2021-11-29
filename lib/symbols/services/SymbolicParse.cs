//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    using SQ = SymbolicQuery;

    [ApiHost]
    public readonly struct SymbolicParse
    {
        [Op]
        public static int SkipWhitespace(ReadOnlySpan<AsciCode> src)
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


        /// <summary>
        /// Parsed the leading digit sequence of a given row
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        public static Outcome digits(Base10 @base, in AsciLine src, ref uint i, out ushort dst)
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

                if(SQ.digit(@base, c))
                {
                    result = parse(@base, slice(data,i), out dst);
                    break;
                }
            }
            return result;
        }

        [MethodImpl(Inline), Op]
        public static uint convert(ReadOnlySpan<AsciCode> src, Span<char> dst)
        {
            var count = (uint)min(src.Length, dst.Length);
            for(var i=0; i<count; i++)
                seek(dst,i) = (char)skip(src,i);
            return count;
        }

        [MethodImpl(Inline), Op]
        public static uint convert(ReadOnlySpan<char> src, Span<AsciCode> dst)
        {
            var count = (uint)min(src.Length, dst.Length);
            for(var i=0; i<count; i++)
                seek(dst,i) = (AsciCode)skip(src,i);
            return count;
        }

        [Op]
        public static Outcome parse(Base10 @base, ReadOnlySpan<AsciCode> src, out ushort dst)
        {
            var storage = CharBlock16.Null;
            var buffer = storage.Data;
            convert(src, buffer);
            return ScalarParser.parse(@base, buffer, out dst);
        }

        [Op]
        public static Outcome parse(Base10 @base, ReadOnlySpan<AsciCode> src, ref uint i, out ushort dst)
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
    }
}