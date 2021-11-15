//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Ops.Logic
{
    public class And : OpExpr2<And,LogicExprKind>, ILogicOp
    {
        public And(IExpr a, IExpr b)
            : base(a,b)
        {
        }

        public override Label OpName => "and";

        public override LogicExprKind Kind
            => LogicExprKind.And;

        public override And Make(IExpr a, IExpr b)
            => new And(a,b);
    }
}