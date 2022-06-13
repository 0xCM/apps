//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct AssetCatalogEntry
    {
        const string TableId = "assets.catalog";

        [Render(16)]
        public MemoryAddress BaseAddress;

        [Render(8)]
        public ByteSize Size;

        [Render(1)]
        public StringAddress Name;
    }
}