//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Ops.Logic
{
    public class Impl : OpExpr2<Impl,IBooleanExpr,LogicExprKind>
    {
        public Impl(IBooleanExpr a, IBooleanExpr b)
            : base(a,b)
        {
        }

        public override Name OpName
            => "impl";


        public override LogicExprKind Kind
            => LogicExprKind.Impl;

        public override Impl Create(IBooleanExpr a, IBooleanExpr b)
            => new Impl(a,b);
    }
}