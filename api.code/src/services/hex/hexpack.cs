//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.IO;

    using static core;

    partial class ApiHex
    {
        [Op]
        public static ByteSize pack(in MemoryBlocks src, StreamWriter dst)
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
        public static ByteSize pack(in MemoryBlock block, uint index, StreamWriter dst)
        {
            var data = block.View;
            var size = (uint)data.Length;
            var buffer = alloc<char>(data.Length*2);
            Hex.charpack(data, buffer);
            dst.WriteLine(string.Format(HexLine.HexPackPattern, block.BaseAddress, index, size, text.format(buffer)));
            return size;
        }

        [Op]
        public static string pack(in MemorySeg src, uint index, Span<char> dst)
        {
            var memspan = src.ToSpan();
            var count = Hex.charpack(memspan.View, dst);
            var chars = slice(dst, 0, count);
            return string.Format(HexLine.HexPackPattern, memspan.BaseAddress, index, (uint)memspan.Size, text.format(chars));
        }

        [Op]
        public static ByteSize pack(ReadOnlySpan<ApiCodeBlock> src, Span<ApiHexPack> dst, Span<char> buffer)
        {
            var count = (uint)min(src.Length, dst.Length);
            var size = 0ul;
            for(var i=0u; i<count; i++)
            {
                ref readonly var block = ref skip(src,i);
                buffer.Clear();
                ref var package = ref seek(dst,i);
                package.Index = i;
                package.Address = block.BaseAddress;
                package.Size = block.Size;
                package.Data = text.format(slice(buffer,0, Hex.charpack(block.Bytes, buffer)));
                size += package.Size;
            }
            return size;
        }

        [Op]
        public static ByteSize pack(MemorySeg src, uint bpl, StreamWriter dst)
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
            return pack(buffer, dst);
        }

        [Op]
        public static MemoryBlocks pack(ReadOnlySpan<ApiCodeBlock> src)
        {
            var count = src.Length;
            if(count == 0)
                return MemoryBlocks.Empty;
            var dst = alloc<MemoryBlock>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var code = ref skip(src,i);
                seek(dst,i) = new MemoryBlock(code.AddressRange, code.Encoded);
            }

            dst.Sort();
            return new MemoryBlocks(dst);
        }

        [Op]
        public static ByteSize pack(Index<MemorySeg> src, StreamWriter dst)
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

        public static Index<ApiHexPack> pack(SortedIndex<ApiCodeBlock> src, bool validate = false)
        {
            const ushort BufferLength = 48400;

            var blocks = src.View;
            var count = blocks.Length;
            var packs = alloc<ApiHexPack>(count);
            var chars = alloc<char>(BufferLength);
            ref var dst = ref first(packs);
            var size = pack(blocks, packs, chars);
            if(validate)
            {
                var buffer = span<HexDigitValue>(BufferLength);
                for(var i=0; i<count; i++)
                {
                    buffer.Clear();
                    ref readonly var pack = ref skip(dst,i);
                    var outcome = Hex.digits(pack.Data,buffer);
                    if(!outcome)
                    {
                        Errors.Throw("Reconstitution failed");
                        break;
                    }
                }
            }

            return packs;
        }

        [MethodImpl(Inline), Op]
        public static void charpack(byte src, out char c0, out char c1)
        {
            c0 = Hex.hexchar(LowerCase, src, 1);
            c1 = Hex.hexchar(LowerCase, src, 0);
        }
    }
}