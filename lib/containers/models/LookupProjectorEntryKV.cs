//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct LookupProjectorEntry<K,V>
    {
        public readonly K Key;

        public readonly V Value;

        internal readonly ISFxProjector Projector;

        [MethodImpl(Inline)]
        public LookupProjectorEntry(K key, V value, ISFxProjector projector)
        {
            Key = key;
            Value = value;
            Projector = projector;
        }

        [MethodImpl(Inline)]
        public T Project<T>()
            => Projector.Invoke(Value);

        [MethodImpl(Inline)]
        public static implicit operator LookupProjectorEntry<K,V>((K key, V value, ISFxProjector projector) src)
            => new LookupProjectorEntry<K,V>(src.key, src.value, src.projector);
    }
}