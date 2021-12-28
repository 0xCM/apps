//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Ops.Scalar
{
    public class And : OpExpr2<And,BinaryBitLogicKind>
    {
        public And(IExpr a, IExpr b)
            : base(a,b)
        {
        }

        public override Name OpName
            => "and";

        public override BinaryBitLogicKind Kind
            => BinaryBitLogicKind.And;

        public override And Create(IExpr a, IExpr b)
            => new And(a,b);
    }
}