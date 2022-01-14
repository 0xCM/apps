//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Ops.Scalar
{
    public class Ge : BinaryOpExpr<Ge,CmpPredKind>
    {
        public Ge(IExpr a, IExpr b)
            : base(a,b)
        {
        }

        public override Name OpName
            => "Ge";

        public override CmpPredKind Kind
            => CmpPredKind.GE;

        public override Ge Create(IExpr a, IExpr b)
            => new Ge(a,b);
    }
}