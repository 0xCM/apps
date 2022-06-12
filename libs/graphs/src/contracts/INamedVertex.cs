//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
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