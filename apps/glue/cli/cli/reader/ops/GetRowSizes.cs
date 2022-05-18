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
            var buffer = alloc<byte>(TableCount);
            ref var dst = ref first(buffer);
            for(byte i=0; i<TableCount; i++)
            {
               try
               {
                    seek(dst,i) = (byte)MD.GetTableRowSize((TableIndex)i);
               }
               catch(Exception)
               {

               }
            }
            return buffer;
        }
    }
}