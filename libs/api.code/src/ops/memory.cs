//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Algs;
    using static Spans;
    using static Arrays;

    partial class ApiCode
    {
        public static MemoryBlocks memory(ReadOnlySpan<ApiCodeRow> src)
        {
            var count = src.Length;
            var dst = sys.alloc<MemoryBlock>(count);
            for(var i=0; i<count; i++)
                seek(dst,i) = memory(skip(src,i));
            return dst;
        }

        [Op]
        public static MemoryBlocks memory(ReadOnlySpan<ApiCodeBlock> src)
        {
            var count = src.Length;
            if(count == 0)
                return MemoryBlocks.Empty;
            var dst = sys.alloc<MemoryBlock>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var code = ref skip(src,i);
                seek(dst,i) = new MemoryBlock(code.AddressRange, code.Encoded);
            }

            dst.Sort();
            return new MemoryBlocks(dst);
        }

        [MethodImpl(Inline), Op]
        static MemoryBlock memory(in ApiCodeRow src)
            => new MemoryBlock(new MemoryRange(src.Address, src.Address + src.Data.Size), src.Data);
    }
}