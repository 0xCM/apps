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

    using C = AsciCode;

    partial struct SymbolicQuery
    {
        [MethodImpl(Inline), Op]
        public static int next(ReadOnlySpan<C> src, uint offset, C a0)
        {
            var i = offset;
            while(i < src.Length)
            {
                if(skip(src,i++) == a0)
                    return (int)i;
            }
            return NotFound;
        }

        [MethodImpl(Inline), Op]
        public static int next(ReadOnlySpan<char> src, uint offset, char c0)
        {
            var i = offset;
            while(i < src.Length)
            {
                if(skip(src,i++) == c0)
                    return (int)i;
            }
            return NotFound;
        }

        [MethodImpl(Inline), Op]
        public static int next(ReadOnlySpan<C> src, uint offset, C a0, C a1)
        {
            var i = offset;
            var max = src.Length - 1;
            while(i < max)
            {
                ref readonly var b0 = ref skip(src,i);
                ref readonly var b1 = ref skip(src,i+1);
                if(b0 == a0 && b1 == a1)
                    return (int)i;

                i++;
            }
            return NotFound;
        }
    }
}