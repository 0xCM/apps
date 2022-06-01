//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;

    partial class ApiCode
    {
        public static MemoryBlocks memory(FS.FilePath src)
        {
            var dst = MemoryBlocks.Empty;
            var result = Outcome<MemoryBlocks>.Success;
            var unpacked = Outcome<ByteSize>.Success;
            var size  = ByteSize.Zero;
            var buffer = list<MemoryBlock>();
            var counter = z16;
            using var reader = src.AsciReader();
            var data = reader.ReadLine();
            var block = MemoryBlock.Empty;
            while(result.Ok && text.nonempty(data))
            {
                unpacked = ApiHexPacks.parse(counter++, data, out block);
                if(unpacked.Fail)
                {
                    result = (false, unpacked.Message);
                    Errors.Throw(unpacked.Message);
                }
                else
                {
                    buffer.Add(block);
                    size += unpacked.Data;
                    data = reader.ReadLine();
                }
            }

            dst = buffer.ToArray();
            return dst;
        }

        public static MemoryBlocks memory(ReadOnlySpan<ApiMemberExtract> src)
        {
            var count = src.Length;
            if(count == 0)
                return MemoryBlocks.Empty;
            var dst = alloc<MemoryBlock>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var code = ref skip(src,i);
                var encoded = code.Block.Encoded;
                seek(dst,i) = new MemoryBlock(code.Origin, encoded);
            }

            dst.Sort();
            return new MemoryBlocks(dst);
        }

        [MethodImpl(Inline), Op]
        public static MemoryBlock memory(in ApiMemberExtract src)
            => new MemoryBlock(src.Block.Origin, src.Block.Encoded);

        [MethodImpl(Inline), Op]
        public static MemoryBlock memory(in ApiHexRow src)
            => new MemoryBlock(new MemoryRange(src.Address, src.Address + src.Data.Size), src.Data);

        public static MemoryBlocks memory(ReadOnlySpan<ApiHexRow> src)
        {
            var count = src.Length;
            var dst = alloc<MemoryBlock>(count);
            for(var i=0; i<count; i++)
                seek(dst,i) = memory(skip(src,i));
            return dst;
        }
    }
}