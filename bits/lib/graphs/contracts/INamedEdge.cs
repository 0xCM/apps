//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface INamedEdge : IEdge, INamed
    {

    }

    public interface INamedEdge<V> : INamedEdge, IEdge<V>
    {

    }
}