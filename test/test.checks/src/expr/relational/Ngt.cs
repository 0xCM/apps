//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Ops.Scalar
{
    public class Ngt : BinaryOpExpr<Ngt,CmpPredKind>
    {
        public Ngt(IExpr a, IExpr b)
            : base(a,b)
        {
        }

        public override Name OpName
            => "ngt";

        public override CmpPredKind Kind
            => CmpPredKind.NGT;

        public override Ngt Create(IExpr a, IExpr b)
            => new Ngt(a,b);
    }
}