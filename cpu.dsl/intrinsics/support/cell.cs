//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Vdsl
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct Intrinsics
    {
        [MethodImpl(Inline), Closures(Closure)]
        public static m128i<T> m128i<T>()
            where T : unmanaged
                => default;

        [MethodImpl(Inline), Closures(Closure)]
        public static m256i<T> m256i<T>()
            where T : unmanaged
                => default;

        [MethodImpl(Inline), Closures(Closure)]
        public static m512i<T> m512i<T>()
            where T : unmanaged
                => default;

        public static m128i<byte> z128i(W8 w)
            => default;

        public static m128i<sbyte> z128i(W8i w)
            => default;

        public static m128i<ushort> z128i(W16 w)
            => default;

        public static m128i<uint> z128i(W32 w)
            => default;

        public static m128i<ulong> z128i(W64 w)
            => default;

        public static m256i<byte> z256i(W8 w)
            => default;

        public static m512i<byte> z512i(W8 w)
            => default;
     }
}