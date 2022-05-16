//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Relations
    {
        [StructLayout(LayoutKind.Sequential)]
        public readonly struct Lt<T> : IFreeCmpPred<Lt<T>,T>
            where T : unmanaged
        {
            public T Left {get;}

            public T Right {get;}

            [MethodImpl(Inline)]
            public Lt(T a, T b)
            {
                Left = a;
                Right = b;
            }

            public CmpPredKind Kind
                => CmpPredKind.LT;

            [MethodImpl(Inline)]
            public Lt<T> Create(T a0, T a1)
                => new Lt<T>(a0, a1);

            [MethodImpl(Inline)]
            public static implicit operator Lt<T>((T a, T b) src)
                => new Lt<T>(src.a, src.b);
        }
    }
}