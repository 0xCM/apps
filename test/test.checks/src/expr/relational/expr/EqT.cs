//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Relations
    {
        [StructLayout(LayoutKind.Sequential)]
        public readonly struct Eq<T> : IFreeCmpPred<Eq<T>,T>
            where T : unmanaged
        {
            public T Left {get;}

            public T Right {get;}

            [MethodImpl(Inline)]
            public Eq(T a, T b)
            {
                Left = a;
                Right = b;
            }

            public CmpPredKind Kind
                => CmpPredKind.EQ;

            [MethodImpl(Inline)]
            public Eq<T> Create(T a0, T a1)
                => new Eq<T>(a0,a1);

            [MethodImpl(Inline)]
            public static implicit operator Eq<T>((T a, T b) src)
                => new Eq<T>(src.a, src.b);
        }
    }
}