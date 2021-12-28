//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Ops.Scalar
{
    public class Neq : OpExpr2<Neq,CmpPredKind>
    {
        public Neq(IExpr a, IExpr b)
            : base(a,b)
        {
        }

        public override Name OpName
            => "neq";

        public override CmpPredKind Kind
            => CmpPredKind.NEQ;

        public override Neq Create(IExpr a, IExpr b)
            => new Neq(a,b);
    }
}