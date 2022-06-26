//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class Settings<K,V> : ReadOnlySeq<Setting<K,V>>, ILookup<K,Setting<K,V>>
        where K : unmanaged, INamed<K>
    {
        readonly ConstLookup<K,Setting<K,V>> Lookup;

        public Settings()
        {
            Lookup = ConstLookup<K,Setting<K,V>>.Empty;

        }

        public Settings(Setting<K,V>[] data)
            : base(data)
        {
            Lookup = data.Select(x => (x.Name,x)).ToDictionary();
        }

        public Settings(Setting<K,V>[] data, Dictionary<K,Setting<K,V>> lookup)
            : base(data)
        {
            Lookup = lookup;
        }

        public bool Find(K name, out Setting<K,V> dst)
            => Lookup.Find(name, out dst);
    }
}