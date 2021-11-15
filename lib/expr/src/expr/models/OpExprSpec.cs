//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Expr
{
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct OpExprSpec
    {
        public ExprScope Scope {get;}

        public Label OpName {get;}

        public Index<IExpr> Operands {get;}

        [MethodImpl(Inline)]
        public OpExprSpec(ExprScope scope, Label opname, IExpr[] operands)
        {
            Scope = scope;
            OpName = opname;
            Operands = operands;
        }
    }
}