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

    partial struct BitRender
    {
        [MethodImpl(Inline), Op]
        public static uint render64x8(ulong src, ref uint i, Span<char> dst)
        {
            var i0 = i;
            render32x8((uint)(src >> 32), ref i, dst);
            render32x8((uint)src, ref i, dst);
            return i - i0;
        }

        [MethodImpl(Inline), Op]
        public static uint render64x8(ulong src, Span<char> dst)
        {
            var i=0u;
            return render64x8(src, ref i, dst);
        }
    }
}