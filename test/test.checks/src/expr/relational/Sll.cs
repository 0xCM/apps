//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Ops.Scalar
{
    public class Sll : BinaryOpExpr<Sll,BinaryBitLogicKind>
    {
        public Sll(IExpr a, IExpr b)
            : base(a,b)
        {
        }

        public override Name OpName => "sll";

        public override BinaryBitLogicKind Kind
            => BinaryBitLogicKind.And;

        public override Sll Create(IExpr a, IExpr b)
            => new Sll(a,b);
    }
}