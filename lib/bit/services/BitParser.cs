//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [ApiHost]
    public readonly struct BitParser
    {
        const NumericKind Closure = UnsignedInts;

        [MethodImpl(Inline), Op]
        public static uint parse(ReadOnlySpan<char> src, Span<bit> dst)
        {
            var input = src;
            var count = (uint)min(src.Length,dst.Length);
            var lastix = count - 1;
            for(var i=0; i<= lastix; i++)
               seek(dst, lastix - i) = skip(input,i) == bit.Zero ? bit.Off : bit.On;
            return count;
        }

        public static Outcome parse<T>(string src, out bits<T> dst)
            where T : unmanaged
        {
            var result = Outcome.Success;
            var input = text.trim(text.despace(src));
            var content = input;
            if(text.fenced(input, RenderFence.Embraced))
                result = text.unfence(src, RenderFence.Embraced, out content);
            else if(text.fenced(input, RenderFence.Bracketed))
                result = text.unfence(src, RenderFence.Bracketed, out content);

            var sep = text.contains(src, Chars.Space) ? Chars.Space : Chars.Comma;
            var parts = text.split(content, sep);
            var n = (uint)parts.Length;
            var storage = default(T);
            var target = bytes(storage);
            var size = target.Length;
            var k = 0u;
            for(var i=0; i<size; i++)
            {
                ref var b = ref seek(target,i);
                for(byte j=0; j<8 && k < n; j++, k++)
                {
                    ref readonly var part = ref skip(parts,k);
                    if(bit.digit(part, out BinaryDigit d))
                        b |= (Bytes.sll((byte)d,j));
                }
            }

            dst = new bits<T>(n,storage);
            return result;
        }

        [Parser]
        public static bool parse(string src, out bit dst)
            => bit.parse(src, out dst);

        [Op]
        public static bool semantic(string src, out bit dst)
        {
            const string On1 = "1";
            const string On2 = "true";
            const string On3 = "yes";
            const string On4 = "on";
            const string Off1 = "0";
            const string Off2 = "false";
            const string Off3 = "no";
            const string Off4 = "off";

            dst = default;
            var result = false;
            if(empty(src))
                return false;

            var input = src.ToLowerInvariant();
            if(matches(input, On1))
            {
                dst = 1;
                result = true;
            }
            else if(matches(input, On2))
            {
                dst = 1;
                result = true;
            }
            else if(matches(input, On3))
            {
                dst = 1;
                result = true;
            }
            else if(matches(input, On4))
            {
                dst = 1;
                result = true;
            }
            else if(matches(input, Off1))
            {
                dst = 0;
                result = true;
            }
            else if(matches(input, Off2))
            {
                dst = 0;
                result = true;
            }
            else if(matches(input, Off3))
            {
                dst = 0;
                result = true;
            }
            else if(matches(input, Off4))
            {
                dst = 0;
                result = true;
            }

            return result;
        }

        [MethodImpl(Inline), Op]
        static bool matches(ReadOnlySpan<char> a, ReadOnlySpan<char> b)
        {
            var count = a.Length;
            if(count != b.Length)
                return false;

            for(var i=0; i<count; i++)
                if(skip(a,i) != skip(b, i))
                    return false;

            return true;
        }
    }
}