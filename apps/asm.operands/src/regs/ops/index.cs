//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{

    partial struct AsmRegs
    {
        [MethodImpl(Inline), Op]
        public static RegIndexCode index(RegOp src)
            => (RegIndexCode)bits.extract(src.Bitfield, 10, 15);

        /// <summary>
        /// Determines the register code from the kind
        /// </summary>
        /// <param name="src">The source kind</param>
        [MethodImpl(Inline), Op]
        public static RegIndexCode index(RegKind src)
            => (RegIndexCode)bits.slice((uint)src, (byte)RegFieldIndex.C, (byte)RegFieldWidth.RegCode);
    }
}