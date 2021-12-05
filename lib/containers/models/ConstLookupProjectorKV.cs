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

    public class ConstLookupProjector<K,V>
    {
        readonly ConcurrentDictionary<K,V> ValueLookup;

        readonly ConcurrentDictionary<K,ISFxProjector> ProjectorLookup;

        Index<K> _Keys;

        Index<V> _Values;

        Index<LookupProjectorEntry<K,V>> _Entries;

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

        ConstLookupProjector()
        {
            ValueLookup = new();
            _Keys = sys.empty<K>();
            _Values = sys.empty<V>();
            _Entries = sys.empty<LookupProjectorEntry<K,V>>();
            ProjectorLookup = new();
        }

        public ConstLookupProjector(LookupProjectorEntry<K,V>[] src)
        {
            _Entries = src;
            ValueLookup = src.Map(x => (x.Key, x.Value)).ToConcurrentDictionary();
            ProjectorLookup = src.Map(x => (x.Key, x.Projector)).ToConcurrentDictionary();
            _Keys = src.Map(x => x.Key);
            _Values = src.Map(x => x.Value);
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

        public ReadOnlySpan<LookupProjectorEntry<K,V>> Entries
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
            => ValueLookup.TryGetValue(key, out value);

        public bool Project<T>(K key, out T value)
        {
            var result = false;
            value = default;
            if(Find(key, out var  x))
            {
                if(ProjectorLookup.TryGetValue(key, out var projector))
                {
                    value = projector.Invoke(x);
                    result = true;
                }
            }

            return result;
        }

        public static ConstLookupProjector<K,V> Empty => new();
    }
}