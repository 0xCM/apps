//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Collections.Concurrent;
    using System.Runtime.CompilerServices;

    using static Root;

    public class Lookup<K,V>
    {
        readonly ConcurrentDictionary<K,V> Storage;

        Index<K> _Keys;

        Index<V> _Values;

        Index<LookupEntry<K,V>> _Entries;

        bool Sealed;

        object locker;

        public Lookup()
        {
            Storage = new();
            Sealed = false;
            locker = new();
            _Keys = sys.empty<K>();
            _Values = sys.empty<V>();
        }

        public Lookup<K,V> Seal()
        {
            lock(locker)
            {
                if(!Sealed)
                {
                    Sealed = true;
                    _Keys = Storage.Keys.Array();
                    _Values = Storage.Values.Array();
                    _Entries = Storage.Map(x => new LookupEntry<K,V>(x.Key,x.Value));
                }
            }
            return this;
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
        public bool Add(K key, V value)
            =>  Sealed ? false : Storage.TryAdd(key,value);

        [MethodImpl(Inline)]
        public bool Find(K key, out V value)
        {
            if(Sealed)
            {
                value = default;
                return false;
            }
            else
                return Storage.TryGetValue(key, out value);
        }
    }
}