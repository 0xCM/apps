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

        public static Settings<K,V> load(params Setting<K,V>[] src)
            => new Settings<K,V>(src);

        public Settings()
        {
            Lookup = ConstLookup<K,V>.Empty;
        }

        public Settings(Setting<K,V>[] data)
            : base(data)
        {
            var dst = core.dict<K,V>();
            core.iter(data, s => dst.TryAdd(s.Name,s.Value));
            Lookup = dst;
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

        public override string Delimiter => "\n";

        public override Fence<char>? Fence => null;

        public static new Settings<K,V> Empty => new Settings<K,V>();
    }
}