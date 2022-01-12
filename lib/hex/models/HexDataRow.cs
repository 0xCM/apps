//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Root;
    using static core;

    using System.Runtime.InteropServices;
    using System.Runtime.CompilerServices;

    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct HexDataRow
    {
        public const string TableId = "hex.dat";

        public MemoryAddress Address;

        public BinaryCode Data;

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Data.IsEmpty;
        }

        public static HexDataRow Empty
        {
            [MethodImpl(Inline)]
            get
            {
                var empty = new HexDataRow();
                empty.Data = BinaryCode.Empty;
                return empty;
            }
        }
    }

    partial class XTend
    {
        public static ByteSize TotalSize(this HexDataRow[] src)
            => src.Select(x => x.Data.Count).Sum();

        public static ByteSize TotalSize(this Index<HexDataRow> src)
            => src.Storage.TotalSize();

        public static BinaryCode Compact(this HexDataRow[] src)
        {
            var count = src.Length;
            if(count == 0)
                return BinaryCode.Empty;

            var size = src.TotalSize();
            var buffer = alloc<byte>(size);
            var dst = span(buffer);
            var offset = 0u;
            for(var i=0; i<count; i++)
            {
                var data = skip(src,i).Data.View;
                for(var j=0; j<data.Length; j++)
                    seek(dst,offset++) = skip(data,j);

            }
            return buffer;
        }

        public static BinaryCode Compact(this Index<HexDataRow> src)
            => src.Storage.Compact();
    }
}