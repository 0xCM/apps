//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct expr
    {
        [MethodImpl(Inline), Op]
        public static OpExprSpec spec(ExprScope scope, string opname, IExpr[] operands)
            => new OpExprSpec(scope,opname,operands);

        [MethodImpl(Inline), Op]
        public static ExprSpec spec(ExprScope scope, IExpr[] operands, IExprComposer composer)
            => new ExprSpec(scope,operands,composer);
    }
}