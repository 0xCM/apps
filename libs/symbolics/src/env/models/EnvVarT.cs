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
    public readonly record struct EnvVar<T> : IComparable<EnvVar<T>>, IHashed
        where T : IEquatable<T>
    {
        const string TableId = "env.vars.{0}";

        public readonly SettingName<asci64> Name;

        public readonly T Value;

        [MethodImpl(Inline)]
        public EnvVar(asci64 name, T value)
        {
            Name = name;
            Value = value;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => core.hash(Format());
        }

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
    }
}