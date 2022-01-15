//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Ops.Scalar
{
    public class Nlt : BinaryOpExpr<Nlt,CmpPredKind>
    {
        public Nlt(IExpr a, IExpr b)
            : base(a,b)
        {
        }

        public override Name OpName
            => "nlt";

        public override CmpPredKind Kind
            => CmpPredKind.NLT;

        public override Nlt Create(IExpr a, IExpr b)
            => new Nlt(a,b);
    }
}