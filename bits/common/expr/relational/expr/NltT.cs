//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Relations
    {
        [StructLayout(LayoutKind.Sequential)]
        public readonly struct Nlt<T> : IFreeCmpPred<Nlt<T>,T>
            where T : unmanaged
        {
            public T Left {get;}

            public T Right {get;}

            [MethodImpl(Inline)]
            public Nlt(T a, T b)
            {
                Left = a;
                Right = b;
            }

            public CmpPredKind Kind
                => CmpPredKind.NLT;

            [MethodImpl(Inline)]
            public Nlt<T> Create(T a0, T a1)
                => new Nlt<T>(a0, a1);

            [MethodImpl(Inline)]
            public static implicit operator Nlt<T>((T a, T b) src)
                => new Nlt<T>(src.a, src.b);
        }
    }
}