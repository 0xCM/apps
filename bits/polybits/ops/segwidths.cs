//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct BfDatasets
    {
        public static Index<byte> segwidths(in asci64 src)
        {
            var fields = BfDatasets.indicators(src);
            var count = fields.Length;
            var buffer = alloc<byte>(count);
            for(var i=0; i<count; i++)
                seek(buffer,i) = (byte)fields[i].Length;
            return buffer;
        }
    }
}