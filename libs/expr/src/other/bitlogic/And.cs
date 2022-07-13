//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Ops.Scalar
{
    public class And : BinaryOpExpr<And,BinaryBitLogicKind>
    {
        public And(IExprDeprecated a, IExprDeprecated b)
            : base(a,b)
        {
        }

        public override Identifier OpName
            => "and";

        public override BinaryBitLogicKind Kind
            => BinaryBitLogicKind.And;

        public override And Create(IExprDeprecated a, IExprDeprecated b)
            => new And(a,b);
    }
}