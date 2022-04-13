//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static bit;

    partial class bits
    {
        /// <summary>
        /// Constructs a bitstring from text
        /// </summary>
        /// <param name="src">The bit source</param>
        [Op]
        public static int parse(string src, out Span<bit> dst)
        {
            dst = alloc<bit>(src.Length);
            var count = parse(src,dst);
            if(count >= 0)
                dst = core.slice(dst, 0, count);
            else
                dst = default;
            return count;
        }

        public static int parse(string src, Span<bit> dst)
        {
            var input = core.span(src.RemoveBlanks().Remove("0b").Remove("_")).Reverse();
            if(input.Length > dst.Length)
                return -1;

            var result = true;
            var count = min(input.Length, dst.Length);
            var counter = 0;
            for(var i=0; i<count; i++)
            {
                ref readonly var c = ref skip(input,i);
                ref var bit = ref seek(dst, i);
                if(c == bit.Zero)
                    bit = Off;
                else if(c == bit.One)
                    bit = On;
                else
                {
                    result = false;
                    break;
                }
                counter++;
            }
            return result ? counter : -1;
        }
    }
}