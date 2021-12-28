//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Ops.Scalar
{
    public class Eq : OpExpr2<Eq,CmpPredKind>
    {
        public Eq(IExpr a, IExpr b)
            : base(a,b)
        {
        }

        public override Name OpName
            => "eq";

        public override CmpPredKind Kind
            => CmpPredKind.EQ;

        public override Eq Create(IExpr a, IExpr b)
            => new Eq(a,b);
    }
}