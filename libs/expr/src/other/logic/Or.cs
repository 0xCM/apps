//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Z0.Ops;

    partial class LogicOps
    {
        public class Or : BinaryOpExpr<Or,LogicExprKind>, ILogicOp
        {
            public Or(IExprDeprecated a, IExprDeprecated b)
                : base(a,b)
            {
            }

            public override NameOld OpName
                => "or";

            public override LogicExprKind Kind
                => LogicExprKind.Or;

            public override Or Create(IExprDeprecated a, IExprDeprecated b)
                => new Or(a,b);
        }
    }
}