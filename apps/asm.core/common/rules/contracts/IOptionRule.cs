//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Rules;

    public interface IOptionRule : IRuleExpr
    {
        IRuleExpr Potential {get;}

        RuleExprKind IRuleExpr.ExprKind
            => RuleExprKind.Option;
    }
}