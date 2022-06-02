//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct AssetCatalogEntry
    {
        public const string TableId = "assets.catalog";

        public const byte FieldCount = 3;

        [Render(16)]
        public MemoryAddress BaseAddress;

        [Render(8)]
        public ByteSize Size;

        [Render(1)]
        public StringAddress Name;

        public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{16,12,48};
    }
}