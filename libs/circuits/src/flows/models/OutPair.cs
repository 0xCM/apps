//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Gated
    {
        public readonly struct OutPair<T>
            where T : unmanaged
        {
            public T A {get;}

            public T B {get;}

            [MethodImpl(Inline)]
            public OutPair(T x, T y)
            {
                A = x;
                B = y;
            }

            [MethodImpl(Inline)]
            public void Deconstruct(out T x, out T y)
            {
                x = A;
                y = B;
            }

            [MethodImpl(Inline)]
            public static implicit operator (T x, T y)(OutPair<T> src)
                => (src.A, src.B);

            [MethodImpl(Inline)]
            public static implicit operator OutPair<T> ((T x, T y) src)
                => new OutPair<T>(src.x, src.y);

            [MethodImpl(Inline)]
            public static implicit operator OutPair<T>(InPair<T> src)
                => new OutPair<T>(src.A,src.B);
        }
    }
}