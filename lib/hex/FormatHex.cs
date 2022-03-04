//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static HexFormatSpecs;

    [ApiHost]
    public static class XHex
    {
        /// <summary>
        /// Renders a number as a hexadecimal string
        /// </summary>
        /// <param name="src">The source number</param>
        /// <param name="zpad">Specifies whether the numeric content should be left-padded with zeros</param>
        /// <param name="specifier">Specifies whether the hex numeric specifier shold prefix the output</param>
        /// <param name="uppercase">Specifies whether hex characters should be upper-cased</param>
        /// <param name="prespec">Indicates where the specifier, if applied, is a prefix specifier (true) or a postfix specifier (false)</param>
        [Op]
        public static string FormatHex(this sbyte src, bool zpad = true, bool specifier = true, bool uppercase = false, bool prespec = true)
            => (specifier && prespec ? "0x" : string.Empty)
            + (zpad ? src.ToString(CaseSpec(uppercase).ToString()).PadLeft(Hex8Width, '0')
            : src.ToString(CaseSpec(uppercase).ToString()))
             + (specifier && !prespec ? "h" : string.Empty);

        [Op]
        public static string FormatHex(this byte src, bool zpad = true, bool specifier = true, bool uppercase = false, bool prespec = true)
            => (specifier && prespec ? "0x" : string.Empty)
             + (zpad ? src.ToString(CaseSpec(uppercase).ToString()).PadLeft(Hex8Width, '0')
                     : src.ToString(CaseSpec(uppercase).ToString()))
             + (specifier && !prespec ? "h" : string.Empty);

        /// <summary>
        /// Renders a number as a hexadecimal string
        /// </summary>
        /// <param name="src">The source number</param>
        /// <param name="zpad">Specifies whether the numeric content should be left-padded with zeros</param>
        /// <param name="specifier">Specifies whether the hex numeric specifier shold prefix the output</param>
        /// <param name="uppercase">Specifies whether hex characters should be upper-cased</param>
        /// <param name="prespec">Indicates where the specifier, if applied, is a prefix specifier (true) or a postfix specifier (false)</param>
        [Op]
        public static string FormatHex(this short src, bool zpad = true, bool specifier = true, bool uppercase = false, bool prespec = true)
            => (specifier && prespec ? "0x" : string.Empty)
             + (zpad ? src.ToString(CaseSpec(uppercase).ToString()).PadLeft(Hex16Width, '0')
                     : src.ToString(CaseSpec(uppercase).ToString()))
             + (specifier && !prespec ? "h" : string.Empty);

        /// <summary>
        /// Renders a number as a hexadecimal string
        /// </summary>
        /// <param name="src">The source number</param>
        /// <param name="zpad">Specifies whether the numeric content should be left-padded with zeros</param>
        /// <param name="specifier">Specifies whether the hex numeric specifier shold prefix the output</param>
        /// <param name="uppercase">Specifies whether hex characters should be upper-cased</param>
        /// <param name="prespec">Indicates where the specifier, if applied, is a prefix specifier (true) or a postfix specifier (false)</param>
        [Op]
        public static string FormatHex(this ushort src, bool zpad = true, bool specifier = true, bool uppercase = false, bool prespec = true)
            => (specifier && prespec ? "0x" : string.Empty)
             + (zpad ? src.ToString(CaseSpec(uppercase).ToString()).PadLeft(Hex16Width, '0')
                     : src.ToString(CaseSpec(uppercase).ToString()))
             + (specifier && !prespec ? "h" : string.Empty);

        /// <summary>
        /// Renders a number as a hexadecimal string
        /// </summary>
        /// <param name="src">The source number</param>
        /// <param name="zpad">Specifies whether the numeric content should be left-padded with zeros</param>
        /// <param name="specifier">Specifies whether the hex numeric specifier shold prefix the output</param>
        /// <param name="uppercase">Specifies whether hex characters should be upper-cased</param>
        /// <param name="prespec">Indicates where the specifier, if applied, is a prefix specifier (true) or a postfix specifier (false)</param>
        [Op]
        public static string FormatHex(this int src, bool zpad = true, bool specifier = true, bool uppercase = false, bool prespec = true)
            => (specifier && prespec ? "0x" : string.Empty)
             + (zpad ? src.ToString(CaseSpec(uppercase).ToString()).PadLeft(Hex32Width, '0')
                     : src.ToString(CaseSpec(uppercase).ToString()))
             + (specifier && !prespec ? "h" : string.Empty);

        /// <summary>
        /// Renders a number as a hexadecimal string
        /// </summary>
        /// <param name="src">The source number</param>
        /// <param name="zpad">Specifies whether the numeric content should be left-padded with zeros</param>
        /// <param name="specifier">Specifies whether the hex numeric specifier shold prefix the output</param>
        /// <param name="uppercase">Specifies whether hex characters should be upper-cased</param>
        /// <param name="prespec">Indicates where the specifier, if applied, is a prefix specifier (true) or a postfix specifier (false)</param>
        [Op]
        public static string FormatHex(this uint src, bool zpad = true, bool specifier = true, bool uppercase = false, bool prespec = true)
            => (specifier && prespec ? "0x" : string.Empty)
             + (zpad ? src.ToString(CaseSpec(uppercase).ToString()).PadLeft(Hex32Width, '0')
                     : src.ToString(CaseSpec(uppercase).ToString()))
             + (specifier && !prespec ? "h" : string.Empty);

        /// <summary>
        /// Renders a number as a hexadecimal string
        /// </summary>
        /// <param name="src">The source number</param>
        /// <param name="zpad">Specifies whether the numeric content should be left-padded with zeros</param>
        /// <param name="specifier">Specifies whether the hex numeric specifier shold prefix the output</param>
        /// <param name="uppercase">Specifies whether hex characters should be upper-cased</param>
        /// <param name="prespec">Indicates where the specifier, if applied, is a prefix specifier (true) or a postfix specifier (false)</param>
        [Op]
        public static string FormatHex(this long src, bool zpad = true, bool specifier = true, bool uppercase = false, bool prespec = true)
            => (specifier && prespec ? "0x" : string.Empty)
             + (zpad ? src.ToString(CaseSpec(uppercase).ToString()).PadLeft(Hex64Width, '0')
                     : src.ToString(CaseSpec(uppercase).ToString()))
             + (specifier && !prespec  ? "h" : string.Empty);

        /// <summary>
        /// Renders a number as a hexadecimal string
        /// </summary>
        /// <param name="src">The source number</param>
        /// <param name="zpad">Specifies whether the numeric content should be left-padded with zeros</param>
        /// <param name="specifier">Specifies whether the hex numeric specifier shold prefix the output</param>
        /// <param name="uppercase">Specifies whether hex characters should be upper-cased</param>
        /// <param name="prespec">Indicates where the specifier, if applied, is a prefix specifier (true) or a postfix specifier (false)</param>
        [Op]
        public static string FormatHex(this ulong src, bool zpad = true, bool specifier = true, bool uppercase = false, bool prespec = true)
            => (specifier && prespec ? "0x" : string.Empty)
             + (zpad ? src.ToString(CaseSpec(uppercase).ToString()).PadLeft(Hex64Width, '0')
                     : src.ToString(CaseSpec(uppercase).ToString()))
             + (specifier && !prespec  ? "h" : string.Empty);

        /// <summary>
        /// Formats a scalar value as a sequence of hex digits
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="uppercase">Whether to use uppercase characters for digits A - F</param>
        [Op]
        public static string FormatHex(this float src, bool zpad = true, bool specifier = true, bool uppercase = false, bool prespec = true)
            => BitConverter.SingleToInt32Bits(src).FormatHex(zpad, specifier, uppercase, prespec);

        /// <summary>
        /// Formats a scalar value as a sequence of hex digits
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="uppercase">Whether to use uppercase characters for digits A - F</param>
        [Op]
        public static string FormatHex(this double src, bool zpad = true, bool specifier = true, bool uppercase = false, bool prespec = true)
            => BitConverter.DoubleToInt64Bits(src).FormatHex(zpad, specifier, uppercase, prespec);

        [Op]
        public static string FormatHex(this byte src, HexFormatOptions config)
            => src.FormatHex(config.ZeroPad, config.Specifier, config.Uppercase, config.PreSpec);

        [Op]
        public static string FormatHex(this sbyte src, HexFormatOptions config)
            => src.FormatHex(config.ZeroPad, config.Specifier, config.Uppercase, config.PreSpec);

        [Op]
        public static string FormatHex(this short src, HexFormatOptions config)
            => src.FormatHex(config.ZeroPad, config.Specifier, config.Uppercase, config.PreSpec);

        [Op]
        public static string FormatHex(this ushort src, HexFormatOptions config)
            => src.FormatHex(config.ZeroPad, config.Specifier, config.Uppercase, config.PreSpec);

        [Op]
        public static string FormatHex(this int src, HexFormatOptions config)
            => src.FormatHex(config.ZeroPad, config.Specifier, config.Uppercase, config.PreSpec);

        [Op]
        public static string FormatHex(this uint src, HexFormatOptions config)
            => src.FormatHex(config.ZeroPad, config.Specifier, config.Uppercase, config.PreSpec);

        [Op]
        public static string FormatHex(this ulong src, HexFormatOptions config)
            => src.FormatHex(config.ZeroPad, config.Specifier, config.Uppercase, config.PreSpec);

        [Op]
        public static string FormatHex(this long src, HexFormatOptions config)
            => src.FormatHex(config.ZeroPad, config.Specifier, config.Uppercase, config.PreSpec);

        [Op]
        public static string FormatHex(this byte[] src)
            => HexFormatter.format(src, HexFormatSpecs.HexData);

        [Op]
        public static string FormatHex(this byte[] src, in HexFormatOptions config)
            => HexFormatter.format(src, config);

        [Op]
        public static string FormatHex(this ReadOnlySpan<byte> src)
            => HexFormatter.format(src, HexFormatSpecs.HexData);

        [Op]
        public static string FormatHex(this ReadOnlySpan<byte> src, in HexFormatOptions options)
            => HexFormatter.format(src, options);

        [Op]
        public static string FormatHex(this Span<byte> src)
            => HexFormatter.format(src, HexFormatSpecs.HexData);

        [Op]
        public static string FormatHex(this Span<byte> src, in HexFormatOptions options)
            => HexFormatter.format(src, options);

        /// <summary>
        /// Formats a span of numeric cell type as a sequence of hex values
        /// </summary>
        /// <param name="src">The source span</param>
        /// <param name="bracket">Whether to enclose the formatted hex within brackets</param>
        /// <param name="sep">The character to use when separating digits</param>
        /// <param name="prespec">Whether to prefix each number with the canonical hex specifier, "0x"</param>
        /// <typeparam name="T">The primal type</typeparam>
        public static string FormatHex<T>(this Span<T> src, char sep, bool prespec)
            where T : unmanaged
                => HexFormatter.format(src.ReadOnly(), sep, prespec);

        public static string FormatHex<T>(this ReadOnlySpan<T> src, char sep, bool prespec = false, bool uppercase = false)
            where T : unmanaged
                => HexFormatter.format(src, sep, prespec, uppercase);

        public static string FormatHex<T>(this Span<T> src, char sep, bool prespec = false, bool uppercase = false)
            where T : unmanaged
                => core.@readonly(src).FormatHex(sep, prespec, uppercase);

        [Op]
        public static string FormatHex(this sbyte src, int digits, bool prespec = false, bool postspec = false)
            => HexFormatter.format8i(src, digits, prespec, postspec);

        [Op]
        public static string FormatHex(this byte src, int digits, bool prespec = false, bool postspec = false)
            => HexFormatter.format8u(src, digits, prespec, postspec);

        [Op]
        public static string FormatHex(this short src, int digits, bool prespec = false, bool postspec = false)
            => HexFormatter.format16i(src, digits, prespec, postspec);

        [Op]
        public static string FormatHex(this ushort src, int digits, bool prespec = false, bool postspec = false)
            => HexFormatter.format16u(src, digits, prespec, postspec);

        [Op]
        public static string FormatHex(this int src, int digits, bool prespec = false, bool postspec = false)
            => HexFormatter.format32i(src, digits, prespec, postspec);

        [Op]
        public static string FormatHex(this uint src, int digits, bool prespec = false, bool postspec = false)
            => HexFormatter.format32u(src, digits, prespec, postspec);

        [Op]
        public static string FormatHex(this ulong src, int digits, bool prespec = false, bool postspec = false)
            => HexFormatter.format64u(src, digits, prespec, postspec);

        [Op]
        public static string FormatHex(this long src, int digits, bool prespec = false, bool postspec = false)
            => HexFormatter.format64i(src, digits, prespec, postspec);

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