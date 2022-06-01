//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using System.IO;

    partial class ApiCode
    {
        [Op]
        public static ByteSize hexpack(in MemoryBlocks src, StreamWriter dst)
        {
            var blocks = src.View;
            var maxsz = Z0.memory.maxblock(blocks).Size;
            var count = blocks.Length;
            var buffer = span<char>(maxsz*2);
            var total = 0u;
            for(var i=0u; i<count;i++)
            {
                buffer.Clear();
                ref readonly var block = ref skip(blocks,i);
                var charcount = Hex.charpack(block.View, buffer);
                var formatted = text.format(slice(buffer,0, charcount));
                var size = (uint)block.Size;
                dst.WriteLine(string.Format(HexLine.HexPackPattern, block.BaseAddress, i, size, formatted));
                total += size;
            }
            return total;
        }

        [Op]
        public static ByteSize hexpack(in MemoryBlock block, uint index, StreamWriter dst)
        {
            var data = block.View;
            var size = (uint)data.Length;
            var buffer = alloc<char>(data.Length*2);
            Hex.charpack(data, buffer);
            dst.WriteLine(string.Format(HexLine.HexPackPattern, block.BaseAddress, index, size, text.format(buffer)));
            return size;
        }

        [Op]
        public static string hexpack(in MemorySeg src, uint index, Span<char> buffer)
        {
            var memspan = src.ToSpan();
            var count = Hex.charpack(memspan.View, buffer);
            var chars = slice(buffer, 0, count);
            return string.Format(HexLine.HexPackPattern, memspan.BaseAddress, index, (uint)memspan.Size, text.format(chars));
        }

        [Op]
        public static ByteSize hexpack(MemorySeg src, uint bpl, StreamWriter dst)
        {
            var div = src.Length/bpl;
            var mod = src.Length % bpl;
            var count = div + (mod != 0 ? 1 : 0);
            var buffer = alloc<MemorySeg>(count);
            var @base = src.BaseAddress;
            var offset = MemoryAddress.Zero;
            for(var i=0; i<div; i++)
            {
                seek(buffer,i) = new MemorySeg(@base + offset, bpl);
                offset += bpl;
            }
            if(mod !=0)
                seek(buffer, div) = new MemorySeg(@base + offset, mod);
            return hexpack(buffer, dst);
        }

        [Op]
        public static ByteSize hexpack(Index<MemorySeg> src, StreamWriter dst)
        {
            var buffer = span<char>(src.Select(x => (uint)x.Size).Storage.Max()*2);
            var total = 0u;
            for(var i=0u; i<src.Count;i++)
            {
                buffer.Clear();
                ref readonly var seg = ref src[i];
                var charcount = Hex.charpack(seg.View, buffer);
                var formatted = text.format(slice(buffer,0, charcount));
                var size = (uint)seg.Size;
                dst.WriteLine(string.Format(HexLine.HexPackPattern, seg.BaseAddress, i, size, formatted));
                total += size;
            }
            return total;
        }
    }
}