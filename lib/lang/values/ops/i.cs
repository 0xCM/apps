//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    using Types;

    partial struct TV
    {
        [MethodImpl(Inline), Op]
        public static i0<bit> i0()
            => default;

        [MethodImpl(Inline), Op]
        public static iN<T> iN<T>(uint n, T value = default)
            where T : unmanaged
                => new iN<T>(n,value);
    }
}