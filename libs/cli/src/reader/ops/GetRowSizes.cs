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
        public Index<TableIndex,byte> GetRowSizes()
        {
            var values = Symbols.values<TableIndex,byte>();
            var count = values.Count;
            var dst = sys.alloc<byte>(count);
            for(byte i=0; i<count; i++)
            {
                try
                {
                    seek(dst,i) = (byte)MD.GetTableRowSize(values[i].Key);
                }
                catch(Exception)
                {
                    term.emit(Events.error(typeof(CliReader), $"Index {i} out of range"));
                }
            }
            return dst;
        }
    }
}