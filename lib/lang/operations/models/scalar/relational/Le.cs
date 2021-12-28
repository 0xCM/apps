//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Ops.Scalar
{
    public class Le : OpExpr2<Le,CmpPredKind>
    {
        public Le(IExpr a, IExpr b)
            : base(a,b)
        {
        }

        public override Name OpName
            => "le";

        public override CmpPredKind Kind
            => CmpPredKind.LE;

        public override Le Create(IExpr a, IExpr b)
            => new Le(a,b);
    }
}