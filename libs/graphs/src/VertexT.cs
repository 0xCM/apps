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
    [Free]
    public interface INamedVertex : IVertex, INamed
    {

    }

    [Free]
    public interface INamedVertex<V> : INamedVertex, IVertex<V>
        where V : IEquatable<V>

    {
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

    public class Vertex<T> : IVertex<T>
        where T : IEquatable<T>
    {
        public T Value {get;}

        public DataList<Vertex<T>> Targets {get;}

        [MethodImpl(Inline)]
        public Vertex(T value)
        {
            Value = value;
            Targets = new();
        }

        public string Format()
            => Value.ToString();

        [MethodImpl(Inline)]
        public bool Equals(Vertex<T> src)
            => Value.Equals(src.Value);

        public override string ToString()
            => Format();

        public override int GetHashCode()
            => Value.GetHashCode();

        public override bool Equals(object src)
            => src is Vertex<T> v && Equals(v);

        [MethodImpl(Inline)]
        public static implicit operator Vertex<T>(T key)
            => new Vertex<T>(key);

        [MethodImpl(Inline)]
        public static implicit operator Vertex(Vertex<T> src)
            => new Vertex(src.Value);

        [MethodImpl(Inline)]
        public static bool operator ==(Vertex<T> a, Vertex<T> b)
            => a.Equals(b);

        [MethodImpl(Inline)]
        public static bool operator !=(Vertex<T> a, Vertex<T> b)
            => !a.Equals(b);
    }
}