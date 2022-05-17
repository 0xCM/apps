//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Relations
    {
        [StructLayout(LayoutKind.Sequential)]
        public readonly struct Ngt<T> : IFreeCmpPred<Ngt<T>,T>
            where T : unmanaged
        {
            public T Left {get;}

            public T Right {get;}

            [MethodImpl(Inline)]
            public Ngt(T a, T b)
            {
                Left = a;
                Right = b;
            }

            public CmpPredKind Kind
                => CmpPredKind.NGT;

            [MethodImpl(Inline)]
            public Ngt<T> Create(T a0, T a1)
                => new Ngt<T>(a0, a1);

            [MethodImpl(Inline)]
            public static implicit operator Ngt<T>((T a, T b) src)
                => new Ngt<T>(src.a, src.b);
        }
    }
}