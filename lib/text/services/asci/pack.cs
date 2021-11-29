//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct AsciSymbols
    {
        [MethodImpl(Inline), Op]
        public static ushort pack(AsciCode c0, AsciCode c1)
            => (ushort)((uint)c0 | ((uint)c1 << 8));

        [MethodImpl(Inline), Op]
        public static ref uint pack(AsciCode c0, AsciCode c1, AsciCode c2, out uint dst)
        {
            dst = (uint)c0 | ((uint)c1 << 8) | (uint)c2 << 16;
            return ref dst;
        }

        [MethodImpl(Inline), Op]
        public static ref uint pack(AsciCode c0, AsciCode c1, AsciCode c2, AsciCode c3, out uint dst)
        {
            dst = (uint)c0 | ((uint)c1 << 8) | (uint)c2 << 16 | (uint)c3 << 24;
            return ref dst;
        }
    }
}