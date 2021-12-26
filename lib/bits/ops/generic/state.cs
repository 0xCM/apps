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

    partial class gbits
    {
        [MethodImpl(Inline)]
        public static bit state<T>(in T src, uint pos)
            where T : unmanaged, IIndexedBits
        {
            var b = core.bytes(src);
            var i = pos / 8u;
            var j = (byte)(pos % 8u);
            return bit.test(skip(b,i),j);
        }

        [MethodImpl(Inline)]
        public static void state<T>(bit src, uint pos, ref T dst)
            where T : unmanaged, IIndexedBits
        {
            var data = core.bytes(src);
            var i = pos / 8u;
            var j = (byte)(pos % 8u);
            bit.set(ref seek(data,i),j,src);
        }
    }
}