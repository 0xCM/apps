//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    partial class XTend
    {
        [Op]
        public static string FormatBits(this Hex8 src, N8 n)
            => BitRender.format8(src);

        [Op]
        public static string FormatBits(this Hex8 src, N4 n)
            => BitRender.format8x4(src);

        [Op]
        public static string FormatBits(this Hex16 src, N8 n)
            => BitRender.format16x8(src);

        [Op]
        public static string FormatBits(this Hex32 src, N8 n)
            => BitRender.format32x8(src);

        [Op]
        public static string FormatBits(this Hex64 src, N8 n)
            => BitRender.format64x8(src);

        [Op]
        public static HexArray ToHexArray(this byte[] src)
            => HexArray.cover(src);

        [Op]
        public static HexArray ToHexArray(this ReadOnlySpan<byte> src)
            => HexArray.from(src);

        [Op]
        public static HexArray ToHexArray(this Span<byte> src)
            => HexArray.from(src);

        [Op]
        public static string FormatHexArray(this byte[] src)
            => HexArray.cover(src).Format();

        [Op]
        public static string FormatHexArray(this ReadOnlySpan<byte> src)
            => HexArray.from(src).Format();

        [Op]
        public static string FormatHexArray(this Span<byte> src)
            => HexArray.from(src).Format();

        [Op]
        public static string FormatHexArray(this byte[] src, Fence<char> fence)
            => HexArray.cover(src).Format(fence);

        [Op]
        public static string FormatHexArray(this ReadOnlySpan<byte> src, Fence<char> fence)
            => HexArray.from(src).Format(fence);

        [Op]
        public static string FormatHexArray(this Span<byte> src, Fence<char> fence)
            => HexArray.from(src).Format(fence);

        [Op]
        public static string FormatAsmHex(this sbyte src, int? digits = null)
            => HexFormatter.asmhex(src, digits);

        [Op]
        public static string FormatAsmHex(this byte src, int? digits = null)
            => HexFormatter.asmhex(src, digits);

        [Op]
        public static string FormatAsmHex(this short src, int? digits = null)
            => HexFormatter.asmhex(src, digits);

        [Op]
        public static string FormatAsmHex(this ushort src, int? digits = null)
            => HexFormatter.asmhex(src, digits);

        [Op]
        public static string FormatAsmHex(this int src, int? digits = null)
            => HexFormatter.asmhex(src, digits);

        [Op]
        public static string FormatAsmHex(this uint src, int? digits = null)
            => HexFormatter.asmhex(src, digits);

        [Op]
        public static string FormatAsmHex(this ulong src, int? digits = null)
            => HexFormatter.asmhex(src, digits);

        [Op]
        public static string FormatAsmHex(this long src, int? digits = null)
            => HexFormatter.asmhex(src,digits);

        [Op]
        public static string FormatTrimmedAsmHex(this ushort src)
            => src.FormatAsmHex(Widths.effective(src));

        [Op]
        public static string FormatTrimmedAsmHex(this uint src)
            => src.FormatAsmHex(Widths.effective(src));

        [Op]
        public static string FormatTrimmedAsmHex(this ulong src)
            => src.FormatAsmHex(Widths.effective(src));
    }
}
