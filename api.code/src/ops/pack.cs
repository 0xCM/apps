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
        [MethodImpl(Inline), Op]
        public static void charpack(byte src, out char c0, out char c1)
        {
            c0 = Hex.hexchar(LowerCase, src, 1);
            c1 = Hex.hexchar(LowerCase, src, 0);
        }

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
        public static Index<HexPacked> pack(SortedIndex<ApiCodeBlock> src, bool validate = false)
        {
            const ushort BufferLength = 48400;

            var blocks = src.View;
            var count = blocks.Length;
            var packs = alloc<HexPacked>(count);
            var chars = alloc<char>(BufferLength);
            ref var dst = ref first(packs);
            var size = ApiBlocks.pack(blocks, packs, chars);
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