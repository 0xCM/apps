//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Ops.Scalar
{
    public class Lt : OpExpr2<Lt,CmpPredKind>
    {
        public Lt(IExpr a, IExpr b)
            : base(a,b)
        {
        }

        public override Label OpName => "lt";

        public override CmpPredKind Kind
            => CmpPredKind.LT;

        public override Lt Make(IExpr a, IExpr b)
            => new Lt(a,b);
    }
}