//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct BitNumbers
    {
        [MethodImpl(Inline), Op]
        public static eight movlo(uint4 src, eight dst)
            => movzx(dst.Hi, w8) | movzx(src, w8);

        [MethodImpl(Inline), Op]
        public static eight movhi(uint4 src, eight dst)
            => movzx(dst.Lo, w8) | movzx(src, w8);
    }
}