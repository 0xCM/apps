//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static FreeExpr;

    partial class Relations
    {
        [Free]
        public interface IFreeCmpPred : IFreeExpr
        {

        }

        [Free]
        public interface IFreeCmpPred<H> : IFreeCmpPred
            where H : IFreeCmpPred<H>
        {

        }

        [Free]
        public interface IFreeCmpPred<H,T> : IFreeCmpPred<H>, IFreeExpr<H,CmpPredKind,T>
            where T : unmanaged
            where H : IFreeCmpPred<H,T>
        {

            T Left {get;}

            T Right {get;}

            new CmpPredKind Kind {get;}

            CmpPredKind IKinded<CmpPredKind>.Kind
                => Kind;

            string ITextual.Format()
                => string.Format("{0} {1} {2}", Left, Symbols.expr<CmpPredKind>(Kind), Right);
        }
    }
}