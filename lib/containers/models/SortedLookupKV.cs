//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    internal interface ILookupData<K,V>
    {
        ConcurrentDictionary<K,V> Storage {get;}

        Index<K> Keys{get;}

        Index<V> Values {get;}
    }

    public class SortedLookup<K,V>
        where K : IComparable<K>
    {
        readonly ConcurrentDictionary<K,V> Storage;

        Index<K> _Keys;

        Index<V> _Values;

        Index<SortedLookupEntry<K,V>> _Entries;

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

        SortedLookup()
        {
            Storage = new();
            _Keys = sys.empty<K>();
            _Values = sys.empty<V>();
            _Entries = sys.empty<SortedLookupEntry<K,V>>();
        }

        public SortedLookup(ConcurrentDictionary<K,V> src)
        {
            Storage = src;
            _Keys = src.Keys.Array().Sort();
            _Values = src.Values.Array();
            _Entries = Storage.Map(x => new SortedLookupEntry<K,V>(x.Key,x.Value)).Sort();
        }

        public SortedLookup(Dictionary<K,V> src)
        {
            Storage = src.ToConcurrentDictionary();
            _Keys = src.Keys.Array().Sort();
            _Values = src.Values.Array();
            _Entries = Storage.Map(x => new SortedLookupEntry<K,V>(x.Key,x.Value)).Sort();
        }

        internal SortedLookup(ILookupData<K,V> src)
        {
            Storage = src.Storage;
            _Keys = src.Keys.Sort();
            _Values = src.Values;
            _Entries = Storage.Map(x => new SortedLookupEntry<K,V>(x.Key,x.Value)).Sort();
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

        public ReadOnlySpan<SortedLookupEntry<K,V>> Entries
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
        public bool ContainsKey(K key)
            => Storage.ContainsKey(key);

        public V this[K key]
        {
            [MethodImpl(Inline)]
            get => Storage[key];
        }

        public ref readonly V this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref _Values[index];
        }

        public ref readonly V this[int index]
        {
            [MethodImpl(Inline)]
            get => ref _Values[index];
        }

        [MethodImpl(Inline)]
        public bool Find(K key, out V value)
            => Storage.TryGetValue(key, out value);

        public Index<T> MapValues<T>(Func<V,T> f)
            => _Values.Map(f);

        public Index<T> MapKeys<T>(Func<K,T> f)
            => _Keys.Map(f);

        public Index<T> MapEntries<T>(Func<SortedLookupEntry<K,V>,T> f)
            => _Entries.Map(f);

        public static SortedLookup<K,V> Empty => new();

        public static implicit operator SortedLookup<K,V>(Dictionary<K,V> src)
            => new SortedLookup<K,V>(src);

        public static implicit operator SortedLookup<K,V>(ConcurrentDictionary<K,V> src)
            => new SortedLookup<K,V>(src);
    }
}