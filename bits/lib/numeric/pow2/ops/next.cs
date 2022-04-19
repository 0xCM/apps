//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct Pow2
    {
        [MethodImpl(Inline), Op]
        public static ulong next(ulong src)
            => pow((byte)(log(src) + 1));
    }
}