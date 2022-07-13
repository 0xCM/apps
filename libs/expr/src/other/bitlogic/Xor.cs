//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Ops.Scalar
{
    public class Xor : BinaryOpExpr<Xor,BinaryBitLogicKind>
    {
        public Xor(IExprDeprecated a, IExprDeprecated b)
            : base(a,b)
        {
        }

        public override Identifier OpName
            => "xor";

        public override BinaryBitLogicKind Kind
            => BinaryBitLogicKind.Xor;

        public override Xor Create(IExprDeprecated a, IExprDeprecated b)
            => new Xor(a,b);
    }
}