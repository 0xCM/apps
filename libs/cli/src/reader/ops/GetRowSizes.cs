//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class CliReader
    {
        [Op]
        public Index<TableIndex,byte> GetRowSizes()
        {
            var dst = sys.alloc<byte>(TableCount);
            for(byte i=0; i<TableCount; i++)
                seek(dst,i) = (byte)MD.GetTableRowSize((TableIndex)i);
            return dst;
        }
    }
}