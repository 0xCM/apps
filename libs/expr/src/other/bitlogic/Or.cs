//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Ops.Scalar
{
    public class Or : BinaryOpExpr<Or,BinaryBitLogicKind>
    {
        public Or(IExprDeprecated a, IExprDeprecated b)
            : base(a,b)
        {
        }

        public override Identifier OpName
            => "or";

        public override BinaryBitLogicKind Kind
            => BinaryBitLogicKind.Or;

        public override Or Create(IExprDeprecated a, IExprDeprecated b)
            => new Or(a,b);
    }
}