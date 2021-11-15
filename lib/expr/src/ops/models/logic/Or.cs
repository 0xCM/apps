//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Ops.Logic
{
    public class Or : OpExpr2<Or,LogicExprKind>, ILogicOp
    {
        public Or(IExpr a, IExpr b)
            : base(a,b)
        {
        }

        public override Label OpName
            => "or";

        public override LogicExprKind Kind
            => LogicExprKind.Or;

        public override Or Make(IExpr a, IExpr b)
            => new Or(a,b);
    }
}