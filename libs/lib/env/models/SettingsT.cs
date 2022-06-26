//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class Settings<K,V> : ReadOnlySeq<Setting<K,V>>, ILookup<K,V>
        where K : unmanaged, INamed<K>
    {
        readonly ConstLookup<K,V> Lookup;

        public Settings()
        {
            Lookup = ConstLookup<K,V>.Empty;
        }

        public Settings(Setting<K,V>[] data)
            : base(data)
        {
            Lookup = data.Select(x => (x.Name,x.Value)).ToDictionary();
        }

        public Settings(Setting<K,V>[] data, Dictionary<K,V> lookup)
            : base(data)
        {
            Lookup = lookup;
        }

        public V Find(K name, V @default)
        {
            var dst = @default;
            Lookup.Find(name, out dst);
            return dst;
        }

        public bool Find(K name, out V dst)
            => Lookup.Find(name, out dst);
    }
}