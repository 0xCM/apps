
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Ops.Logic
{
    public class True : OpExpr<True,LogicExprKind>, ILogicOp
    {
        public override Label OpName
            => "true";

        public override LogicExprKind Kind
            => LogicExprKind.True;

        public override string Format()
            => "true";
    }
}