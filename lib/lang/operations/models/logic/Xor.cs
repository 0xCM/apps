//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Ops.Logic
{
    public class Xor : OpExpr2<Xor,IBooleanExpr,LogicExprKind>, ILogicOp
    {
        public Xor(IBooleanExpr a, IBooleanExpr b)
            : base(a,b)
        {

        }

        public override LogicExprKind Kind
            => LogicExprKind.XOr;

        public override Label OpName
            => "xor";

        public override Xor Create(IBooleanExpr a, IBooleanExpr b)
            => new Xor(a,b);
    }
}