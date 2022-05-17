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
            public readonly T Left {get;}

            public readonly T Right {get;}

            public readonly CmpPredKind Kind {get;}

            [MethodImpl(Inline)]
            public CmpPred(T a, T b, CmpPredKind kind)
            {
                Left = a;
                Right = b;
                Kind = kind;
            }

            public CmpPred<T> Create(T a, T b)
                => new CmpPred<T>(a, b, Kind);
        }
    }
}