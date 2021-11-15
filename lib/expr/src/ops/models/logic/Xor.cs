//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Ops.Logic
{
    public class Xor : OpExpr2<Xor,LogicExprKind>, ILogicOp
    {
        public Xor(IExpr a, IExpr b)
            : base(a,b)
        {

        }

        public override LogicExprKind Kind
            => LogicExprKind.XOr;

        public override Label OpName => "xor";

        public override Xor Make(IExpr a, IExpr b)
            => new Xor(a,b);
    }
}