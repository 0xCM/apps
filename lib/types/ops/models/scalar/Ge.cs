//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Ops.Scalar
{
    public class Ge : OpExpr2<Ge,CmpPredKind>
    {
        public Ge(IExpr a, IExpr b)
            : base(a,b)
        {
        }

        public override Label OpName => "Ge";

        public override CmpPredKind Kind
            => CmpPredKind.GE;

        public override Ge Make(IExpr a, IExpr b)
            => new Ge(a,b);
    }
}