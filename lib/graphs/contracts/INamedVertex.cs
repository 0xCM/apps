//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface INamedVertex : IVertex, INamed
    {

    }

    [Free]
    public interface INamedVertex<V> : INamedVertex, IVertex<V>
        where V : IEquatable<V>

    {
    }
}