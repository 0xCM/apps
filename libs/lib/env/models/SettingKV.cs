//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct Setting<K,V> : ISetting<K,V>, IComparable<Setting<K,V>>
        where K : unmanaged, INamed<K>
    {
        public readonly K Name;

        public readonly V Value;

        [MethodImpl(Inline)]
        public Setting(K name, V value)
        {
            Name = name;
            Value = value;
        }

        public string Format(char sep)
            => $"{Name}{sep}{Value}";

        public int CompareTo(Setting<K,V> src)
            => Name.CompareTo(src.Name);

        K ISetting<K,V>.Name
            => Name;

        V ISetting<V>.Value
            => Value;

        public static Setting<K,V> Empty => default;

    }
}