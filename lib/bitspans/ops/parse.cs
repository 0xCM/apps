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

    partial class BitSpans
    {
        /// <summary>
        /// Creates a bitspan from text encoding of a binary number
        /// </summary>
        /// <param name="src">The bit source</param>
        [Op]
        public static BitSpan parse(ReadOnlySpan<char> src)
        {
            var count = src.Length;
            var dst = load(span<bit>(count));
            parse(src, dst);
            return dst;
        }

        /// <summary>
        /// Creates a bitspan from text encoding of a binary number
        /// </summary>
        /// <param name="src">The bit source</param>
        [MethodImpl(Inline), Op]
        public static void parse(ReadOnlySpan<char> src, BitSpan dst)
        {
            ref var target = ref dst.First;
            var input = src;
            var count = min(input.Length, dst.BitCount);
            var lastix = count - 1;
            for(var i=0; i<=lastix; i++)
            {
                ref readonly var c = ref skip(input,i);
                if(c == bit.Zero)
                    seek(target, lastix - i) = bit.Off;
                else if(c == bit.One)
                    seek(target, lastix - i) = bit.On;
            }
        }
    }
}