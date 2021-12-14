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
        [MethodImpl(Inline)]
        public static uint render<N>(StringAddress<N> src, ref uint i, Span<char> dst)
            where N : unmanaged, ITypeNat
        {
            ref var c = ref first(src.Source);
            var n = src.Length;
            for(var j=0; j<n; j++)
                seek(dst,i++) = skip(c,j);
            return n;
        }

        [MethodImpl(Inline), Op]
        public static uint render(StringAddress src, ref uint i, Span<char> dst)
        {
            var i0=i;
            ref var c = ref first(src);
            var j=0u;
            while(c != 0 && i < dst.Length)
                seek(dst, i++) = skip(c, j++);
            return j-1;
        }
    }
}