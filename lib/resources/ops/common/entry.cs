//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Resources
    {
        [MethodImpl(Inline), Op]
        public static AssetCatalogEntry entry(in Asset src)
        {
            AssetCatalogEntry dst = new();
            dst.BaseAddress = src.Address;
            dst.Name = src.Name.Format();
            dst.Size = src.Size;
            return dst;
        }
    }
}