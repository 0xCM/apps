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
        [Op]
        public static ByteSize emit(in MemoryBlock src, FS.FilePath dst)
        {
            using var writer = dst.Writer();
            return emit(src, 0, writer);
        }

        [Op]
        public static ByteSize emit(MemoryBlocks src, FS.FilePath dst)
        {
            using var writer = dst.Writer();
            return emit(src, writer);
        }

        [Op]
        public static ByteSize emit(MemoryBlocks src, StreamWriter dst)
        {
            var blocks = src.View;
            var maxsz = max(blocks).Size;
            var count = blocks.Length;
            var buffer = span<char>(maxsz*2);
            var total = 0u;
            for(var i=0u; i<count;i++)
            {
                buffer.Clear();
                ref readonly var block = ref skip(blocks,i);
                var charcount = Hex.pack(block.View, buffer);
                var formatted = text.format(slice(buffer,0, charcount));
                var size = (uint)block.Size;
                dst.WriteLine(string.Format(HexLine.HexPackPattern, block.BaseAddress, i, size, formatted));
                total += size;
            }
            return total;
        }
    }
}