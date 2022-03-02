//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Rules;
    public interface IChoiceRule : IRuleExpr
    {
        Index<IRuleExpr> Terms {get;}

        RuleExprKind IRuleExpr.ExprKind
            => RuleExprKind.Choice;
    }
}