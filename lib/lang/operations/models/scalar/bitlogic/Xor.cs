//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Ops.Scalar
{
    public class Xor : OpExpr2<Xor,BinaryBitLogicKind>
    {
        public Xor(IExpr a, IExpr b)
            : base(a,b)
        {
        }

        public override Label OpName
            => "xor";

        public override BinaryBitLogicKind Kind
            => BinaryBitLogicKind.Xor;

        public override Xor Create(IExpr a, IExpr b)
            => new Xor(a,b);
    }
}