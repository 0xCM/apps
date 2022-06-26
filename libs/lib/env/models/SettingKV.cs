//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct Setting<K,V>
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

        public string Format()
            => $"{Name}={Value}";

        public override string ToString()
            => Format();

        public static Setting<K,V> Empty => default;
    }
}