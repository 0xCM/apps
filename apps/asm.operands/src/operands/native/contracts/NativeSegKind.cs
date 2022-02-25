//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using SC = ScalarClass;
    using SZ = NativeSizeCode;

    /// <summary>
    /// Classifies concrete storage blocks of total width w over segments of width t and sign indicator s where:
    /// w = kind[0..15]
    /// t = kind[16..23]
    /// s = {u | i | f} as determined by kind[30..31]
    /// </summary>
    [SymSource("api.kinds", NumericBaseKind.Base16), Flags]
    public enum NativeSegKind : ushort
    {
        None = 0,

        /// <summary>
        /// A block defined over 8-bit unsigned segments
        /// </summary>
        Seg8u = (SZ.W8 | SC.U << 4) | (1 << 8),

        /// <summary>
        /// A block defined over 8-bit signed segments
        /// </summary>
        Seg8i = (SZ.W8 | SC.I << 4) | (1 << 8),

        /// <summary>
        /// A block defined over 16-bit unsigned segments
        /// </summary>
        Seg16u = (SZ.W16 | SC.U << 4) | (1 << 8),

        /// <summary>
        /// A block defined over 16-bit signed segments
        /// </summary>
        Seg16i = (SZ.W16 | SC.I << 4) | (1 << 8),

        /// <summary>
        /// A block defined over 32-bit unsigned segments
        /// </summary>
        Seg32u = (SZ.W32 | SC.U << 4) | (1 << 8),

        /// <summary>
        /// A block defined over 32-bit signed segments
        /// </summary>
        Seg32i = (SZ.W32 | SC.I << 4) | (1 << 8),

        /// <summary>
        /// A block defined over 64-bit unsigned segments
        /// </summary>
        Seg64u = (SZ.W64 | SC.U << 4) | (1 << 8),

        /// <summary>
        /// A block defined over 64-bit signed segments
        /// </summary>
        Seg64i = (SZ.W64 | SC.I << 4) | (1 << 8),

        /// <summary>
        /// A block defined over 32-bit floating-point segments
        /// </summary>
        Seg32f = (SZ.W32 | SC.F << 4) | (1 << 8),

        /// <summary>
        /// A block defined over 64-bit floating-point segments
        /// </summary>
        Seg64f = (SZ.W64 | SC.F << 4) | (1 << 8),

        /// <summary>
        /// A 128-bit unsigned segment
        /// </summary>
        Seg128u = (SZ.W128 | SC.U << 4) | (1 << 8),

        /// <summary>
        /// A 256-bit unsigned segment
        /// </summary>
        Seg256u = (SZ.W256 | SC.U << 4) | (1 << 8),

        /// <summary>
        /// A 512-bit unsigned segment
        /// </summary>
        Seg512u = (SZ.W512 | SC.U << 4) | (1 << 8),

        /// <summary>
        /// A 16-bit block covering 2 unsigned 8-bit segments
        /// </summary>
        Seg16x8u = (SZ.W8 | SC.U << 4) | (2 << 8),

        /// <summary>
        /// A 16-bit block covering 2 signed 8-bit segments
        /// </summary>
        Seg16x8i = (SZ.W8 | SC.I << 4) | (2 << 8),

        /// <summary>
        /// A 32-bit block covering 4 unsigned 8-bit segments
        /// </summary>
        Seg32x8u = (SZ.W8 | SC.U << 4) | (4 << 8),

        /// <summary>
        /// A 32-bit block covering 4 unsigned 8-bit segments
        /// </summary>
        Seg32x8i = (SZ.W8 | SC.I << 4) | (4 << 8),

        /// <summary>
        /// A 32-bit block covering 2 unsigned 16-bit segments
        /// </summary>
        Seg32x16u = (SZ.W16 | SC.U << 4) | (2 << 8),

        /// <summary>
        /// A 32-bit block covering 2 signed 16-bit segments
        /// </summary>
        Seg32x16i = (SZ.W16 | SC.I << 4) | (2 << 8),

        /// <summary>
        /// A 64-bit block covering 8 unsigned 8-bit segments
        /// </summary>
        Seg64x8u = (SZ.W8 | SC.U << 4) | (8 << 8),

        /// <summary>
        /// A 64-bit block covering 8 signed 8-bit segments
        /// </summary>
        Seg64x8i = (SZ.W8 | SC.I << 4) | (8 << 8),

        /// <summary>
        /// A 64-bit block covering 4 unsigned 16-bit segments
        /// </summary>
        Seg64x16u = (SZ.W16 | SC.U << 4) | (4 << 8),

        /// <summary>
        /// A 64-bit block covering 4 signed 16-bit segments
        /// </summary>
        Seg64x16i = (SZ.W16 | SC.I << 4) | (4 << 8),

        /// <summary>
        /// A 64-bit block covering 2 unsigned 32-bit segments
        /// </summary>
        Seg64x32u = (SZ.W32 | SC.U << 4) | (2 << 8),

        /// <summary>
        /// A 64-bit block covering 2 signed 32-bit segments
        /// </summary>
        Seg64x32i = (SZ.W32 | SC.I << 4) | (2 << 8),

        /// <summary>
        /// A 64-bit block covering 2 32-bit floating-point segments
        /// </summary>
        Seg64x32f = (SZ.W32 | SC.F << 4) | (2 << 8),

        /// <summary>
        /// A 128-bit block covering 16 8-bit unsigned segments
        /// </summary>
        Seg128x8u = (SZ.W8 | SC.U << 4) | (16 << 8),

        /// <summary>
        /// A 128-bit block covering 16 8-bit signed segments
        /// </summary>
        Seg128x8i = (SZ.W8 | SC.I << 4) | (16 << 8),

        /// <summary>
        /// A 128-bit block covering 8 16-bit unsigned segments
        /// </summary>
        Seg128x16u = (SZ.W16 | SC.U << 4) | (8 << 8),

        /// <summary>
        /// A 128-bit block covering 8 16-bit signed segments
        /// </summary>
        Seg128x16i = (SZ.W16 | SC.I << 4) | (8 << 8),

        /// <summary>
        /// A 128-bit block covering 4 32-bit unsigned segments
        /// </summary>
        Seg128x32u = (SZ.W32 | SC.U << 4) | (4 << 8),

        /// <summary>
        /// A 128-bit block covering 4 32-bit signed segments
        /// </summary>
        Seg128x32i = (SZ.W32 | SC.I << 4) | (4 << 8),

        /// <summary>
        /// A 128-bit block covering 2 64-bit unsigned segments
        /// </summary>
        Seg128x64u = (SZ.W64 | SC.U << 4) | (2 << 8),

        /// <summary>
        /// A 128-bit block covering 2 64-bit signed segments
        /// </summary>
        Seg128x64i = (SZ.W64 | SC.I << 4) | (2 << 8),

        /// <summary>
        /// A 128-bit block covering 4 32-bit floating-point segments
        /// </summary>
        Seg128x32f = (SZ.W32 | SC.F << 4) | (4 << 8),

        /// <summary>
        /// A 128-bit block covering 2 64-bit floating-point segments
        /// </summary>
        Seg128x64f = (SZ.W64 | SC.F << 4) | (2 << 8),

        /// <summary>
        /// A 256-bit block covering 32 8-bit unsigned segments
        /// </summary>
        Seg256x8u = (SZ.W8 | SC.U << 4) | (32 << 8),

        /// <summary>
        /// A 256-bit block covering 32 8-bit signed segments
        /// </summary>
        Seg256x8i = (SZ.W8 | SC.I << 4) | (32 << 8),

        /// <summary>
        /// A 256-bit block covering 16 16-bit unsigned segments
        /// </summary>
        Seg256x16u = (SZ.W16 | SC.U << 4) | (16 << 8),

        /// <summary>
        /// A 256-bit block covering 16 16-bit signed segments
        /// </summary>
        Seg256x16i = (SZ.W16 | SC.I << 4) | (16 << 8),

        /// <summary>
        /// A 256-bit block covering 8 32-bit unsigned segments
        /// </summary>
        Seg256x32u = (SZ.W32 | SC.U << 4) | (8 << 8),

        /// <summary>
        /// A 256-bit block covering 8 32-bit signed segments
        /// </summary>
        Seg256x32i = (SZ.W32 | SC.I << 4) | (8 << 8),

        /// <summary>
        /// A 256-bit block covering 4 64-bit unsigned segments
        /// </summary>
        Seg256x64u = (SZ.W64 | SC.U << 4) | (4 << 8),

        /// <summary>
        /// A 256-bit block covering 4 64-bit signed segments
        /// </summary>
        Seg256x64i = (SZ.W64 | SC.I << 4) | (4 << 8),

        /// <summary>
        /// A 256-bit block covering 8 32-bit floating-point segments
        /// </summary>
        Seg256x32f = (SZ.W32 | SC.F << 4) | (8 << 8),

        /// <summary>
        /// A 256-bit block covering 4 64-bit floating-point segments
        /// </summary>
        Seg256x64f = (SZ.W64 | SC.F << 4) | (4 << 8),

        /// <summary>
        /// A 512-bit block covering 32 8-bit unsigned segments
        /// </summary>
        Seg512x8u = (SZ.W8 | SC.U << 4) | (64 << 8),

        /// <summary>
        /// A 512-bit block covering 32 8-bit signed segments
        /// </summary>
        Seg512x8i = (SZ.W8 | SC.I << 4) | (64 << 8),

        /// <summary>
        /// A 512-bit block covering 16 16-bit unsigned segments
        /// </summary>
        Seg512x16u = (SZ.W16 | SC.U << 4) | (32 << 8),

        /// <summary>
        /// A 512-bit block covering 16 16-bit signed segments
        /// </summary>
        Seg512x16i = (SZ.W16 | SC.I << 4) | (32 << 8),

        /// <summary>
        /// A 512-bit block covering 8 32-bit unsigned segments
        /// </summary>
        Seg512x32u = (SZ.W32 | SC.U << 4) | (16 << 8),

        /// <summary>
        /// A 512-bit block covering 8 32-bit signed segments
        /// </summary>
        Seg512x32i = (SZ.W32 | SC.I << 4) | (16 << 8),

        /// <summary>
        /// A 512-bit block covering 4 64-bit unsigned segments
        /// </summary>
        Seg512x64u = (SZ.W64 | SC.U << 4) | (8 << 8),

        /// <summary>
        /// A 512-bit block covering 4 64-bit signed segments
        /// </summary>
        Seg512x64i = (SZ.W64 | SC.I << 4) | (8 << 8),

        /// <summary>
        /// A 512-bit block covering 8 32-bit floating-point segments
        /// </summary>
        Seg512x32f = (SZ.W32 | SC.F << 4) | (16 << 8),

        /// <summary>
        /// A 512-bit block covering 4 64-bit floating-point segments
        /// </summary>
        Seg512x64f = (SZ.W64 | SC.F << 4) | (8 << 8),

        Void = (SZ.Unknown | SC.None << 4) | (SZ.Unknown << 8)
    }
}