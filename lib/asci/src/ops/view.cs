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

    partial struct Asci
    {
        [MethodImpl(Inline), Op]
        public static ref readonly asci2 view(N2 n, in ushort src)
            => ref @as<ushort,asci2>(src);

        [MethodImpl(Inline), Op]
        public static ref readonly asci4 view(N4 n, in uint src)
            => ref @as<uint,asci4>(src);

        [MethodImpl(Inline), Op]
        public static ref readonly asci8 view(N8 n, in ulong src)
            => ref @as<ulong,asci8>(src);
    }
}