
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Z0.Ops;

    partial class LogicOps
    {
        public class True : OpExpr<True,LogicExprKind>, ILogicOp
        {
            public override Name OpName
                => "true";

            public override LogicExprKind Kind
                => LogicExprKind.True;

            public override string Format()
                => "true";
        }
    }
}