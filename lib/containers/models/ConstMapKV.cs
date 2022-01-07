//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    using static core;
    using static Root;

    public class ConstMap<K,V>
    {
        readonly Dictionary<K,V> Data;

        public ConstMap(Dictionary<K,V> src)
        {
            Data = src;
        }

        [MethodImpl(Inline)]
        public bool Find(K key, out V value)
            => Data.TryGetValue(key, out value);

        public ICollection<K> Keys
        {
            [MethodImpl(Inline)]
            get => Data.Keys;
        }

        public ICollection<V> Values
        {
            [MethodImpl(Inline)]
            get => Data.Values;
        }

        [MethodImpl(Inline)]
        public static implicit operator ConstMap<K,V>(Dictionary<K,V> src)
            => new ConstMap<K,V>(src);
    }
}