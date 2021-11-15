//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface IProduction : IExpr
    {
        Label Name {get;}
    }

    [Free]
    public interface IProduction<T> : IProduction
        where T : IExpr
    {
        T Term {get;}
    }

    [Free]
    public interface IProduction<K,T> : IProduction<T>
        where T : IExpr
        where K : unmanaged
    {

    }
}