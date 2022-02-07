//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;
    using static Hex8Kind;

    partial class AsmBytes
    {
        [MethodImpl(Inline), Op]
        public static byte jo(Hex8 cb, AsmHexWriter dst)
            => dst.Write(x70, cb);

        [MethodImpl(Inline), Op]
        public static byte jo(Hex32 cd, AsmHexWriter dst)
            => dst.Write(x70, x86, cd);
    }
}