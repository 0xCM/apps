//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IVertex : IExpr
    {
        object Value {get;}

        DataList<Vertex> Targets {get;}
    }

    [Free]
    public interface IVertex<V> : IVertex
        where V : IEquatable<V>
    {
        new V Value {get;}

        new DataList<Vertex<V>> Targets {get;}

        object IVertex.Value
            => Value;

        DataList<Vertex> IVertex.Targets
            => new DataList<Vertex>(Targets.Map(x => (Vertex)x));
    }
}