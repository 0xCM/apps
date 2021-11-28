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
        public static uint render16x8(ushort src, uint offset, char sep, Span<char> dst)
        {
            var counter = 0u;
            var cells = bytes(src);
            counter += render8(skip(cells,1), counter + offset, dst);
            counter += separate(counter + offset, sep, dst);
            counter += render8(skip(cells,0), counter + offset, dst);
            return counter;
        }

        [MethodImpl(Inline), Op]
        public static uint render16x8(ushort src, char sep, Span<char> dst)
            => render16x8(src,0, sep, dst);

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> render16x8(ushort src, char sep)
        {
            var buffer = CharBlock32.Null.Data;
            var count = render16x8(src, 0, sep, buffer);
            return slice(buffer,0,count);
        }
    }
}