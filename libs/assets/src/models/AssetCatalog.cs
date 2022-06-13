//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class AssetCatalog
    {
        readonly Index<AssetCatalogEntry> Data;

        [MethodImpl(Inline)]
        public AssetCatalog(AssetCatalogEntry[] src)
        {
            Data = src;
        }

        public ref readonly Index<AssetCatalogEntry> Entries
        {
            [MethodImpl(Inline)]
            get => ref Data;
        }

        public ref AssetCatalogEntry this[uint i]
        {
            [MethodImpl(Inline)]
            get => ref Data[i];
        }

        public ref AssetCatalogEntry this[int i]
        {
            [MethodImpl(Inline)]
            get => ref Data[i];
        }

        public uint EntryCount
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        [MethodImpl(Inline)]
        public static implicit operator AssetCatalog(AssetCatalogEntry[] src)
            => new AssetCatalog(src);
    }
}