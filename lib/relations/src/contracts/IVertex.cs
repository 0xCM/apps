//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface IVertex : IExpr
    {

    }

    [Free]
    public interface IVertex<V,T> : IVertex, IEquatable<V>, IComparable<V>
        where V : struct, IVertex<V,T>
        where T : unmanaged
    {
        T Key {get;}
    }

    [Free]
    public interface IVertex<V,K,T> : IVertex<V,T>
        where V : struct, IVertex<V,K,T>
        where K : unmanaged
        where T : unmanaged
    {
        K Kind {get;}
    }

    [Free]
    public interface IVertex<V,P,K,T> : IVertex<V,K,T>
        where V : struct, IVertex<V,P,K,T>
        where K : unmanaged
        where T : unmanaged
    {
        P Value {get;}
    }
}