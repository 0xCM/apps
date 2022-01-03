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

    partial struct Bitfields
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static BitfieldSeg<T> segment<T>(T src, uint offset, uint width)
            where T : unmanaged
                => new BitfieldSeg<T>(src,offset,width);
    }
}