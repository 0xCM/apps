//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Ops.Logic
{
    public class Impl : OpExpr2<Impl,LogicExprKind>
    {
        public Impl(IExpr a, IExpr b)
            : base(a,b)
        {
        }

        public override Label OpName
            => "impl";

        public override LogicExprKind Kind
            => LogicExprKind.Impl;

        public override Impl Make(IExpr a, IExpr b)
            => new Impl(a,b);
    }
}