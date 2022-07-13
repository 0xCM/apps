//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct Setting<K,V> : ISetting<K,V>, IComparable<Setting<K,V>>
        where K : unmanaged, IExpr, IDataType<K>
    {
        public readonly K Name;

        public readonly V Value;

        [MethodImpl(Inline)]
        public Setting(K name, V value)
        {
            Name = name;
            Value = value;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Name.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Name.IsEmpty;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => HashCodes.combine(Name.Hash, HashCodes.hash(Value));
        }

        public string Format(char sep)
            => $"{Name}{sep}{Value}";

        public int CompareTo(Setting<K,V> src)
            => Name.CompareTo(src.Name);

        public override int GetHashCode()
            => Hash;

        public string Format()
            => Format(Chars.Eq);

        public override string ToString()
            => Format();

        K INamed<K>.Name
            => Name;

        V ISetting<V>.Value
            => Value;

        public static Setting<K,V> Empty => default;
    }
}