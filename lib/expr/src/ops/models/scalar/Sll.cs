//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Ops.Scalar
{
    public class Sll : OpExpr2<Sll,BinaryBitLogicKind>
    {
        public Sll(IExpr a, IExpr b)
            : base(a,b)
        {
        }

        public override Label OpName => "sll";

        public override BinaryBitLogicKind Kind
            => BinaryBitLogicKind.And;

        public override Sll Make(IExpr a, IExpr b)
            => new Sll(a,b);
    }
}