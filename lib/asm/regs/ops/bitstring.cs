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
        public static string bitstring<T>(in AsmRegValue<T> src)
            where T : unmanaged
        {
            if(size<T>() == 1)
                return BitRender.format8(u8(src.Value));
            else if(size<T>() == 2)
                return BitRender.format16x8(u16(src.Value));
            else if(size<T>() == 4)
                return BitRender.format32x8(u32(src.Value));
            else if(size<T>() == 8)
                return BitRender.format64x8(u64(src.Value));
            else
                return EmptyString;
        }
    }
}
