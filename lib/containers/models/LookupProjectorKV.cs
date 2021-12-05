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

    public class LookupProjector<K,V>
    {
        readonly ConcurrentDictionary<K,LookupProjectorEntry<K,V>> Storage;

        object locker;

        ConstLookupProjector<K,V> _Const;

        public LookupProjector()
        {
            Storage = new();
            locker = new();
            _Const = ConstLookupProjector<K,V>.Empty;
        }

        public ConstLookupProjector<K,V> Seal()
        {
            lock(locker)
            {
                if(_Const.IsEmpty)
                    _Const = new(Storage.Values.Array());
            }
            return _Const;
        }

        [MethodImpl(Inline)]
        public bool Include(K key, V value, ISFxProjector projector)
            =>  _Const.IsNonEmpty ? false : Storage.TryAdd(key, new LookupProjectorEntry<K,V>(key,value, projector));
    }
}