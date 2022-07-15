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
        public Index<TableIndex,uint> GetRowCounts()
        {
            var dst = sys.alloc<uint>(TableCount);
            for(byte i=0; i<TableCount; i++)
               seek(dst,i) = (uint)MD.GetTableRowCount((TableIndex)i);
            return dst;
        }
    }
}