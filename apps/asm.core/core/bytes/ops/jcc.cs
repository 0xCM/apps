//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    partial class AsmBytes
    {
        [MethodImpl(Inline), Op]
        public static byte jo(Hex8 cb, ref byte hex)
        {
            const byte Size = 2;
            seek(hex,0) = 0x70;
            seek(hex,1) = cb;
            return Size;
        }

        [MethodImpl(Inline), Op]
        public static byte jo(Hex32 cd, ref byte hex)
        {
            const byte Size = 6;
            seek16(hex,0) = 0x7080;
            seek32(hex,1) = cd;
            return Size;
        }
    }
}