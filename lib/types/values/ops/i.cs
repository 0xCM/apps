//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;


    using static Root;
    using static core;

    using Types;

    partial struct TV
    {
        [MethodImpl(Inline), Op]
        public static i0<bit> i0()
            => default;

        [MethodImpl(Inline), Op]
        public static i1<byte> i1(byte src)
            => new i1<byte>(src);

        [MethodImpl(Inline), Op]
        public static i2<sbyte> i2(sbyte src)
            => new i2<sbyte>(src);

        [MethodImpl(Inline), Op]
        public static iN<T> iN<T>(uint n, T value = default)
            where T : unmanaged
                => new iN<T>(n,value);
    }
}