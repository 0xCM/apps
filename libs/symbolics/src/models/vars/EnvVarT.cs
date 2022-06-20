//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines a value-parametric environment variable
    /// </summary>
    [Record(TableId)]
    public readonly record struct EnvVar<T> : IVar<AsciName<asci32>,T>
        where T : IEquatable<T>
    {
        const string TableId = "env.vars.{0}";

        public readonly AsciName<asci32> Name;

        public readonly T Value;

        [MethodImpl(Inline)]
        public EnvVar(asci32 name, T value)
        {
            Name = name;
            Value = value;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => core.hash(Format());
        }

        AsciName<asci32> IVar<AsciName<asci32>,T>.Name
            => Name;

        T IVar<T>.Value
            => Value;

        Name INamed.Name
            => Name.Format();

        public override int GetHashCode()
            => Hash;

        public string Format()
            => $"{Name}={Value}";

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public int CompareTo(EnvVar<T> src)
            => Name.CompareTo(src.Name);

        [MethodImpl(Inline)]
        public bool Equals(EnvVar<T> src)
            => Name.Equals(src.Name) && Value.Equals(src.Value);

        public bool Equals(AsciName<asci32> other)
        {
            throw new NotImplementedException();
        }

        public int CompareTo(AsciName<asci32> other)
        {
            throw new NotImplementedException();
        }
    }
}