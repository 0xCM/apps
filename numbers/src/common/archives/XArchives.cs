//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XTend
    {
        public static IRuntimeArchive RuntimeArchive(this Assembly src)
            => Z0.RuntimeArchive.create(src);

        public static ByteSize TotalSize(this HexDataRow[] src)
            => src.Select(x => x.Data.Count).Sum();

        public static ByteSize TotalSize(this Index<HexDataRow> src)
            => src.Storage.TotalSize();

        public static BinaryCode Compact(this HexDataRow[] src)
            => HexEmitter.compact(src);

        public static BinaryCode Compact(this Index<HexDataRow> src)
            => src.Storage.Compact();
    }
}