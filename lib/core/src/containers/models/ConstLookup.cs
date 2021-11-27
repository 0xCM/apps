//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Concurrent;
    using System.Runtime.CompilerServices;

    using static Root;

    public class ConstLookup<K,V>
    {
        readonly ConcurrentDictionary<K,V> Storage;

        Index<K> _Keys;

        Index<V> _Values;

        Index<LookupEntry<K,V>> _Entries;

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => _Entries.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => _Entries.IsNonEmpty;
        }

        ConstLookup()
        {
            Storage = new();
            _Keys = sys.empty<K>();
            _Values = sys.empty<V>();
            _Entries = sys.empty<LookupEntry<K,V>>();
        }

        public ConstLookup(ConcurrentDictionary<K,V> src)
        {
            Storage = src;
            _Keys = src.Keys.Array();
            _Values = src.Values.Array();
            _Entries = src.Map(x => new LookupEntry<K,V>(x.Key,x.Value));
        }

        public ConstLookup(Dictionary<K,V> src)
        {
            Storage = src.ToConcurrentDictionary();
            _Keys = src.Keys.Array();
            _Values = src.Values.Array();
            _Entries = src.Map(x => new LookupEntry<K,V>(x.Key,x.Value));
        }

        public ReadOnlySpan<K> Keys
        {
            [MethodImpl(Inline)]
            get => _Keys.View;
        }

        public ReadOnlySpan<V> Values
        {
            [MethodImpl(Inline)]
            get => _Values.View;
        }

        public ReadOnlySpan<LookupEntry<K,V>> Entries
        {
            [MethodImpl(Inline)]
            get => _Entries.View;
        }

        public uint EntryCount
        {
            [MethodImpl(Inline)]
            get => _Entries.Count;
        }

        [MethodImpl(Inline)]
        public bool Find(K key, out V value)
            => Storage.TryGetValue(key, out value);

        public static ConstLookup<K,V> Empty => new();


        public static implicit operator ConstLookup<K,V>(Dictionary<K,V> src)
            => new ConstLookup<K,V>(src);

        public static implicit operator ConstLookup<K,V>(ConcurrentDictionary<K,V> src)
            => new ConstLookup<K,V>(src);

    }
}