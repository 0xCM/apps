//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct EClosures
    {
        [MethodImpl(Inline), Add, Closures(UInt64k)]
        public static @enum<E64u,T> add<T>(@enum<E64u,T> a, @enum<E64u,T> b)
            where T : unmanaged
                => emath.add(a, b);

        [MethodImpl(Inline), Sub, Closures(UInt64k)]
        public static @enum<E64u,T> sub<T>(@enum<E64u,T> a, @enum<E64u,T> b)
            where T : unmanaged
                => emath.sub(a, b);

        [MethodImpl(Inline), Add, Closures(UInt64k)]
        public static @enum<E64u,T> mul<T>(@enum<E64u,T> a, @enum<E64u,T> b)
            where T : unmanaged
                => emath.mul(a, b);

        [MethodImpl(Inline), Div, Closures(UInt64k)]
        public static @enum<E64u,T> div<T>(@enum<E64u,T> a, @enum<E64u,T> b)
            where T : unmanaged
                => emath.div(a, b);

        [MethodImpl(Inline), Mod, Closures(UInt64k)]
        public static @enum<E64u,T> mod<T>(@enum<E64u,T> a, @enum<E64u,T> b)
            where T : unmanaged
                => emath.mod(a, b);

        [MethodImpl(Inline), And, Closures(UInt64k)]
        public static @enum<E64u,T> and<T>(@enum<E64u,T> a, @enum<E64u,T> b)
            where T : unmanaged
                => emath.and(a, b);

        [MethodImpl(Inline), Or, Closures(UInt64k)]
        public static @enum<E64u,T> or<T>(@enum<E64u,T> a, @enum<E64u,T> b)
            where T : unmanaged
                => emath.or(a, b);

        [MethodImpl(Inline), Xor, Closures(UInt64k)]
        public static @enum<E64u,T> xor<T>(@enum<E64u,T> a, @enum<E64u,T> b)
            where T : unmanaged
                => emath.xor(a, b);

        [MethodImpl(Inline), Nand, Closures(UInt64k)]
        public static @enum<E64u,T> nand<T>(@enum<E64u,T> a, @enum<E64u,T> b)
            where T : unmanaged
                => emath.nand(a, b);

        [MethodImpl(Inline), Nor, Closures(UInt64k)]
        public static @enum<E64u,T> nor<T>(@enum<E64u,T> a, @enum<E64u,T> b)
            where T : unmanaged
                => emath.nor(a, b);
    }
}