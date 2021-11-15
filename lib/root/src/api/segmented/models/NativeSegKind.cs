//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using W = CpuCellWidth;
    using NK = NumericKind;

    /// <summary>
    /// Classifies concrete storage blocks of total width w over segments of width t and sign indicator s where:
    /// w = kind[0..15]
    /// t = kind[16..23]
    /// s = {u | i | f} as determined by kind[30..31]
    /// </summary>
    [Flags]
    public enum NativeSegKind : uint
    {
        None = 0,

        /// <summary>
        /// A block defined over 8-bit unsigned segments
        /// </summary>
        Seg8 = NK.U8 | NK.Unsigned,

        /// <summary>
        /// A block defined over 8-bit signed segments
        /// </summary>
        Seg8i = NK.I8 | NK.Signed,

        /// <summary>
        /// A block defined over 16-bit unsigned segments
        /// </summary>
        Seg16 = NK.U16 | NK.Unsigned,

        /// <summary>
        /// A block defined over 16-bit signed segments
        /// </summary>
        Seg16i = NK.I16 | NK.Signed,

        /// <summary>
        /// A block defined over 32-bit unsigned segments
        /// </summary>
        Seg32 = NK.U32 | NK.Unsigned,

        /// <summary>
        /// A block defined over 32-bit signed segments
        /// </summary>
        Seg32i = NK.I32 | NK.Signed,

        /// <summary>
        /// A block defined over 64-bit unsigned segments
        /// </summary>
        Seg64 = NK.U64 | NK.Unsigned,

        /// <summary>
        /// A block defined over 64-bit signed segments
        /// </summary>
        Seg64i = NK.I64 | NK.Signed,

        /// <summary>
        /// A block defined over 32-bit floating-point segments
        /// </summary>
        Seg32f = NK.F32 | NK.Float,

        /// <summary>
        /// A block defined over 64-bit floating-point segments
        /// </summary>
        Seg64f = NK.F64 | NK.Float,

        /// <summary>
        /// A 128-bit block with no particular sign
        /// </summary>
        Seg128 = W.W128,

        /// <summary>
        /// A 256-bit block with no particular sign
        /// </summary>
        Seg256 = W.W256,

        /// <summary>
        /// A 512-bit block with no particular sign
        /// </summary>
        Seg512 = W.W512,

        /// <summary>
        /// A 16-bit block covering 2 unsigned 8-bit segments
        /// </summary>
        Seg16x8u = W.W16 | Seg8,

        /// <summary>
        /// A 16-bit block covering 2 signed 8-bit segments
        /// </summary>
        Seg16x8i = W.W16 | Seg8i,

        /// <summary>
        /// A 16-bit block covering an unsigned 16-bit segment
        /// </summary>
        Seg16x16u = W.W16 | Seg16,

        /// <summary>
        /// A 16-bit block covering an unsigned 16-bit segment
        /// </summary>
        Seg16x16i = W.W16 | Seg16i,

        /// <summary>
        /// A 32-bit block covering 4 unsigned 8-bit segments
        /// </summary>
        Seg32x8u = W.W32 | Seg8,

        /// <summary>
        /// A 32-bit block covering 4 unsigned 8-bit segments
        /// </summary>
        Seg32x8i = W.W32 | Seg8i,

        /// <summary>
        /// A 32-bit block covering 2 unsigned 16-bit segments
        /// </summary>
        Seg32x16u = W.W32 | Seg16,

        /// <summary>
        /// A 32-bit block covering 2 signed 16-bit segments
        /// </summary>
        Seg32x16i = W.W32 | Seg16i,

        /// <summary>
        /// A 32-bit block covering an unsigned 32-bit segment
        /// </summary>
        Seg32x32u = W.W32 | Seg32,

        /// <summary>
        /// A 32-bit block covering a signed 32-bit segment
        /// </summary>
        Seg32x32i = W.W32 | Seg32i,

        /// <summary>
        /// A 32-bit block covering a floating-point 32-bit segment
        /// </summary>
        Seg32x32f = W.W32 | Seg32f,

        /// <summary>
        /// A 64-bit block covering 8 unsigned 8-bit segments
        /// </summary>
        Seg64x8u = W.W64 | Seg8,

        /// <summary>
        /// A 64-bit block covering 8 signed 8-bit segments
        /// </summary>
        Seg64x8i = W.W64 | Seg8i,

        /// <summary>
        /// A 64-bit block covering 4 unsigned 16-bit segments
        /// </summary>
        Seg64x16u = W.W64 | Seg16,

        /// <summary>
        /// A 64-bit block covering 4 signed 16-bit segments
        /// </summary>
        Seg64x16i = W.W64 | Seg16i,

        /// <summary>
        /// A 64-bit block covering 2 unsigned 32-bit segments
        /// </summary>
        Seg64x32u = W.W64 | Seg32,

        /// <summary>
        /// A 64-bit block covering 2 signed 32-bit segments
        /// </summary>
        Seg64x32i = W.W64 | Seg32i,

        /// <summary>
        /// A 64-bit block covering an unsigned 64-bit segment
        /// </summary>
        Seg64x64u = W.W64 | Seg64,

        /// <summary>
        /// A 64-bit block covering a signed 64-bit segment
        /// </summary>
        Seg64x64i = W.W64 | Seg64i,

        /// <summary>
        /// A 64-bit block covering 2 32-bit floating-point segments
        /// </summary>
        Seg64x32f = W.W64 | Seg32f,

        /// <summary>
        /// A 64-bit block covering a 64-bit floating-point segment
        /// </summary>
        Seg64x64f = W.W64 | Seg64f,

        /// <summary>
        /// A 128-bit block covering 16 8-bit unsigned segments
        /// </summary>
        Seg128x8u = W.W128 | Seg8,

        /// <summary>
        /// A 128-bit block covering 16 8-bit signed segments
        /// </summary>
        Seg128x8i = W.W128 | Seg8i,

        /// <summary>
        /// A 128-bit block covering 8 16-bit unsigned segments
        /// </summary>
        Seg128x16u = W.W128 | Seg16,

        /// <summary>
        /// A 128-bit block covering 8 16-bit signed segments
        /// </summary>
        Seg128x16i = W.W128 | Seg16i,

        /// <summary>
        /// A 128-bit block covering 4 32-bit unsigned segments
        /// </summary>
        Seg128x32u = W.W128 | Seg32,

        /// <summary>
        /// A 128-bit block covering 4 32-bit signed segments
        /// </summary>
        Seg128x32i = W.W128 | Seg32i,

        /// <summary>
        /// A 128-bit block covering 2 64-bit unsigned segments
        /// </summary>
        Seg128x64u = W.W128 | Seg64,

        /// <summary>
        /// A 128-bit block covering 2 64-bit signed segments
        /// </summary>
        Seg128x64i = W.W128 | Seg64i,

        /// <summary>
        /// A 128-bit block covering 4 32-bit floating-point segments
        /// </summary>
        Seg128x32f = W.W128 | Seg32f,

        /// <summary>
        /// A 128-bit block covering 2 64-bit floating-point segments
        /// </summary>
        Seg128x64f = W.W128 | Seg64f,

        /// <summary>
        /// A 256-bit block covering 32 8-bit unsigned segments
        /// </summary>
        Seg256x8u = W.W256 | Seg8,

        /// <summary>
        /// A 256-bit block covering 32 8-bit signed segments
        /// </summary>
        Seg256x8i = W.W256 | Seg8i,

        /// <summary>
        /// A 256-bit block covering 16 16-bit unsigned segments
        /// </summary>
        Seg256x16u = W.W256 | Seg16,

        /// <summary>
        /// A 256-bit block covering 16 16-bit signed segments
        /// </summary>
        Seg256x16i = W.W256 | Seg16i,

        /// <summary>
        /// A 256-bit block covering 8 32-bit unsigned segments
        /// </summary>
        Seg256x32u = W.W256 | Seg32,

        /// <summary>
        /// A 256-bit block covering 8 32-bit signed segments
        /// </summary>
        Seg256x32i = W.W256 | Seg32i,

        /// <summary>
        /// A 256-bit block covering 4 64-bit unsigned segments
        /// </summary>
        Seg256x64u = W.W256 | Seg64,

        /// <summary>
        /// A 256-bit block covering 4 64-bit signed segments
        /// </summary>
        Seg256x64i = W.W256 | Seg64i,

        /// <summary>
        /// A 256-bit block covering 8 32-bit floating-point segments
        /// </summary>
        Seg256x32f = W.W256 | Seg32f,

        /// <summary>
        /// A 256-bit block covering 4 64-bit floating-point segments
        /// </summary>
        Seg256x64f = W.W256 | Seg64f,

        /// <summary>
        /// A 512-bit block covering 32 8-bit unsigned segments
        /// </summary>
        Seg512x8u = W.W512 | Seg8,

        /// <summary>
        /// A 512-bit block covering 32 8-bit signed segments
        /// </summary>
        Seg512x8i = W.W512 | Seg8i,

        /// <summary>
        /// A 512-bit block covering 16 16-bit unsigned segments
        /// </summary>
        Seg512x16u = W.W512 | Seg16,

        /// <summary>
        /// A 512-bit block covering 16 16-bit signed segments
        /// </summary>
        Seg512x16i = W.W512 | Seg16i,

        /// <summary>
        /// A 512-bit block covering 8 32-bit unsigned segments
        /// </summary>
        Seg512x32u = W.W512 | Seg32,

        /// <summary>
        /// A 512-bit block covering 8 32-bit signed segments
        /// </summary>
        Seg512x32i = W.W512 | Seg32i,

        /// <summary>
        /// A 512-bit block covering 4 64-bit unsigned segments
        /// </summary>
        Seg512x64u = W.W512 | Seg64,

        /// <summary>
        /// A 512-bit block covering 4 64-bit signed segments
        /// </summary>
        Seg512x64i = W.W512 | Seg64i,

        /// <summary>
        /// A 512-bit block covering 8 32-bit floating-point segments
        /// </summary>
        Seg512x32f = W.W512 | Seg32f,

        /// <summary>
        /// A 512-bit block covering 4 64-bit floating-point segments
        /// </summary>
        Seg512x64f = W.W512 | Seg64f,
    }
}