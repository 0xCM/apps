//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Ops.Scalar
{
    public class Nlt : OpExpr2<Nlt,CmpPredKind>
    {
        public Nlt(IExpr a, IExpr b)
            : base(a,b)
        {
        }

        public override Label OpName => "nlt";

        public override CmpPredKind Kind
            => CmpPredKind.NLT;

        public override Nlt Make(IExpr a, IExpr b)
            => new Nlt(a,b);
    }
}