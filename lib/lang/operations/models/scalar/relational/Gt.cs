//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Ops.Scalar
{
    public class Gt : OpExpr2<Gt,CmpPredKind>
    {
        public Gt(IExpr a, IExpr b)
            : base(a,b)
        {
        }

        public override Name OpName
            => "gt";

        public override CmpPredKind Kind
            => CmpPredKind.GT;

        public override Gt Create(IExpr a, IExpr b)
            => new Gt(a,b);
    }
}