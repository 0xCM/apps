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
            var buffer = alloc<uint>(TableCount);
            ref var dst = ref first(buffer);
            for(byte i=0; i<TableCount; i++)
            {
               seek(dst,i) = (uint)MD.GetTableRowCount((TableIndex)i);
            }
            return buffer;
        }
    }
}