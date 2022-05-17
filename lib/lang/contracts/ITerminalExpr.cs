//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface ITerminalExpr : IValue
    {

    }

    [Free]
    public interface ITerminalExpr<T> : ITerminalExpr, IValue<T>
    {
    }
}