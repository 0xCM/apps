//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Text;
    using System.IO;

    using static core;
    using static HexFormatSpecs;

    using SK = HexSpecKind;

    [ApiHost]
    public readonly struct HexFormatter
    {
        const NumericKind Closure = UnsignedInts;

        /// <summary>
        /// Specifies the default configuration for hex data emission
        /// </summary>
        public static HexFormatOptions HexData
        {
            [MethodImpl(Inline)]
            get => options(true, false, false, false, true, DataDelimiter);
        }

        /// <summary>
        /// The default configuration for array initialization content
        /// </summary>
        public static HexFormatOptions HexArray
        {
            [MethodImpl(Inline)]
             get => options(zpad:true, specifier:true, uppercase:false, prespec:true, delimitsegs:true, segsep:ListDelimiter, valsep: ListDelimiter);
        }

        public static HexFormatOptions Compact
        {
            [MethodImpl(Inline)]
            get => options(zpad:true, specifier:false, uppercase:true, prespec:false, delimitsegs:false, delimitblocks:false);
        }


        /// <summary>
        /// Removes leading or trailing hex specifiers
        /// </summary>
        /// <param name="src">The source string</param>
        public static string clear(string src)
            => src.Remove("0x").RemoveAny('h');

        /// <summary>
        /// Removes leading or trailing hex specifiers
        /// </summary>
        /// <param name="src">The source string</param>
        public static ReadOnlySpan<char> clear(ReadOnlySpan<char> src)
        {
            var output = src;
            if(src.Length >= 2)
            {
                ref readonly var c0 = ref skip(src,0);
                ref readonly var c1 = ref skip(src,1);
                if(c0 == '0' & c1 == 'x')
                    output = slice(src,2);
                else
                {
                    ref readonly var c = ref skip(src,src.Length-1);
                    if(c == 'h')
                    {
                        output = slice(src,0, src.Length - 1);
                    }
                }
            }
            return output;
        }

        public static string spec(W8 w, HexPadStyle pad, LetterCaseKind @case)
        {
            if(pad == HexPadStyle.Zero)
                return @case == LetterCaseKind.Upper ? Hex8SpecUC : Hex8Spec;
            else
                 return CaseSpec(@case);
        }

        public static string spec(W8i w, HexPadStyle pad, LetterCaseKind @case)
            => spec(w8, pad, @case);

        public static string spec(W16 w, HexPadStyle pad, LetterCaseKind @case)
        {
            if(pad == HexPadStyle.Zero)
                return @case == LetterCaseKind.Upper ? Hex16SpecUC : Hex16Spec;
            else
                 return CaseSpec(@case);
        }

        public static string spec(W16i w, HexPadStyle pad, LetterCaseKind @case)
            => spec(w16, pad, @case);

        public static string spec(W32 w, HexPadStyle pad, LetterCaseKind @case)
        {
            if(pad == HexPadStyle.Zero)
                return @case == LetterCaseKind.Upper ? Hex32SpecUC : Hex32Spec;
            else
                 return CaseSpec(@case);
        }

        public static string spec(W32i w, HexPadStyle pad, LetterCaseKind @case)
            => spec(w32, pad, @case);

        public static string spec(W64 w, HexPadStyle pad, LetterCaseKind @case)
        {
            if(pad == HexPadStyle.Zero)
                return @case == LetterCaseKind.Upper ? Hex64SpecUC : Hex64Spec;
            else
                 return CaseSpec(@case);
        }

        public static string spec(W64i w, HexPadStyle pad, LetterCaseKind @case)
            => spec(w64, pad, @case);

        public static string spec(W8 w, LetterCaseKind @case, int? digits)
            => @case == LetterCaseKind.Lower ? digits.Map(n => $"x{n}", () => Hex8Spec) : digits.Map(n => $"X{n}", () => Hex8SpecUC);

        public static string spec(W16 w, LetterCaseKind @case, int? digits)
            => @case == LetterCaseKind.Lower ? digits.Map(n => $"x{n}", () => Hex16Spec) : digits.Map(n => $"X{n}", () => Hex16SpecUC);

        public static string spec(W32 w, LetterCaseKind @case, int? digits)
            => @case == LetterCaseKind.Lower ? digits.Map(n => $"x{n}", () => Hex32Spec) : digits.Map(n => $"X{n}", () => Hex32SpecUC);

        public static string spec(W64 w, LetterCaseKind @case, int? digits)
            => @case == LetterCaseKind.Lower ? digits.Map(n => $"x{n}", () => "x") : digits.Map(n => $"X{n}", () => "X");

        public static ReadOnlySpan<char> ClearSpecs(ReadOnlySpan<char> src)
            => clear(text.format(src));

        [MethodImpl(Inline)]
        public static bool HasPrespec(ReadOnlySpan<char> src)
            => src.Length > 2 && text.begins(src,"0x");

        [MethodImpl(Inline)]
        public static bool HasPostspec(ReadOnlySpan<char> src)
            => src.Length > 0 && skip(src, src.Length - 1) == 'h';

        [MethodImpl(Inline)]
        public static bool HasSpec(ReadOnlySpan<char> src)
            => HasPrespec(src) || HasPostspec(src);

        [MethodImpl(Inline)]
        public static ReadOnlySpan<char> ClearPrespec(ReadOnlySpan<char> src)
            => HasPrespec(src) ? slice(src,2) : src;

        [MethodImpl(Inline)]
        public static HexFormatOptions options(bool zpad = true, bool specifier = true, bool uppercase = false, bool prespec = true,
            bool delimitsegs = true, char? segsep = null, bool delimitblocks = false, char? blocksep = null, char? valsep = null)
        {
            var dst = new HexFormatOptions();
            dst.ZeroPad = zpad;
            dst.CaseIndicator = CaseSpec(uppercase);
            dst.Specifier = specifier;
            dst.Uppercase = uppercase;
            dst.PreSpec = prespec;
            dst.DelimitSegs = delimitsegs;
            dst.SegDelimiter = segsep ?? DataDelimiter;
            dst.DelimitBlocks = delimitblocks;
            dst.BlockDelimiter = blocksep ?? Chars.Null;
            dst.BlockWidth = 0;
            dst.ValueDelimiter = valsep ?? DataDelimiter;
            return dst;
        }

        /// <summary>
        /// Defines the asci character codes for uppercase hex digits 1,2, ..., 9, A, ..., F
        /// </summary>
        public static ReadOnlySpan<byte> UpperHexDigits
            => new byte[]{48,49,50,51,52,53,54,55,56,57,65,66,67,68,69,70};

        /// <summary>
        /// Defines the asci character codes for uppercase hex digits 1,2, ..., 9, a, ..., f
        /// </summary>
        public static ReadOnlySpan<byte> LowerHexDigits
            => new byte[]{48,49,50,51,52,53,54,55,56,57,97,98,99,100,101,102};

        [Op, Closures(Closure)]
        public static string format<T>(ReadOnlySpan<T> src, in HexFormatOptions config)
            where T : unmanaged
        {
            var result = new StringBuilder();
            var count = src.Length;
            for(var i = 0; i<count; i++)
            {
                var formatted = format(skip(src,i), config.ZeroPad, config.Specifier, config.Uppercase, config.PreSpec);
                result.Append(formatted);
                if(i != count - 1)
                    result.Append(config.ValueDelimiter);
            }

            return result.ToString();
        }

        public static HexLineConfig DefaultLineConfig
            => new HexLineConfig(bpl: 32, labels: true, delimiter: Chars.Space, zeropad: true);

        [Op, Closures(Closure)]
        public static void quoted<T>(T src, LetterCaseKind @case, ITextBuffer dst)
            where T : unmanaged
                => quoted_u(src, null, 0, @case, dst);

        [Op, Closures(Closure)]
        public static void quoted<T>(T src, HexSpecKind spec, LetterCaseKind @case, ITextBuffer dst)
            where T : unmanaged
                => quoted_u(src, null, spec, @case, dst);

        [Op, Closures(Closure)]
        public static void quoted<T>(T src, int? digits, LetterCaseKind @case, ITextBuffer dst)
            where T : unmanaged
                => quoted_u(src, digits, 0, @case, dst);

        [Op, Closures(Closure)]
        public static void quoted<T>(T src, int? digits, HexSpecKind spec, LetterCaseKind @case, ITextBuffer dst)
            where T : unmanaged
                => quoted_u(src, digits, spec, @case, dst);

        [MethodImpl(Inline)]
        static void quoted_u<T>(T src, int? digits, HexSpecKind spec, LetterCaseKind @case, ITextBuffer dst)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                dst.Append(text.enquote(HexFormatter.format8u(uint8(src), digits, prespec:spec == SK.PreSpec, postspec:spec == SK.PostSpec, @case:@case)));
            else if(typeof(T) == typeof(ushort))
                dst.Append(text.enquote(HexFormatter.format16u(uint16(src), digits, prespec:spec == SK.PreSpec, postspec:spec == SK.PostSpec, @case:@case)));
            else if(typeof(T) == typeof(uint))
                dst.Append(text.enquote(HexFormatter.format32u(uint32(src), digits, prespec:spec == SK.PreSpec, postspec:spec == SK.PostSpec, @case:@case)));
            else if(typeof(T) == typeof(ulong))
                dst.Append(text.enquote(HexFormatter.format64u(uint64(src), digits, prespec:spec == SK.PreSpec, postspec:spec == SK.PostSpec, @case:@case)));
            else
                quoted_i(src,digits, spec, @case,dst);
        }

        [MethodImpl(Inline)]
        static void quoted_i<T>(T src, int? digits, HexSpecKind spec, LetterCaseKind @case, ITextBuffer dst)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                dst.Append(text.enquote(HexFormatter.format8i(int8(src), digits, prespec:spec == SK.PreSpec, postspec:spec == SK.PostSpec, @case:@case)));
            else if(typeof(T) == typeof(ushort))
                dst.Append(text.enquote(HexFormatter.format16i(int16(src), digits, prespec:spec == SK.PreSpec, postspec:spec == SK.PostSpec, @case:@case)));
            else if(typeof(T) == typeof(uint))
                dst.Append(text.enquote(HexFormatter.format32i(int32(src), digits, prespec:spec == SK.PreSpec, postspec:spec == SK.PostSpec, @case:@case)));
            else if(typeof(T) == typeof(ulong))
                dst.Append(text.enquote(HexFormatter.format64i(int64(src), digits, prespec:spec == SK.PreSpec, postspec:spec == SK.PostSpec, @case:@case)));
            else
                quoted_x(src, digits, spec, @case, dst);
        }

        [MethodImpl(Inline)]
        static void quoted_x<T>(T src, int? digits, HexSpecKind spec, LetterCaseKind @case, ITextBuffer dst)
            where T : unmanaged
        {
            if(size<T>() == 1)
                dst.Append(text.enquote(HexFormatter.format8u(bw8(src), digits, prespec:spec == SK.PreSpec, postspec:spec == SK.PostSpec, @case:@case)));
            else if(size<T>() == 2)
                dst.Append(text.enquote(HexFormatter.format16u(bw16(src), digits, prespec:spec == SK.PreSpec, postspec:spec == SK.PostSpec, @case:@case)));
            else if(size<T>() == 4)
                dst.Append(text.enquote(HexFormatter.format32u(bw32(src), digits, prespec:spec == SK.PreSpec, postspec:spec == SK.PostSpec, @case:@case)));
            else
                dst.Append(text.enquote(HexFormatter.format64u(bw64(src), digits, prespec:spec == SK.PreSpec, postspec:spec == SK.PostSpec, @case:@case)));
        }

        [Op]
        public static uint emit(ReadOnlySpan<byte> src, StreamWriter dst, HexLineConfig? c = null)
        {
            var count = (uint)src.Length;
            if(count == 0)
                return 0;

            var config = c ?? DefaultLineConfig;
            var line = text.buffer();
            var address = Address32.Zero;
            var offset = 1;
            var restart = true;
            var last = count - 1;
            var i=0u;
            var bpl = config.BytesPerLine;

            while(i++ <= last)
            {
                address = (Address32)(i - 1);
                ref readonly var b = ref skip(src,i);
                if(restart)
                {
                    line.Append(string.Format("{0} ", address.Format()));
                    restart = false;
                }

                line.Append(string.Format("{0} ", HexFormatter.format<W8,byte>(b)));

                if(offset != 0 && (offset % bpl == 0))
                {
                    dst.WriteLine(line.Emit());
                    restart = true;
                }

                offset++;
            }

            if(config.ZeroPad)
            {
                var fill = bpl - (count % bpl);
                for(var q=0; q<fill; q++)
                {
                    line.Append("00");
                    if(q != fill - 1)
                        line.Append(" ");
                }
            }
            dst.WriteLine(line.Emit());
            return count;
        }

        /// <summary>
        /// Formats a span pf presumed integral values as a sequence of hex values
        /// </summary>
        /// <param name="src">The source span</param>
        /// <param name="bracket">Whether to format the result as a vector</param>
        /// <param name="sep">The character to use when separating digits</param>
        /// <param name="prespec">Whether to prefix each number with the canonical hex specifier, "0x"</param>
        /// <typeparam name="T">The primal type</typeparam>
        [Op, Closures(Closure)]
        public static string format<T>(ReadOnlySpan<T> src, char sep = Chars.Space, bool prespec = false, bool uppercase = false)
            where T : unmanaged
        {
            var result = new StringBuilder();
            var count = src.Length;
            for(var i = 0; i<count; i++)
            {
                result.Append(format(skip(src,i), true, prespec, uppercase:uppercase, prespec:true));
                if(i != count - 1)
                    result.Append(sep);
            }

            return result.ToString();
        }

        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ISystemFormatter<T> sysformatter<T>()
            where T : struct
                => system_u<T>();

        /// <summary>
        /// Formats a sequence of primal numeric calls as data-formatted hex
        /// </summary>
        /// <param name="src">The source data</param>
        /// <typeparam name="T">The numeric type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static string array<T>(ReadOnlySpan<T> src)
            where T : unmanaged
                => formatter<T>().Format(src, HexArray);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static HexFormatter<T> formatter<T>()
            where T : unmanaged
                => new HexFormatter<T>(sysformatter<T>());

        [Op]
        public static string format(ReadOnlySpan<byte> src, in HexFormatOptions config)
        {
            int? blockwidth = null;
            var dst = new StringBuilder();
            var count = src.Length;
            var pre = (config.Specifier && config.PreSpec) ? "0x" : EmptyString;
            var post = (config.Specifier && !config.PreSpec) ? "h" : EmptyString;
            var spec = CaseSpec(config.Uppercase).ToString();
            var width = config.BlockWidth == 0 ? ushort.MaxValue : config.BlockWidth;
            var counter = 0;

            for(var i=0; i<count; i++)
            {
                var value = skip(src,i).ToString(spec);
                var padded = config.ZeroPad ? value.PadLeft(2, Chars.D0) : value;
                dst.Append(string.Concat(pre, padded, post));
                if(config.DelimitSegs && i != count - 1)
                    dst.Append(config.SegDelimiter);

                if(++counter >= width && config.DelimitBlocks)
                {
                    if(config.BlockDelimiter == Chars.NL || config.BlockDelimiter == Chars.CR)
                        dst.AppendLine();
                    else
                        dst.Append(config.BlockDelimiter);
                    counter = 0;
                }
            }

            return dst.ToString();
        }

        [Op]
        public static string format(W8 w, byte src, bool prespec = false, bool postspec = false, LetterCaseKind @case = LetterCaseKind.Lower)
            => (prespec ? PreSpec : EmptyString)
             + (@case == LetterCaseKind.Lower ? src.ToString(Hex8Spec) : src.ToString(Hex8SpecUC))
             + (postspec ? PostSpec : EmptyString);

        [Op]
        public static string format(W8i w, sbyte src, bool prespec = false, bool postspec = false, LetterCaseKind @case = LetterCaseKind.Lower)
            => (prespec ? PreSpec : EmptyString)
             + (@case == LetterCaseKind.Lower ? src.ToString(Hex8Spec) : src.ToString(Hex8SpecUC))
             + (postspec ? PostSpec : EmptyString);

        [Op]
        public static string format(W16 w, ushort src, bool prespec = false, bool postspec = false, LetterCaseKind @case = LetterCaseKind.Lower)
            => (prespec ? PreSpec : EmptyString)
             + (@case == LetterCaseKind.Lower ? src.ToString(Hex16Spec) : src.ToString(Hex16SpecUC))
             + (postspec ? PostSpec : EmptyString);

        [Op]
        public static string format(W16i w, short src, bool prespec = false, bool postspec = false, LetterCaseKind @case = LetterCaseKind.Lower)
            => (prespec ? PreSpec : EmptyString)
             + (@case == LetterCaseKind.Lower ? src.ToString(Hex16Spec) : src.ToString(Hex16SpecUC))
             + (postspec ? PostSpec : EmptyString);

        [Op]
        public static string format(W32 w, uint src, bool prespec = false, bool postspec = false, LetterCaseKind @case = LetterCaseKind.Lower)
            => (prespec ? PreSpec : EmptyString)
             + (@case == LetterCaseKind.Lower ? src.ToString(Hex32Spec) : src.ToString(Hex32SpecUC))
             + (postspec ? PostSpec : EmptyString);

        [Op]
        public static string format(W32i w, int src, bool prespec = false, bool postspec = false, LetterCaseKind @case = LetterCaseKind.Lower)
            => (prespec ? PreSpec : EmptyString)
             + (@case == LetterCaseKind.Lower ? src.ToString(Hex32Spec) : src.ToString(Hex32SpecUC))
             + (postspec ? PostSpec : EmptyString);

        [Op]
        public static string format(W64 w, ulong src, bool prespec = false, bool postspec = false, LetterCaseKind @case = LetterCaseKind.Lower)
            => (prespec ? PreSpec : EmptyString)
             + (@case == LetterCaseKind.Lower ? src.ToString(Hex64Spec) : src.ToString(Hex64SpecUC))
             + (postspec ? PostSpec : EmptyString);

        [Op]
        public static string format(W64i w, long src, bool prespec = false, bool postspec = false, LetterCaseKind @case = LetterCaseKind.Lower)
            => (prespec ? PreSpec : EmptyString)
             + (@case == LetterCaseKind.Lower ? src.ToString(Hex64Spec) : src.ToString(Hex64SpecUC))
             + (postspec ? PostSpec : EmptyString);

        [Op]
        public static string format(W8 w, byte src, HexPadStyle pad, bool prespec = false, bool postspec = false, LetterCaseKind @case = LetterCaseKind.Lower)
            => (prespec ? PreSpec : EmptyString)
             + src.ToString(spec(w, pad, @case))
             + (postspec ? PostSpec : EmptyString);

        [Op]
        public static string format(W8i w, sbyte src, HexPadStyle pad, bool prespec = false, bool postspec = false, LetterCaseKind @case = LetterCaseKind.Lower)
            => (prespec ? PreSpec : EmptyString)
             + src.ToString(spec(w, pad, @case))
             + (postspec ? PostSpec : EmptyString);

        [Op]
        public static string format(W16 w, ushort src, HexPadStyle pad, bool prespec = false, bool postspec = false, LetterCaseKind @case = LetterCaseKind.Lower)
            => (prespec ? PreSpec : EmptyString)
             + src.ToString(spec(w, pad, @case))
             + (postspec ? PostSpec : EmptyString);

        [Op]
        public static string format(W16i w, short src, HexPadStyle pad, bool prespec = false, bool postspec = false, LetterCaseKind @case = LetterCaseKind.Lower)
            => (prespec ? PreSpec : EmptyString)
             + src.ToString(spec(w, pad, @case))
             + (postspec ? PostSpec : EmptyString);

        [Op]
        public static string format(W32 w, uint src, HexPadStyle pad, bool prespec = false, bool postspec = false, LetterCaseKind @case = LetterCaseKind.Lower)
            => (prespec ? PreSpec : EmptyString)
             + src.ToString(spec(w, pad, @case))
             + (postspec ? PostSpec : EmptyString);

        [Op]
        public static string format(W32i w, int src, HexPadStyle pad, bool prespec = false, bool postspec = false, LetterCaseKind @case = LetterCaseKind.Lower)
            => (prespec ? PreSpec : EmptyString)
             + src.ToString(spec(w,pad,@case))
             + (postspec ? PostSpec : EmptyString);

        [Op]
        public static string format(W64 w, ulong src, HexPadStyle pad, bool prespec = false, bool postspec = false, LetterCaseKind @case = LetterCaseKind.Lower)
            => (prespec ? PreSpec : EmptyString)
             + src.ToString(spec(w, pad, @case))
             + (postspec ? PostSpec : EmptyString);

        [Op]
        public static string format(W64i w, long src, HexPadStyle pad, bool prespec = false, bool postspec = false, LetterCaseKind @case = LetterCaseKind.Lower)
            => (prespec ? PreSpec : EmptyString)
             + src.ToString(spec(w, pad, @case))
             + (postspec ? PostSpec : EmptyString);

        [Op]
        public static string format(NativeSize size, ulong src, bool prespec = false, bool postspec = false, LetterCaseKind @case = LetterCaseKind.Lower)
            => size.Code switch {
                NativeSizeCode.W8 => format(w8, (byte)src, prespec, postspec, @case),
                NativeSizeCode.W16 => format(w16,(ushort)src, prespec, postspec, @case),
                NativeSizeCode.W32 => format(w32,(uint)src, prespec, postspec, @case),
                _ => format(w64,src, prespec, postspec, @case)
            };

        [Op]
        public static string format(NativeSize size, long src, bool prespec = false, bool postspec = false, LetterCaseKind @case = LetterCaseKind.Lower)
            => size.Code switch {
                NativeSizeCode.W8 => format(w8i, (sbyte)src, prespec, postspec, @case),
                NativeSizeCode.W16 => format(w16i,(short)src, prespec, postspec, @case),
                NativeSizeCode.W32 => format(w32i,(int)src, prespec, postspec, @case),
                _ => format(w64i,src, prespec, postspec, @case)
            };

        [Op]
        public static string format(NativeSize size, ulong src, HexPadStyle pad, bool prespec = false, bool postspec = false, LetterCaseKind @case = LetterCaseKind.Lower)
            => size.Code switch {
                NativeSizeCode.W8 => format(w8, (byte)src, pad, prespec, postspec, @case),
                NativeSizeCode.W16 => format(w16,(ushort)src, pad, prespec, postspec, @case),
                NativeSizeCode.W32 => format(w32,(uint)src, pad, prespec, postspec, @case),
                _ => format(w64,src, pad, prespec, postspec, @case)
            };

        [Op]
        public static string format(NativeSize size, long src, HexPadStyle pad, bool prespec = false, bool postspec = false, LetterCaseKind @case = LetterCaseKind.Lower)
            => size.Code switch {
                NativeSizeCode.W8 => format(w8i, (sbyte)src, pad, prespec, postspec, @case),
                NativeSizeCode.W16 => format(w16i,(short)src, pad, prespec, postspec, @case),
                NativeSizeCode.W32 => format(w32i,(int)src, pad, prespec, postspec, @case),
                _ => format(w64i, src, pad, prespec, postspec, @case)
            };

        [Op]
        public static string asmhex(sbyte src, int? digits = null)
            => digits.Map(n => src.ToString($"x{n}"), () => src.ToString(Hex8Spec)) + PostSpec;

        [Op]
        public static string asmhex(byte src, int? digits = null)
            => digits.Map(n => src.ToString($"x{n}"), () => src.ToString(Hex8Spec)) + PostSpec;

        [Op]
        public static string asmhex(short src, int? digits = null)
            => digits.Map(n => src.ToString($"x{n}"), () => src.ToString(Hex16Spec)) + PostSpec;

        [Op]
        public static string asmhex(ushort src, int? digits = null)
            => digits.Map(n => src.ToString($"x{n}"), () => src.ToString(Hex16Spec)) + PostSpec;

        [Op]
        public static string asmhex(int src, int? digits = null)
            => digits.Map(n => src.ToString($"x{n}"), () => src.ToString("x")) + PostSpec;

        [Op]
        public static string asmhex(uint src, int? digits = null)
            => digits.Map(n => src.ToString($"x{n}"), () => src.ToString("x8")) + PostSpec;

        [Op]
        public static string asmhex(ulong src, int? digits = null)
            => digits.Map(n => src.ToString($"x{n}"), () => src.ToString("x")) + PostSpec;

        [Op]
        public static string asmhex(long src, int? digits = null)
            => digits.Map(n => src.ToString($"x{n}"), () => src.ToString("x")) + PostSpec;

        [Op]
        public static string format8u(byte src, int? digits = null, bool prespec = false, bool postspec = false, LetterCaseKind @case = LetterCaseKind.Lower)
            => (prespec ? HexFormatSpecs.PreSpec : EmptyString)
            + src.ToString(spec(w8, @case, digits))
            + (postspec ? PostSpec : EmptyString);

        [Op]
        public static string format8i(sbyte src, int? digits = null, bool prespec = false, bool postspec = false, LetterCaseKind @case = LetterCaseKind.Lower)
            => (prespec ? HexFormatSpecs.PreSpec : EmptyString)
            + src.ToString(spec(w8, @case, digits))
            + (postspec ? PostSpec : EmptyString);

        [Op]
        public static string format16i(short src, int? digits = null, bool prespec = false, bool postspec = false, LetterCaseKind @case = LetterCaseKind.Lower)
            => (prespec ? HexFormatSpecs.PreSpec : EmptyString)
            + src.ToString(spec(w16, @case, digits))
            + (postspec ? PostSpec : EmptyString);

        [Op]
        public static string format16u(ushort src, int? digits = null, bool prespec = false, bool postspec = false, LetterCaseKind @case = LetterCaseKind.Lower)
            => (prespec ? HexFormatSpecs.PreSpec : EmptyString)
            + src.ToString(spec(w16, @case, digits))
            + (postspec ? PostSpec : EmptyString);

        [Op]
        public static string format32i(int src, int? digits = null, bool prespec = false, bool postspec = false, LetterCaseKind @case = LetterCaseKind.Lower)
            => (prespec ? HexFormatSpecs.PreSpec : EmptyString)
            + src.ToString(spec(w32, @case, digits))
            + (postspec ? PostSpec : EmptyString);

        [Op]
        public static string format32u(uint src, int? digits = null, bool prespec = false, bool postspec = false, LetterCaseKind @case = LetterCaseKind.Lower)
            => (prespec ? HexFormatSpecs.PreSpec : EmptyString)
            + src.ToString(spec(w32, @case, digits))
            + (postspec ? PostSpec : EmptyString);

        [Op]
        public static string format64i(long src, int? digits = null, bool prespec = false, bool postspec = false, LetterCaseKind @case = LetterCaseKind.Lower)
            => (prespec ? HexFormatSpecs.PreSpec : EmptyString)
            + src.ToString(spec(w64, @case, digits))
            + (postspec ? PostSpec : EmptyString);

        [Op]
        public static string format64u(ulong src, int? digits = null, bool prespec = false, bool postspec = false, LetterCaseKind @case = LetterCaseKind.Lower)
            => (prespec ? HexFormatSpecs.PreSpec : EmptyString)
            + src.ToString(spec(w64, @case, digits))
            + (postspec ? PostSpec : EmptyString);

        [Op]
        public static string bytes(ushort src)
            => format(core.bytes(src), HexData);

        [Op]
        public static string bytes(short src)
            => format(core.bytes(src), HexData);

        [Op]
        public static string bytes(int src)
            => format(core.bytes(src), HexData);

        [Op]
        public static string bytes(uint src)
            => format(core.bytes(src), HexData);

        [Op]
        public static string bytes(long src)
            => format(core.bytes(src), HexData);

        [Op]
        public static string bytes(ulong src)
            => format(core.bytes(src), HexData);

        public static string bytes<T>(T src)
            where T : unmanaged
                => format(core.bytes(src), HexData);

        [Op, Closures(AllNumeric)]
        public static string format<T>(T src, bool zpad, bool specifier, bool uppercase = false, bool prespec = true)
            where T : unmanaged
                => format_u(src, zpad, specifier, uppercase, prespec);

        [MethodImpl(Inline)]
        static string format_u<T>(T src, bool zpad = true, bool specifier = true, bool uppercase = false, bool prespec = true)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return uint8(src).FormatHex(zpad, specifier, uppercase, prespec);
            else if(typeof(T) == typeof(ushort))
                return uint16(src).FormatHex(zpad, specifier, uppercase, prespec);
            else if(typeof(T) == typeof(uint))
                return uint32(src).FormatHex(zpad, specifier, uppercase, prespec);
            else if(typeof(T) == typeof(ulong))
                return uint64(src).FormatHex(zpad, specifier, uppercase, prespec);
            else
                return format_i(src,zpad,specifier,uppercase,prespec);
        }

        [MethodImpl(Inline)]
        static string format_i<T>(T src, bool zpad = true, bool specifier = true, bool uppercase = false, bool prespec = true)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                return int8(src).FormatHex(zpad, specifier, uppercase, prespec);
            else if(typeof(T) == typeof(short))
                return int16(src).FormatHex(zpad, specifier, uppercase, prespec);
            else if(typeof(T) == typeof(int))
                return int32(src).FormatHex(zpad, specifier, uppercase, prespec);
            else if(typeof(T) == typeof(long))
                return int64(src).FormatHex(zpad, specifier, uppercase, prespec);
            else
                return format_f(src,zpad,specifier,uppercase,prespec);
        }

        [MethodImpl(Inline)]
        static string format_f<T>(T src, bool zpad = true, bool specifier = true, bool uppercase = false, bool prespec = true)
            where T : unmanaged
        {
            if(typeof(T) == typeof(float))
                return float32(src).FormatHex(zpad, specifier, uppercase, prespec);
            else if(typeof(T) == typeof(double))
                return float64(src).FormatHex(zpad, specifier, uppercase, prespec);
            else
                throw no<T>();
        }

        [MethodImpl(Inline), Op]
        public static string format<W,T>(T value, W w = default, bool postspec = false, LetterCaseKind @case = LetterCaseKind.Lower)
            where W : unmanaged, IDataWidth
            where T : unmanaged
        {
            if(typeof(W) == typeof(W8))
                return format(w8, bw8(value), postspec:postspec, @case:@case);
            else if(typeof(W) == typeof(W16))
                return format(w16, bw16(value), postspec:postspec, @case:@case);
            else if(typeof(W) == typeof(W32))
                return format(w32, bw32(value), postspec:postspec, @case:@case);
            else
                return format(w64, bw64(value), postspec:postspec, @case:@case);
        }

        [MethodImpl(Inline)]
        internal static ISystemFormatter<T> system_u<T>()
            where T : struct
        {
            if(typeof(T) == typeof(byte))
                return generalize<HexFormatter8u,ISystemFormatter<T>>(HexFormatter8u.Service);
            else if(typeof(T) == typeof(ushort))
                return generalize<HexFormatter16u,ISystemFormatter<T>>(HexFormatter16u.Service);
            else if(typeof(T) == typeof(uint))
                return generalize<HexFormatter32u,ISystemFormatter<T>>(HexFormatter32u.Service);
            else if(typeof(T) == typeof(ulong))
                return generalize<HexFormatter64u,ISystemFormatter<T>>(HexFormatter64u.Service);
            else
                return system_i<T>();
        }

        [MethodImpl(Inline)]
        static ISystemFormatter<T> system_i<T>()
            where T : struct
        {
            if(typeof(T) == typeof(sbyte))
                return generalize<HexFormatter8i,ISystemFormatter<T>>(HexFormatter8i.Service);
            else if(typeof(T) == typeof(short))
                return generalize<HexFormatter16i,ISystemFormatter<T>>(HexFormatter16i.Service);
            else if(typeof(T) == typeof(int))
                return generalize<HexFormatter32i,ISystemFormatter<T>>(HexFormatter32i.Service);
            else if(typeof(T) == typeof(long))
                return generalize<HexFormatter64i,ISystemFormatter<T>>(HexFormatter64i.Service);
            else
                return system_f<T>();
        }

        [MethodImpl(Inline)]
        static ISystemFormatter<T> system_f<T>()
            where T : struct
        {
            if(typeof(T) == typeof(float))
                return generalize<HexFormatter32f,ISystemFormatter<T>>(HexFormatter32f.Service);
            else if(typeof(T) == typeof(double))
                return generalize<HexFormatter64f,ISystemFormatter<T>>(HexFormatter64f.Service);
            else
                throw no<T>();
        }

        readonly struct HexFormatter8i : ISystemFormatter<HexFormatter8i,sbyte>
        {
            public static HexFormatter8i Service => default;

            [MethodImpl(Inline)]
            public string Format(sbyte src, string format = null)
                => src.ToString(format ?? string.Empty);
        }

        readonly struct HexFormatter8u : ISystemFormatter<HexFormatter8u,byte>
        {
            public static HexFormatter8u Service => default;

            [MethodImpl(Inline)]
            public string Format(byte src, string format = null)
                => src.ToString(format ?? EmptyString);
        }

        readonly struct HexFormatter16i : ISystemFormatter<HexFormatter16i,short>
        {
            public static HexFormatter16i Service => default;

            [MethodImpl(Inline)]
            public string Format(short src, string format = null)
                => src.ToString(format ?? EmptyString);
        }

        readonly struct HexFormatter16u : ISystemFormatter<HexFormatter16u,ushort>
        {
            public static HexFormatter16u Service =>  default;

            [MethodImpl(Inline)]
            public string Format(ushort src, string format = null)
                => src.ToString(format ?? EmptyString);
        }

        readonly struct HexFormatter32i : ISystemFormatter<HexFormatter32i,int>
        {
            public static HexFormatter32i Service => default;

            [MethodImpl(Inline)]
            public string Format(int src, string format = null)
                => src.ToString(format ?? EmptyString);
        }

        readonly struct HexFormatter32u : ISystemFormatter<HexFormatter32u,uint>
        {
            public static HexFormatter32u Service =>  default;

            [MethodImpl(Inline)]
            public string Format(uint src, string format = null)
                => src.ToString(format ?? EmptyString);
        }

        readonly struct HexFormatter64i : ISystemFormatter<HexFormatter64i,long>
        {
            public static HexFormatter64i Service =>  default;

            [MethodImpl(Inline)]
            public string Format(long src, string format = null)
                => src.ToString(format ?? EmptyString);
        }

        readonly struct HexFormatter64u : ISystemFormatter<HexFormatter64u,ulong>
        {
            public static HexFormatter64u Service =>  default;

            [MethodImpl(Inline)]
            public string Format(ulong src, string format = null)
                => src.ToString(format ?? EmptyString);
        }

        readonly struct HexFormatter32f : ISystemFormatter<HexFormatter32f,float>
        {
            public static HexFormatter32f Service =>  default;

            [MethodImpl(Inline)]
            public string Format(float src, string format = null)
                => BitConverter.SingleToInt32Bits(src).ToString(format ?? EmptyString);
        }

        readonly struct HexFormatter64f : ISystemFormatter<HexFormatter64f,double>
        {
            public static HexFormatter64f Service =>  default;

            [MethodImpl(Inline)]
            public string Format(double src, string format = null)
                => BitConverter.DoubleToInt64Bits(src).ToString(format ?? EmptyString);
        }

        [MethodImpl(Inline)]
        static ref readonly F generalize<X,F>(in X src)
            where X : struct
                => ref @as<X,F>(src);
    }
}