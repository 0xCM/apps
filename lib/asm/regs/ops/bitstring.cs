//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;

    using static Root;
    using static core;

    partial struct AsmRegs
    {
         [Op,Closures(Closure)]
        public static ReadOnlySpan<char> bitstring<T>(in AsmRegValue<T> src, char sep = Chars.Space)
            where T : unmanaged
        {
            if(size<T>() == 1)
                return BitRender.render8(u8(src.Value));
            else if(size<T>() == 2)
                return BitRender.render16x8(u16(src.Value), sep);
            else if(size<T>() == 4)
                return BitRender.render32x8(u32(src.Value));
            else if(size<T>() == 8)
                return BitRender.render64x8(u64(src.Value));
            else
                return EmptyString;
        }
    }
}
