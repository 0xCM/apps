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
    using static core;

    using BL = ByteLogic;
    using LS = vlogic;
    using K = ApiClasses;

    partial struct CalcHosts
    {
        [Closures(Integers), And]
        public readonly struct And<T> : IBinaryOp<T>, IBinarySpanOp<T>
            where T : unmanaged
        {
            public T Invoke(T a, T b)
                => gmath.and(a,b);

            [MethodImpl(Inline)]
            public Span<T> Invoke(ReadOnlySpan<T> a, ReadOnlySpan<T> b, Span<T> dst)
                => gcalc.apply(Calcs.and<T>(), a, b, dst);
        }


        [Closures(UnsignedInts), And]
        public readonly struct BvAnd<T> : IBvBinaryOp<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public readonly BitVector<T> Invoke(BitVector<T> a, BitVector<T> b)
                => BitVector.and(a,b);

            [MethodImpl(Inline)]
            public T Invoke(T a, T b)
                => gmath.and(a,b);
        }

        [Closures(Integers), And]
        public readonly struct VAnd128<T> : IBinaryOp128D<T>
            where T : unmanaged
        {
            public K.And ApiClass => default;

            [MethodImpl(Inline)]
            public Vector128<T> Invoke(Vector128<T> x, Vector128<T> y)
                => gcpu.vand(x,y);

            [MethodImpl(Inline)]
            public T Invoke(T a, T b)
                => gbits.and(a,b);
        }

        [Closures(Integers), And]
        public readonly struct VAnd256<T> : IBinaryOp256D<T>
            where T : unmanaged
        {
            public K.And ApiClass => default;

            [MethodImpl(Inline)]
            public Vector256<T> Invoke(Vector256<T> x, Vector256<T> y)
                => gcpu.vand(x,y);

            [MethodImpl(Inline)]
            public T Invoke(T a, T b)
                => gbits.and(a,b);
        }

        [Closures(Integers), And]
        public readonly struct And128<T> : IBlockedBinaryOp128<T>
            where T : unmanaged
        {
            public K.And ApiClass => default;

            [MethodImpl(Inline)]
            public ref readonly SpanBlock128<T> Invoke(in SpanBlock128<T> a, in SpanBlock128<T> b, in SpanBlock128<T> dst)
                => ref zip(a, b, dst, Calcs.vand<T>(w128));
        }

        [Closures(Integers), And]
        public readonly struct And256<T> : IBlockedBinaryOp256<T>
            where T : unmanaged
        {
            public K.And ApiClass => default;

            [MethodImpl(Inline)]
            public ref readonly SpanBlock256<T> Invoke(in SpanBlock256<T> a, in SpanBlock256<T> b, in SpanBlock256<T> dst)
                => ref zip(a, b, dst, Calcs.vand<T>(w256));
        }

        public readonly struct And<W,T> : IBinarySquare<W,T>
            where W : unmanaged, ITypeWidth
            where T : unmanaged
        {
            public K.And ApiClass => default;

            [MethodImpl(Inline)]
            public void Invoke(in T a, in T b, ref T dst)
            {
                if(typeof(W) == typeof(W64))
                    BL.and(u8(a), u8(b), ref u8(dst));
                else if(typeof(W) == typeof(W128))
                    LS.and(w128, a, b, ref dst);
                else if(typeof(W) == typeof(W256))
                    LS.and(w256, a, b, ref dst);
                else
                    throw no<W>();
            }

            [MethodImpl(Inline)]
            public void Invoke(int count, int step, in T a, in T b, ref T dst)
            {
                if(typeof(W) == typeof(W128))
                    LS.and(w128, count, step, a, b, ref dst);
                else if(typeof(W) == typeof(W256))
                    LS.and(w256, count, step, a, b, ref dst);
                else
                    throw no<W>();
            }
        }
    }
}