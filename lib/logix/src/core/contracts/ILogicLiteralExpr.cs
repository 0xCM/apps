//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ILogicLiteralExpr : ILogicExpr, ILiteralExpr
    {
        bool Value {get;}
    }

    public interface ILogicLiteralExpr<T> : ILogicLiteralExpr, ILogicExpr<T>
        where T : unmanaged
    {

    }
}