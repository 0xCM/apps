//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Ops.Scalar
{
    public class Or : OpExpr2<Or,BinaryBitLogicKind>
    {
        public Or(IExpr a, IExpr b)
            : base(a,b)
        {
        }

        public override Label OpName => "or";

        public override BinaryBitLogicKind Kind
            => BinaryBitLogicKind.Or;

        public override Or Make(IExpr a, IExpr b)
            => new Or(a,b);
    }
}