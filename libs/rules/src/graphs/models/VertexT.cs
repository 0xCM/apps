//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed record class Vertex<T>
        where T : IDataType, IExpr
    {
        public T Value {get;}

        public DataList<Vertex<T>> Targets {get;}

        [MethodImpl(Inline)]
        public Vertex(T value)
        {
            Value = value;
            Targets = new();
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Value.Hash;
        }
        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Value.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Value.IsNonEmpty;
        }

        public string Format()
            => Value.Format();

        [MethodImpl(Inline)]
        public bool Equals(Vertex<T> src)
            => Value.Equals(src.Value);

        public override string ToString()
            => Format();

        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public static implicit operator Vertex<T>(T key)
            => new Vertex<T>(key);

        [MethodImpl(Inline)]
        public static implicit operator Vertex(Vertex<T> src)
            => new Vertex(src.Value);
    }
}