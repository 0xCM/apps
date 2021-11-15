//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes a ternary operator parametrized by expression type
    /// </summary>
    public interface ITernaryOpExpr<X> : IOperatorExpr
        where X : IExpr
    {
        X FirstArg {get;}

        X SecondArg {get;}

        X ThirdArg {get;}
    }
}