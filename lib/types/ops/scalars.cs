//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Ops
{
    using System;
    using System.Runtime.CompilerServices;

    using Scalar;

    using static Root;

    public readonly partial struct scalars
    {
        const NumericKind Closure = UnsignedInts;

        [MethodImpl(Inline)]
        public static Eq<T> eq<T>(T a, T b)
            where T : IExpr
                => new Eq<T>(a,b);

        [MethodImpl(Inline)]
        public static Neq<T> neq<T>(T a, T b)
            where T : IExpr
                => new Neq<T>(a,b);

        [MethodImpl(Inline)]
        public static Ge<T> ge<T>(T a, T b)
            where T : IExpr
                => new Ge<T>(a,b);

        [MethodImpl(Inline)]
        public static Gt<T> gt<T>(T a, T b)
            where T : IExpr
                => new Gt<T>(a,b);

        [MethodImpl(Inline)]
        public static Le<T> le<T>(T a, T b)
            where T : IExpr
                => new Le<T>(a,b);

        [MethodImpl(Inline)]
        public static Lt<T> lt<T>(T a, T b)
            where T : IExpr
                => new Lt<T>(a,b);

        [MethodImpl(Inline)]
        public static Ngt<T> ngt<T>(T a, T b)
            where T : IExpr
                => new Ngt<T>(a,b);

        [MethodImpl(Inline)]
        public static Nlt<T> nlt<T>(T a, T b)
            where T : IExpr
                => new Nlt<T>(a,b);

        [MethodImpl(Inline)]
        public static And<T> and<T>()
            where T : unmanaged
                => new And<T>();

        [MethodImpl(Inline)]
        public static Or<T> or<T>(T a, T b)
            where T : IExpr
                => new Or<T>(a,b);

        [MethodImpl(Inline)]
        public static Not<T> not<T>(T a)
            where T : IExpr
                => new Not<T>(a);

        [MethodImpl(Inline)]
        public static Xor<T> xor<T>(T a, T b)
            where T : IExpr
                => new Xor<T>(a,b);
    }
}