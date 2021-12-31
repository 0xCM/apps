//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static core;

    partial class bits
    {
        /// <summary>
        /// Constructs a bitstring from text
        /// </summary>
        /// <param name="src">The bit source</param>
        [Op]
        public static Outcome parse(string src, out Span<bit> dst)
        {
            dst = alloc<bit>(src.Length);
            var result = parse(src,dst);
            if(result.Ok)
                dst = core.slice(dst,0, result.Data);
            else
                dst = default;

            return result;
        }

        public static Outcome<uint> parse(string src, Span<bit> dst)
        {
            var input = core.span(src.RemoveBlanks().Remove("0b")).Reverse();
            if(input.Length > dst.Length)
                return (false, "Insufficient buffer size");

            var result = Outcome.Success;
            var count = input.Length;
            var lastix = count - 1;
            var counter = 0u;
            for(var i=0; i<count; i++)
            {
                ref readonly var c = ref skip(input,i);
                ref var bit = ref seek(dst, i);
                if(c == bit.Zero)
                    bit = bit.Off;
                else if(c == bit.One)
                    bit = bit.On;
                else
                {
                    result = (false, string.Format("Found non-binary digit in {0}", src));
                    break;
                }
                counter++;
            }
            return result.Ok ? (true,counter) : result;
        }
    }
}