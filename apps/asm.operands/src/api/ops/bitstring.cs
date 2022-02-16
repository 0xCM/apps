//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    partial struct asm
    {
        [Op]
        public static AsmBitstring bitstring(in AsmHexCode src)
        {
            if(src.IsEmpty)
                return default;

            CharBlocks.alloc(n256, out var block);
            var dst = block.Data;
            var count = AsmRender.bitstring(src, dst);
            if(count == 0)
                return AsmBitstring.Empty;

            return new AsmBitstring(text.format(slice(dst, 0, count)));
        }
    }
}