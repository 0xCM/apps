//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.InteropServices;

    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct AssetCatalogEntry : IRecord<AssetCatalogEntry>
    {
        public const string TableId = "assets.catalog";

        public const byte FieldCount = 3;

        public MemoryAddress BaseAddress;

        public ByteSize Size;

        public StringAddress Name;

        public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{16,12,48};
    }
}