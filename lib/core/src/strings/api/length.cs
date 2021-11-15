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

    partial struct strings
    {
        /// <summary>
        /// Computes the total length of the source strings
        /// </summary>
        /// <param name="src">The source strings</param>
        [MethodImpl(Inline), Op]
        public static uint length(ReadOnlySpan<string> src)
        {
            var counter = 0u;
            var count = src.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var s = ref skip(src,i);
                counter += (uint)s.Length;
            }
            return counter;
        }

        [MethodImpl(Inline), Op]
        public static uint length(in MemoryStrings src, int index)
        {
            var a = offset(src, index);
            var b = 0u;
            if(index == src.EntryCount - 1)
                b = src.CharCount;
            else
                b = offset(src, index + 1);
            return (uint)(b - a);
        }


        [MethodImpl(Inline), Op]
        public static uint length(StringAddress src)
        {
            ref var c = ref strings.first(src);
            var counter = 0u;
            while(c != 0)
                c = seek(c, counter++);
            return counter;
        }
    }
}