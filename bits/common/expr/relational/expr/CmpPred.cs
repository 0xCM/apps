//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static FreeExpr;

    partial class Relations
    {
        public readonly struct CmpPred : IFreeCmpPred<CmpPred>
        {
            public readonly IFreeExpr Left {get;}

            public readonly IFreeExpr Right {get;}

            public readonly CmpPredKind Kind {get;}

            public readonly Sym<CmpPredKind> Symbol {get;}

            public readonly uint Size {get;}

            [MethodImpl(Inline)]
            public CmpPred(IFreeExpr a, IFreeExpr b, CmpPredKind kind)
            {
                Left = a;
                Right = b;
                Kind = kind;
                Size = a.Size;
                Symbol = Relations.symbol(Kind);
            }

            public bool Eval()
                => default;

            public string Format()
                => string.Concat("{0} {1} {2}", Left, Symbol, Right);

            public override string ToString()
                => Format();
        }
    }
}