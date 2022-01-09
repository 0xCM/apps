//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    public static class XHexFormatter
    {
        [Op]
        public static string FormatHex(this byte[] src)
            => HexFormatter.format(src, HexFormatSpecs.HexData);

        [Op]
        public static string FormatHex(this ReadOnlySpan<byte> src)
            => HexFormatter.format(src, HexFormatSpecs.HexData);

        [Op]
        public static string FormatHex(this Span<byte> src)
            => HexFormatter.format(src, HexFormatSpecs.HexData);

        [Op]
        public static string FormatHex(this byte[] src, in HexFormatOptions config)
            => HexFormatter.format(src, config);

        /// <summary>
        /// Formats a span of numeric cell type as a sequence of hex values
        /// </summary>
        /// <param name="src">The source span</param>
        /// <param name="bracket">Whether to enclose the formatted hex within brackets</param>
        /// <param name="sep">The character to use when separating digits</param>
        /// <param name="specifier">Whether to prefix each number with the canonical hex specifier, "0x"</param>
        /// <typeparam name="T">The primal type</typeparam>
        public static string FormatHex<T>(this Span<T> src, char sep, bool specifier)
            where T : unmanaged
                => HexFormatter.format(src.ReadOnly(), sep, specifier);

        /// <summary>
        /// Formats a span of numeric cell type as a sequence of hex values
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The primal type</typeparam>
        public static string FormatHex<T>(this ReadOnlySpan<T> src, char sep, bool specifier)
            where T : unmanaged
                => HexFormatter.format(src, sep, specifier);

        [Op]
        public static string FormatHex(this sbyte src, int digits, bool prespec = false, bool postspec = false)
            => HexFormatter.format(src, digits, prespec, postspec);

        [Op]
        public static string FormatHex(this byte src, int digits, bool prespec = false, bool postspec = false)
            => HexFormatter.format(src, digits, prespec, postspec);

        [Op]
        public static string FormatHex(this short src, int digits, bool prespec = false, bool postspec = false)
            => HexFormatter.format(src, digits, prespec, postspec);

        [Op]
        public static string FormatHex(this ushort src, int digits, bool prespec = false, bool postspec = false)
            => HexFormatter.format(src, digits, prespec, postspec);

        [Op]
        public static string FormatHex(this int src, int digits, bool prespec = false, bool postspec = false)
            => HexFormatter.format(src, digits, prespec, postspec);

        [Op]
        public static string FormatHex(this uint src, int digits, bool prespec = false, bool postspec = false)
            => HexFormatter.format(src, digits, prespec, postspec);

        [Op]
        public static string FormatHex(this ulong src, int digits, bool prespec = false, bool postspec = false)
            => HexFormatter.format(src, digits, prespec, postspec);

        [Op]
        public static string FormatHex(this long src, int digits, bool prespec = false, bool postspec = false)
            => HexFormatter.format(src, digits, prespec, postspec);

        [Op]
        public static string FormatTrimmedHex(this ushort src, bool prespec = false, bool postspec = false)
        {
            if(src <= byte.MaxValue)
                return src.FormatHex(2, prespec, postspec);
            else
                return src.FormatHex(4, prespec, postspec);
        }

        [Op]
        public static string FormatTrimmedHex(this uint src, bool prespec = false, bool postspec = false)
        {
            if(src <= byte.MaxValue)
                return src.FormatHex(2, prespec, postspec);
            else if (src <= ushort.MaxValue)
                return src.FormatHex(4, prespec, postspec);
            else
                return src.FormatHex(8, prespec, postspec);
        }

        [Op]
        public static string FormatTrimmedHex(this ulong src, bool prespec = false, bool postspec = false)
        {
            if(src <= byte.MaxValue)
                return src.FormatHex(2, prespec, postspec);
            else if (src <= ushort.MaxValue)
                return src.FormatHex(4, prespec, postspec);
            else if (src <= uint.MaxValue)
                return src.FormatHex(8, prespec, postspec);
            else
                return src.FormatHex(16, prespec, postspec);
        }

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
        {
            if(src <= byte.MaxValue)
                return src.FormatAsmHex(2);
            else
                return src.FormatAsmHex(4);
        }

        [Op]
        public static string FormatTrimmedAsmHex(this uint src)
        {
            if(src <= byte.MaxValue)
                return src.FormatAsmHex(2);
            else if (src <= ushort.MaxValue)
                return src.FormatAsmHex(4);
            else
                return src.FormatAsmHex(8);
        }

        [Op]
        public static string FormatTrimmedAsmHex(this ulong src)
        {
            if(src <= byte.MaxValue)
                return src.FormatAsmHex(2);
            else if (src <= ushort.MaxValue)
                return src.FormatAsmHex(4);
            else if (src <= uint.MaxValue)
                return src.FormatAsmHex(8);
            else
                return src.FormatAsmHex();
        }

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
    }
}