//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Rules;

    public interface IRuleExpr : IExpr
    {
        bool IsTerminal
            => false;

        RuleExprKind ExprKind
            => RuleExprKind.None;
    }

    public interface IRuleExpr<T> : IRuleExpr
    {
        T Content {get;}
    }
}