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
        public static BinaryCode pack(uint size, ReadOnlySpan<ApiEncoded> src)
        {
            var dst = sys.alloc<byte>(size);
            var k = 0u;
            for(var i=0; i<src.Length; i++)
            {
                ref readonly var code = ref src[i].Code;
                for(var j=0; j<code.Length; j++, k++)
                    seek(dst,k) = code[j];
            }
            return dst;
        }

        [Op]
        public static BinaryCode pack(ReadOnlySpan<BinaryCode> src)
        {
            var count = src.Length;
            if(count == 0)
                return BinaryCode.Empty;
            var dst = sys.alloc<byte>(size(src));
            var k = 0u;
            for(var i=0u; i<count; i++)
            {
                var data = skip(src,i).View;
                for(var j=0u; j<data.Length; j++, k++)
                    seek(dst, k) = skip(data, j);
            }
            return dst;
        }

        [Op]
        public static BinaryCode pack(ReadOnlySpan<HexDataRow> src)
        {
            var count = src.Length;
            if(count == 0)
                return BinaryCode.Empty;

            var size = ApiCode.size(src);
            var dst = sys.alloc<byte>(size);
            var offset = 0u;
            for(var i=0; i<count; i++)
            {
                var data = skip(src,i).Data.View;
                for(var j=0; j<data.Length; j++)
                    seek(dst, offset++) = skip(data,j);
            }
            return dst;
        }

        [Op]
        public static ByteSize emit(in MemoryBlock block, uint index, StreamWriter dst)
        {
            var data = block.View;
            var size = (uint)data.Length;
            var buffer = sys.alloc<char>(data.Length*2);
            Hex.pack(data, buffer);
            dst.WriteLine(string.Format(HexLine.HexPackPattern, block.BaseAddress, index, size, new string(buffer)));
            return size;
        }

        [Op]
        public static string pack(in MemorySeg src, uint index, Span<char> dst)
        {
            var memspan = src.ToSpan();
            var count = Hex.pack(memspan.View, dst);
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
                package.Data = sys.@string(slice(buffer,0, Hex.pack(block.Bytes, buffer)));
                size += package.Size;
            }
            return size;
        }

        public static Index<ApiHexPack> pack(SortedIndex<ApiCodeBlock> src, bool validate)
        {
            const ushort BufferLength = 48400;

            var blocks = src.View;
            var count = blocks.Length;
            var packs = sys.alloc<ApiHexPack>(count);
            var chars = sys.alloc<char>(BufferLength);
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
    }
}