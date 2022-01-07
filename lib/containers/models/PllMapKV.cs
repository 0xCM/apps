//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    using static core;
    using static Root;

    public class PllMap<K,V>
    {
        readonly ConcurrentDictionary<K,V> Data;

        public PllMap()
        {
            Data = new();
        }

        [MethodImpl(Inline)]
        public PllMap(ConcurrentDictionary<K,V> src)
        {
            Data = src;
        }

        [MethodImpl(Inline)]
        public bool Include(K key, V value)
            => Data.TryAdd(key,value);

        [MethodImpl(Inline)]
        public V GetOrAdd(K key, Func<K,V> f)
            => Data.GetOrAdd(key,f);

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
        public static implicit operator PllMap<K,V>(ConcurrentDictionary<K,V> src)
            => new PllMap<K,V>(src);

        [MethodImpl(Inline)]
        public static implicit operator ConcurrentDictionary<K,V>(PllMap<K,V> src)
            => src.Data;
    }
}