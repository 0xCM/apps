//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class AssetCatalog : ReadOnlySeq<AssetCatalogEntry>
    {
        [MethodImpl(Inline)]
        public AssetCatalog(AssetCatalogEntry[] src)
            : base(src)
        {
            Data = src;
        }

        [MethodImpl(Inline)]
        public static implicit operator AssetCatalog(AssetCatalogEntry[] src)
            => new AssetCatalog(src);
    }
}