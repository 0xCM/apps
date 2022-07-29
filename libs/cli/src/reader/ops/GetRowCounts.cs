//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Arrays;

    partial class CliReader
    {
        [Op]
        public Index<TableIndex,uint> GetRowCounts()
        {
            var values = Symbols.values<TableIndex,uint>();
            var count = values.Count;
            var dst = sys.alloc<uint>(count);
            for(var i=0; i<count; i++)
                seek(dst,i) = (uint)MD.GetTableRowCount(values[i].Key);
            return dst;
        }
    }
}