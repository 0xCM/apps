//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{

    partial class Relations
    {
        [StructLayout(StructLayout)]
        public readonly struct Neq<T> : IFreeCmpPred<Neq<T>,T>
            where T : unmanaged
        {
            public T Left {get;}

            public T Right {get;}

            [MethodImpl(Inline)]
            public Neq(T a, T b)
            {
                Left = a;
                Right = b;
            }

            public CmpPredKind Kind
                => CmpPredKind.NEQ;

            [MethodImpl(Inline)]
            public Neq<T> Create(T a0, T a1)
                => new Neq<T>(a0,a1);

            [MethodImpl(Inline)]
            public static implicit operator Neq<T>((T a, T b) src)
                => new Neq<T>(src.a, src.b);
        }
    }
}