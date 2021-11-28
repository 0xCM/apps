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
    using static core;
    using static SFx;

    using BL = ByteLogic;
    using LS = vlogic;
    using K = ApiClasses;

    partial struct CalcHosts
    {
        [Closures(UnsignedInts), Not]
        public readonly struct BvNot<T> : IBvUnaryOp<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public readonly BitVector<T> Invoke(BitVector<T> a)
                => BitVector.not(a);

            [MethodImpl(Inline)]
            public T Invoke(T a) => gmath.not(a);
        }

        [Closures(Integers), Not]
        public readonly struct VNot128<T> : IUnaryOp128D<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public Vector128<T> Invoke(Vector128<T> x)
                => gcpu.vnot(x);

            [MethodImpl(Inline)]
            public T Invoke(T a)
                => gbits.not(a);
        }

        [NumericClosures(Integers), Not]
        public readonly struct VNot256<T> : IUnaryOp256D<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public Vector256<T> Invoke(Vector256<T> x)
                => gcpu.vnot(x);

            [MethodImpl(Inline)]
            public T Invoke(T a)
                => gbits.not(a);
        }

        [Closures(Integers), Not]
        public readonly struct Not<T> : IUnaryOp<T>, IUnarySpanOp<T>
            where T : unmanaged
        {
            public const UnaryBitLogicKind OpKind = UnaryBitLogicKind.Not;

            [MethodImpl(Inline)]
            public T Invoke(T a)
                => gmath.not(a);

            [MethodImpl(Inline)]
            public Span<T> Invoke(ReadOnlySpan<T> src, Span<T> dst)
                => Calcs.not(src,dst);
        }

        [NumericClosures(Integers), Not]
        public readonly struct Not128<T> : IBlockedUnaryOp128<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public ref readonly SpanBlock128<T> Invoke(in SpanBlock128<T> src, in SpanBlock128<T> dst)
                => ref map(src, dst, Calcs.vnot<T>(w128));
        }

        [NumericClosures(Integers), Not]
        public readonly struct Not256<T> : IBlockedUnaryOp256<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public ref readonly SpanBlock256<T> Invoke(in SpanBlock256<T> src, in SpanBlock256<T> dst)
                => ref map(src, dst, Calcs.vnot<T>(w256));
        }


        public readonly struct Not<W,T> : IUnarySquare<W,T>
            where W : unmanaged, ITypeWidth
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public void Invoke(in T src, ref T dst)
            {
                if(typeof(W) == typeof(W64))
                    BL.not(in u8(src), ref u8(dst));
                else if(typeof(W) == typeof(W128))
                    LS.not(w128, src, ref dst);
                else if(typeof(W) == typeof(W256))
                    LS.not(w256, src, ref dst);
                else
                    throw no<W>();
            }

            [MethodImpl(Inline)]
            public void Invoke(int count, int step, in T src, ref T dst)
            {
                if(typeof(W) == typeof(W128))
                    LS.not(w128, count, step, src, ref dst);
                else if(typeof(W) == typeof(W256))
                    LS.not(w256, count, step, src, ref dst);
                else
                    throw no<W>();
            }
        }
    }
}