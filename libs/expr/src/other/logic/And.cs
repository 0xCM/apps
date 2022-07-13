//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Z0.Ops;

    partial class LogicOps
    {
        public class And : BinaryOpExpr<And,IBooleanExpr,LogicExprKind>, ILogicOp
        {
            public And(IBooleanExpr a, IBooleanExpr b)
                : base(a,b)
            {
            }

            public override Identifier OpName
                => "and";

            public override LogicExprKind Kind
                => LogicExprKind.And;

            public override And Create(IBooleanExpr a, IBooleanExpr b)
                => new And(a,b);
        }
    }
}