//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface IScalarExpr : IExpr
    {

    }

    [Free]
    public interface IScalarExpr<T> : IScalarExpr, IExpr<T>
    {

    }

    [Free]
    public interface IScalarExpr<K,T> : IScalarExpr<T>, IExpr<K,T>
        where K : unmanaged
    {

    }
}