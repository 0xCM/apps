//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface ITerminalExpr : IValue
    {

    }

    [Free]
    public interface ITerminalExpr<T> : ITerminalExpr, IValue<T>
    {
    }
}