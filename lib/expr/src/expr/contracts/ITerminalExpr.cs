//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Lang
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface ITerminalExpr : IExpr
    {
        dynamic Value {get;}
    }

    [Free]
    public interface ITerminalExpr<T> : ITerminalExpr
    {
        new T Value {get;}

        dynamic ITerminalExpr.Value
            => Value;
    }
}