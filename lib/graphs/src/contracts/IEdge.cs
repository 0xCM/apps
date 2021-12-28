//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface IEdge : IExpr
    {
        Name Name {get;}
    }

    [Free]
    public interface IEdge<V> : IEdge
    {
        V Source {get;}

        V Target {get;}
    }
}