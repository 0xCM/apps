//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct vmask
    {
        [MethodImpl(Inline), Op]
        public static Vector128<byte> hexbins(W128 w)
            => gcpu.vload(w, HexBins128);

        [MethodImpl(Inline), Op]
        public static Vector256<byte> hexbins(W256 w)
            => gcpu.vload(w, HexBins256);

        static ReadOnlySpan<byte> HexBins128 => new byte[16]{
            0x00, 0x10, 0x20, 0x30, 0x40, 0x50, 0x60, 0x70, 0x80, 0x90, 0xA0, 0xB0, 0xC0, 0xD0,0xE0, 0xF0,
            };

        static ReadOnlySpan<byte> HexBins256 => new byte[32]{
            0x00, 0x10, 0x20, 0x30, 0x40, 0x50, 0x60, 0x70, 0x80, 0x90, 0xA0, 0xB0, 0xC0, 0xD0,0xE0, 0xF0,
            0x00, 0x10, 0x20, 0x30, 0x40, 0x50, 0x60, 0x70, 0x80, 0x90, 0xA0, 0xB0, 0xC0, 0xD0,0xE0, 0xF0,
            };
    }
}