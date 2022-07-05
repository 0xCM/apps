//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Z0.Ops;

    partial class LogicOps
    {
        public class Not : UnaryOpExpr<Not,LogicExprKind>, ILogicOp
        {
            public Not(IExprDeprecated a)
                : base(a)
            {

            }

            public override LogicExprKind Kind
                => LogicExprKind.Not;

            public override NameOld OpName
                => "not";

            public override Not Create(IExprDeprecated a)
                => new Not(a);
        }
    }
}