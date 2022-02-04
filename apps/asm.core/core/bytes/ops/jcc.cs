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
        public static void jo(Hex8 cb, AsmHexWriter dst)
        {
            dst.Write1(0x70);
            dst.Write1(cb);
        }

        [MethodImpl(Inline), Op]
        public static void jo(Hex32 cd, AsmHexWriter dst)
        {
            dst.Write2(0x7080);
            dst.Write4(cd);
        }
    }
}