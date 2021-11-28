//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.Intrinsics;

    using static Root;
    using static SFx;

    using K = ApiClasses;

    partial struct CalcHosts
    {
        [Closures(AllNumeric), Abs]
        public readonly struct Abs<T> : IUnaryOp<T>, IUnarySpanOp<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public readonly T Invoke(T a)
                => gmath.abs(a);

            [MethodImpl(Inline)]
            public Span<T> Invoke(ReadOnlySpan<T> a, Span<T> dst)
                => gcalc.apply(Calcs.abs<T>(), a, dst);
        }

        [Closures(AllNumeric), Abs]
        public readonly struct Abs128<T> : IBlockedUnaryOp128<T>
            where T : unmanaged
        {
            public K.Abs ApiClass => default;

            [MethodImpl(Inline)]
            public ref readonly SpanBlock128<T> Invoke(in SpanBlock128<T> src, in SpanBlock128<T> dst)
                => ref map(src, dst, Calcs.vabs<T>(w128));
        }

        [Closures(AllNumeric), Abs]
        public readonly struct Abs256<T> : IBlockedUnaryOp256<T>
            where T : unmanaged
        {
            public K.Abs ApiClass => default;

            [MethodImpl(Inline)]
            public ref readonly SpanBlock256<T> Invoke(in SpanBlock256<T> src, in SpanBlock256<T> dst)
                => ref map(src, dst, Calcs.vabs<T>(w256));
        }

        [Closures(SignedInts), Abs]
        public readonly struct VAbs128<T> : IUnaryOp128D<T>
            where T : unmanaged
        {
            public K.Abs ApiClass => default;

            [MethodImpl(Inline)]
            public Vector128<T> Invoke(Vector128<T> x)
                => gcpu.vabs(x);

            [MethodImpl(Inline)]
            public T Invoke(T a)
                => gmath.abs(a);
        }

        [Closures(SignedInts), Abs]
        public readonly struct VAbs256<T> : IUnaryOp256D<T>
            where T : unmanaged
        {
            public K.Abs ApiClass => default;

            [MethodImpl(Inline)]
            public Vector256<T> Invoke(Vector256<T> x)
                => gcpu.vabs(x);

            [MethodImpl(Inline)]
            public T Invoke(T a)
                => gmath.abs(a);
        }
    }
}