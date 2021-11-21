//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Ops.Scalar
{
    public class Not : OpExpr1<Not,UnaryBitLogicKind>
    {
        public Not(IExpr a)
            : base(a)
        {
        }

        public override Label OpName => "not";

        public override UnaryBitLogicKind Kind
            => UnaryBitLogicKind.Not;

        public override Not Make(IExpr a)
            => new Not(a);
    }
}