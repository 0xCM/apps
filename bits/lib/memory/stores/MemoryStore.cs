//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.IO;
    using System.Linq;

    using static core;

    [ApiHost]
    public readonly struct MemoryStore
    {
        public static MemoryStore Service => default;

        const string HexPackLine = "x{0:x}[{1:D5}:{2:D5}]=<{3}>";

        const string ArrayPackLine = "x{0:x}[{1:D5}:{2:D5}]={3}";

        [Op]
        public static MemoryBlocks pack(MemoryBlock src)
            => new MemoryBlocks(core.array(src));

        [Op]
        public static MemoryBlocks pack(Index<MemoryBlock> src)
        {
            var count = src.Length;
            if(count == 0)
                return MemoryBlocks.Empty;
            src.Sort();
            return new MemoryBlocks(src);
        }

        [Op]
        public static ByteSize emit(Index<MemorySeg> src, StreamWriter dst)
        {
            var count = src.Count;
            var bufferSize = src.Select(x => x.Size).Max()*2;
            var buffer = span<char>(bufferSize);
            var total = 0u;
            var segs = src.View;
            for(var i=0u; i<count;i++)
            {
                buffer.Clear();
                ref readonly var seg = ref skip(segs,i);
                var charcount = Hex.charpack(seg.View, buffer);
                var formatted = text.format(slice(buffer,0, charcount));
                var size = (uint)seg.Size;
                dst.WriteLine(string.Format(HexPackLine, seg.BaseAddress, i, size, formatted));
                total += size;
            }
            return total;
        }

        [Op]
        public static ByteSize emit(MemorySeg src, uint bpl, StreamWriter dst)
        {
            var div = src.Length/bpl;
            var mod = src.Length % bpl;
            var count = div + (mod != 0 ? 1 : 0);
            var buffer = alloc<MemorySeg>(count);
            ref var target = ref first(buffer);
            var @base = src.BaseAddress;
            var offset = MemoryAddress.Zero;
            for(var i=0; i<div; i++)
            {
                seek(target,i) = new MemorySeg(@base + offset, bpl);
                offset += bpl;
            }
            if(mod !=0)
                seek(target, div) = new MemorySeg(@base + offset, mod);
            return emit(buffer, dst);
        }

        [Op]
        public static ByteSize emit(in MemoryBlocks src, StreamWriter dst)
        {
            var blocks = src.View;
            var maxsz = memory.maxblock(blocks).Size;
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
                dst.WriteLine(string.Format(HexPackLine, block.BaseAddress, i, size, formatted));
                total += size;
            }
            return total;
        }

        [Op]
        public static string linepack(in MemorySeg src, uint index, Span<char> buffer)
        {
            var memspan = src.ToSpan();
            var count = Hex.charpack(memspan.View, buffer);
            var chars = slice(buffer, 0, count);
            return string.Format(HexPackLine, memspan.BaseAddress, index, (uint)memspan.Size, text.format(chars));
        }

        [Op]
        public static string arraypack(in MemorySeg src, uint index, Span<char> buffer)
        {
            var memory = src.ToSpan();
            var count = Hex.hexarray(memory.View, buffer);
            var chars = slice(buffer, 0, count);
            return string.Format(ArrayPackLine, memory.BaseAddress, index, (uint)memory.Size, text.format(chars));
        }

        [Op]
        public static string arraypack(in MemoryBlock src, uint index, Span<char> buffer)
        {
            var memory = src.View;
            var count = Hex.hexarray(memory, buffer);
            var chars = slice(buffer, 0, count);
            return string.Format(ArrayPackLine, src.BaseAddress, index, (uint)src.Size, text.format(chars));
        }

        [MethodImpl(Inline), Op]
        public ReadOnlySpan<byte> Load(MemorySeg src)
            => src.Load();

        [MethodImpl(Inline), Op]
        public ReadOnlySpan<byte> Load(ReadOnlySpan<MemorySeg> src, MemorySlot n)
            => MemorySegs.load(src,n);

        [MethodImpl(Inline), Op]
        public ref readonly byte Cell(ReadOnlySpan<MemorySeg> src, MemorySlot n, int i)
            => ref MemorySegs.cell(src,n,i);

        [MethodImpl(Inline)]
        public ulong Sib(ReadOnlySpan<MemorySeg> refs, in MemorySlot n, int i, byte scale, ushort offset)
            => MemorySegs.sib(refs, n, i, scale, offset);
    }
}