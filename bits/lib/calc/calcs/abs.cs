//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static CalcHosts;
    using static ApiClassKind;

    partial struct Calcs
    {
        [MethodImpl(Inline), Factory, Closures(Integers)]
        public static BitLogic<T> bitlogic<T>()
            where T : unmanaged
                => default(BitLogic<T>);

        [MethodImpl(Inline), Factory(Abs), Closures(SignedInts)]
        public static Abs<T> abs<T>()
            where T : unmanaged
                => default;

        [MethodImpl(Inline), Abs, Closures(SignedInts)]
        public static Span<T> abs<T>(ReadOnlySpan<T> src, Span<T> dst)
            where T : unmanaged
                => gcalc.apply(abs<T>(), src, dst);

        [MethodImpl(Inline), Factory(Abs), Closures(SignedInts)]
        public static Abs128<T> abs<T>(W128 w)
            where T : unmanaged
                => default(Abs128<T>);

        [MethodImpl(Inline), Factory(Abs), Closures(SignedInts)]
        public static Abs256<T> abs<T>(W256 w)
            where T : unmanaged
                => default(Abs256<T>);

        [MethodImpl(Inline), Factory(Abs), Closures(SignedInts)]
        public static VAbs128<T> vabs<T>(W128 w)
            where T : unmanaged
                => default(VAbs128<T>);

        [MethodImpl(Inline), Factory(Abs), Closures(SignedInts)]
        public static VAbs256<T> vabs<T>(W256 w)
            where T : unmanaged
                => default(VAbs256<T>);

        [MethodImpl(Inline), Abs, Closures(SignedInts)]
        public static ref readonly SpanBlock128<T> abs<T>(in SpanBlock128<T> a, in SpanBlock128<T> dst)
            where T : unmanaged
                => ref abs<T>(w128).Invoke(a, dst);

        [MethodImpl(Inline), Abs, Closures(SignedInts)]
        public static ref readonly SpanBlock256<T> abs<T>(in SpanBlock256<T> a, in SpanBlock256<T> dst)
            where T : unmanaged
                => ref abs<T>(w256).Invoke(a, dst);

        [MethodImpl(Inline), Abs, Closures(SignedInts)]
        public static ref readonly SpanBlock128<T> add<T>(in SpanBlock128<T> a, in SpanBlock128<T> b, in SpanBlock128<T> dst)
            where T : unmanaged
                => ref add<T>(w128).Invoke(a, b, dst);
    }
}