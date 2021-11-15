//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    partial class XTend
    {
        public static string FormatBits(this Hex8 src, N8 n)
            => BitRender.format8(src);

        public static string FormatBits(this Hex8 src, N4 n)
            => BitRender.format8x4(src);

        public static string FormatBits(this Hex16 src, N8 n)
            => BitRender.format16x8(src);

        public static string FormatBits(this Hex32 src, N8 n)
            => BitRender.format32x8(src);

        public static string FormatBits(this Hex64 src, N8 n)
            => BitRender.format64x8(src);

        public static HexArray ToHexArray(this byte[] src)
            => HexArray.cover(src);

        public static HexArray ToHexArray(this ReadOnlySpan<byte> src)
            => HexArray.from(src);

        public static HexArray ToHexArray(this Span<byte> src)
            => HexArray.from(src);

        public static string FormatHexArray(this byte[] src)
            => HexArray.cover(src).Format();

        public static string FormatHexArray(this ReadOnlySpan<byte> src)
            => HexArray.from(src).Format();

        public static string FormatHexArray(this Span<byte> src)
            => HexArray.from(src).Format();

        public static string FormatHexArray(this byte[] src, Fence<char> fence)
            => HexArray.cover(src).Format(fence);

        public static string FormatHexArray(this ReadOnlySpan<byte> src, Fence<char> fence)
            => HexArray.from(src).Format(fence);

        public static string FormatHexArray(this Span<byte> src, Fence<char> fence)
            => HexArray.from(src).Format(fence);
    }
}
