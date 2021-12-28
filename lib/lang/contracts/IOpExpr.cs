//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface IOpExpr : IExpr
    {
        Name OpName {get;}
    }

    [Free]
    public interface IOpExpr<K> : IOpExpr
        where K : unmanaged
    {

    }

    [Free]
    public interface IOpExpr<F,K> : IOpExpr<K>
        where F : IOpExpr<F,K>
        where K : unmanaged
    {

    }
}