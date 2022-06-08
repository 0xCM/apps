//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------

namespace Z0
{
    public static partial class XTend
    {
        [Op]
        public static AsciLineReader AsciLineReader(this FS.FilePath src)
            => new AsciLineReader(src.AsciReader());

        [Op]
        public static UnicodeLineReader UnicodeLineReader(this FS.FilePath src)
            => new UnicodeLineReader(src.UnicodeReader());

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
