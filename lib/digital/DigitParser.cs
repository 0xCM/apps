//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using SQ = SymbolicQuery;

    [ApiHost]
    public struct DigitParser
    {
        CharBlock64 Storage;

        [MethodImpl(Inline)]
        Span<char> DigitBuffer()
        {
            Storage = CharBlock64.Null;
            return Storage.Data;
        }

        [MethodImpl(Inline), Op]
        public uint Parse(Base2 @base, string src, Span<char> dst)
        {
            var storage = CharBlock64.Null;
            var buffer = storage.Data;
            var count = min(SQ.digits(@base, src, buffer),64);
            for(var i=0; i<count; i++)
                seek(dst,i) = skip(buffer,i);
            return count;
        }

        [MethodImpl(Inline), Op]
        public uint Parse(Base10 @base, string src, Span<char> dst)
        {
            var storage = CharBlock32.Null;
            var buffer = storage.Data;
            var count = min(SQ.digits(@base, src, buffer),32);
            for(var i=0; i<count; i++)
                seek(dst,i) = skip(buffer,i);
            return count;
        }

        [MethodImpl(Inline), Op]
        public uint Parse(Base16 @base, string src, Span<char> dst)
        {
            var storage = CharBlock16.Null;
            var buffer = storage.Data;
            var count = min(SQ.digits(@base, src, buffer),16);
            for(var i=0; i<count; i++)
                seek(dst,i) = skip(buffer,i);
            return count;
        }

        [Op]
        public static uint digits(Base10 @base, ReadOnlySpan<char> src, uint offset, Span<DecimalDigitValue> dst)
        {
            var i=offset;
            var j=0u;
            var imax = src.Length - 1;
            while(i <= imax)
            {
                ref readonly var c = ref skip(src, i++);
                if(SQ.space(c) && j==0)
                    continue;

                if(Digital.test(@base, c))
                    seek(dst, j++) = (DecimalDigitValue)(AsciCode.d9 - (AsciCode)c);
                else
                    break;
            }
            return j;
        }

        [Op]
        public static bool parse32u(ReadOnlySpan<char> input, out uint dst)
        {
            const byte MaxDigitCount = 8;
            var storage = 0ul;
            var output = recover<uint4>(bytes(storage));
            dst = 0;
            var count = min(input.Length, MaxDigitCount);
            var j=0;
            var outcome = true;
            for(var i=count-1; i>=0; i--)
            {
                if(Digital.digit(@base16, skip(input,i), out var d))
                    seek(output, j++) = d;
                else
                    return false;
            }

            for(var k=0; k<j; k++)
                dst |= ((uint)skip(output, k) << k*4);
            return true;
        }
    }
}