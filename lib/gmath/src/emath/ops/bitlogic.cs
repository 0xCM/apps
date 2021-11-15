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

    partial struct emath
    {
        [MethodImpl(Inline)]
        public static @enum<E,T> and<E,T>(@enum<E,T> a, @enum<E,T> b)
            where E : unmanaged, Enum
            where T : unmanaged
                => new @enum<E,T>(gmath.and(a.Scalar, b.Scalar));

        [MethodImpl(Inline)]
        public static T and<E,T>(@enum<E,T> a, T b)
            where E : unmanaged, Enum
            where T : unmanaged
                => gmath.and(a.Scalar, b);

        [MethodImpl(Inline)]
        public static T and<E,T>(T a, @enum<E,T> b)
            where E : unmanaged, Enum
            where T : unmanaged
                => gmath.and(a, b.Scalar);

        [MethodImpl(Inline)]
        public static @enum<E,T> nand<E,T>(@enum<E,T> a, @enum<E,T> b)
            where E : unmanaged, Enum
            where T : unmanaged
                => new @enum<E,T>(gmath.nand(a.Scalar, b.Scalar));

        [MethodImpl(Inline)]
        public static @enum<E,T> nor<E,T>(@enum<E,T> a, @enum<E,T> b)
            where E : unmanaged, Enum
            where T : unmanaged
                => new @enum<E,T>(gmath.nor(a.Scalar, b.Scalar));

        [MethodImpl(Inline)]
        public static @enum<E,T> not<E,T>(@enum<E,T> a)
            where E : unmanaged, Enum
            where T : unmanaged
                => new @enum<E,T>(gmath.not(a.Scalar));


        [MethodImpl(Inline)]
        public static @enum<E,T> xnor<E,T>(@enum<E,T> a, @enum<E,T> b)
            where E : unmanaged, Enum
            where T : unmanaged
                => new @enum<E,T>(gmath.xnor(a.Scalar, b.Scalar));

        [MethodImpl(Inline)]
        public static @enum<E,T> xor<E,T>(@enum<E,T> a, @enum<E,T> b)
            where E : unmanaged, Enum
            where T : unmanaged
                => new @enum<E,T>(gmath.xor(a.Scalar, b.Scalar));

        [MethodImpl(Inline)]
        public static T xor<E,T>(@enum<E,T> a, T b)
            where E : unmanaged, Enum
            where T : unmanaged
                => gmath.xor(a.Scalar, b);

        [MethodImpl(Inline)]
        public static T xor<E,T>(T a, @enum<E,T> b)
            where E : unmanaged, Enum
            where T : unmanaged
                => gmath.xor(a, b.Scalar);
    }
}