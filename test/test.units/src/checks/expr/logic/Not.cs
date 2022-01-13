//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Ops.Logic
{
    public class Not : UnaryOpExpr<Not,LogicExprKind>, ILogicOp
    {
        public Not(IExpr a)
            : base(a)
        {

        }

        public override LogicExprKind Kind
            => LogicExprKind.Not;

        public override Name OpName
            => "not";

        public override Not Create(IExpr a)
            => new Not(a);
    }
}