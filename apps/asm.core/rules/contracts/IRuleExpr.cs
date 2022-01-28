//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IRuleExpr : IExpr
    {
        bool IsTerminal {get;}
    }

    public interface IRuleExpr<T> : IRuleExpr
    {
        T Content {get;}
    }
}