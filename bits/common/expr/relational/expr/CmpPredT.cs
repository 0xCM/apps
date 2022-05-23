//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Relations
    {
        public readonly struct CmpPred<T> : IFreeCmpPred<CmpPred<T>,T>
            where T : unmanaged
        {
            public readonly T Left;

            public readonly T Right;

            public readonly CmpPredKind Kind;

            [MethodImpl(Inline)]
            public CmpPred(T a, T b, CmpPredKind kind)
            {
                Left = a;
                Right = b;
                Kind = kind;
            }

            T IFreeCmpPred<CmpPred<T>, T>.Left
                => Left;

            T IFreeCmpPred<CmpPred<T>, T>.Right
                => Right;

            CmpPredKind IFreeCmpPred<CmpPred<T>, T>.Kind
                => Kind;

            public CmpPred<T> Create(T a, T b)
                => new CmpPred<T>(a, b, Kind);
        }
    }
}