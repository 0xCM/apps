//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    partial struct asm
    {
        [MethodImpl(Inline), Op]
        public static uint bitstring(in AsmHexCode src, Span<char> dst)
        {
            var i=0u;
            return BitRender.render8x4(slice(src.Bytes, 0, src.Size), ref i, dst);
        }

        [Op]
        public static string bitstring(in AsmHexCode src)
        {
            if(src.IsEmpty)
                return default;

            CharBlocks.alloc(n256, out var block);
            var dst = block.Data;
            var count = bitstring(src, dst);
            if(count == 0)
                return EmptyString;

            return text.format(slice(dst, 0, count));
        }
    }
}