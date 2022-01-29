//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IRuleExpr : IExpr
    {
        bool IsTerminal {get;}

        RuleExprKind ExprKind
            => RuleExprKind.None;
    }

    public interface IRuleExpr<T> : IRuleExpr
    {
        T Content {get;}
    }
}