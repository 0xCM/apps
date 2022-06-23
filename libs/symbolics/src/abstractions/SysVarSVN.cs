//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class SysVar<S,N,V> : ISysVar<N,V>
        where S : SysVar<S,N,V>
        where N : unmanaged, INamed<N>
        where V : IEquatable<V>, IComparable<V>, new()
    {
        public N Name  {get; private set;}

        public V Value;

        protected SysVar(N name)
        {
            Name = name;
            Value = new();
        }

        protected SysVar(N name, V value)
        {
            Name = name;
            Value = value;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Name.Hash | (Hash32)Name.GetHashCode();
        }

        public override int GetHashCode()
            => Hash;

        protected virtual char Sep => Chars.Eq;

        public string Format()
            => $"{Name}{Sep}{Value}";

        public override string ToString()
            => Format();

        public bool Equals(SysVar<S,N,V> src)
            => Name.Equals(src.Name) && Value.Equals(src.Value);

        public int CompareTo(SysVar<S,N,V> src)
            => Name.CompareTo(src.Name);

        V ISysVar<V>.Value
            => Value;

    }
}