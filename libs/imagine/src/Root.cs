//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Z = Zero;
    using NK = Z0.NumericKind;
    using CC = System.Runtime.InteropServices.CallingConvention;
    using TE = TextEncodingKind;

    class Root
    {
        public const string EmptyString = "";

        public const MethodImplOptions Inline = MethodImplOptions.AggressiveInlining;

        /// <summary>
        /// Specifies unsigned integral types of widths <see cref='NumericWidths'/>
        /// </summary>
        public const NK UnsignedInts = NK.UnsignedInts;

        /// <summary>
        /// Specifies signed integral types of widths <see cref='NumericWidths'/>
        /// </summary>
        public const NK SignedInts = NK.SignedInts;

        /// <summary>
        /// Specifies signed and unsigned integral types of widths <see cref='NumericWidths'/>
        /// </summary>
        public const NK Integers = NK.Integers;

        /// <summary>
        /// Specifies floating-point primitive kinds
        /// </summary>
        public const NK Floats = NK.Floats;

        /// <summary>
        /// Specifies all numeric primitive kinds
        /// </summary>
        public const NK AllNumeric = NK.All;

        /// <summary>
        /// Specifies numeric types of width <see cref='W8'/>
        /// </summary>
        public const NK Numeric8k = NK.Width8;

        /// <summary>
        /// Specifies numeric types of width <see cref='W64'/>
        /// </summary>
        public const NK Numeric64k = NK.Width64;

        /// <summary>
        /// Specifies numeric types of width <see cref='W8'/>, <see cref='W16'/> and <see cref='W32'/>
        /// </summary>
        public const NK Numeric8x16x32k = NK.Width8 | NK.Width16 | NK.Width32;

        /// <summary>
        /// Specifies numeric types of width <see cref='W16'/>, <see cref='W32'/>, and <see cref='W64'/>
        /// </summary>
        public const NK Numeric16x32x64k = NK.Width16 | NK.Width32 | NK.Width64;

        /// <summary>
        /// Specifies numeric types of width <see cref='W32'/>, and <see cref='W64'/>
        /// </summary>
        public const NK Numeric32x64k = NK.Width32 | NK.Width64;

        /// <summary>
        /// Specifies an usigned integral type of width <see cref='W8'/>
        /// </summary>
        public const NK UInt8k = NK.U8;

        /// <summary>
        /// Specifies an usigned integral type of width <see cref='W16'/>
        /// </summary>
        public const NK UInt16k = NK.U16;

        /// <summary>
        /// Specifies an usigned integral type of width <see cref='W32'/>
        /// </summary>
        public const NK UInt32k = NK.U32;

        /// <summary>
        /// Specifies an usigned integral type of width <see cref='W64'/>
        /// </summary>
        public const NK UInt64k = NK.U64;

        /// <summary>
        /// Specifies a signed integral type of width <see cref='W8'/>
        /// </summary>
        public const NK Int8k = NK.I8;

        /// <summary>
        /// Specifies a signed integral type of width <see cref='W16'/>
        /// </summary>
        public const NK Int16k = NK.I16;

        /// <summary>
        /// Specifies a signed integral type of width <see cref='W32'/>
        /// </summary>
        public const NK Int32k = NK.I32;

        /// <summary>
        /// Specifies a signed integral type of width <see cref='W64'/>
        /// </summary>
        public const NK Int64k = NK.I64;

        /// <summary>
        /// Specifies a floating point type of width <see cref='W32'/>
        /// </summary>
        public const NK Float32k = NK.F32;

        /// <summary>
        /// Specifies a floating point type of width <see cref='W64'/>
        /// </summary>
        public const NK Float64k = NK.F64;

        /// <summary>
        /// Specifies signed and unsigned integral types of width <see cref='W8'/> and <see cref='W16'/>
        /// </summary>
        public const NK Int8x16k = NK.I8 | NK.U8 | NK.I16 | NK.U16;

        /// <summary>
        /// Specifies signed and unsigned integral types of width <see cref='W8'/>, <see cref='W16'/>, and <see cref='W32'/>
        /// </summary>
        public const NK Int8x16x32k = NK.I8 | NK.U8 | NK.I16 | NK.U16 | NK.I32 | NK.U32;

        /// <summary>
        /// Specifies signed and unsigned integral types of width <see cref='W16'/>, <see cref='W32'/>, and <see cref='W64'/>
        /// </summary>
        public const NK Int16x32x64k = NK.I16 | NK.U16 | NK.I32 | NK.U32 | NK.I64 | NK.U64;

        /// <summary>
        /// Specifies signed and unsigned integral types of width <see cref='W8'/> and <see cref='W64'/>
        /// </summary>
        public const NK Int8x64k = NK.I8 | NK.U8 | NK.I64 | NK.U64;

        public const NK Integers8x64k = Int8x64k;

        public const NK Numeric8x16k = Int8x16k;

        public const NK UInt8x64k = Int8x64k;

        public const NK UInt8x16k = Int8x16k;

        public const NK UInt8x16x32k = Int8x16x32k;

        public const NK UInt16x32x64k = Int16x32x64k;

        /// <summary>
        /// The zero-value for an 8-bit signed integer
        /// </summary>
        public const sbyte z8i = Z.z8i;

        /// <summary>
        /// The zero-value for an 8-bit usigned integer
        /// </summary>
        public const byte z8 = Z.z8;

        /// <summary>
        /// The zero-value for a 16-bit signed integer
        /// </summary>
        public const short z16i = Z.z16i;

        /// <summary>
        /// The zero-value for a 16-bit unsigned integer
        /// </summary>
        public const ushort z16 = Z.z16;

        /// <summary>
        /// The zero-value for a 32-bit signed integer
        /// </summary>
        public const int z32i = Z.z32i;

        /// <summary>
        /// The zero-value for a 32-bit usigned integer
        /// </summary>
        public const uint z32 = Z.z32i;

        /// <summary>
        /// The zero-value for a 64-bit signed integer
        /// </summary>
        public const long z64i = Z.z64i;

        /// <summary>
        /// The zero-value for a 64-bit usigned integer
        /// </summary>
        public const ulong z64 = Z.z64;

        /// <summary>
        /// Zero, presented as a character
        /// </summary>
        public const char z16c = Z.z16c;

        /// <summary>
        /// The zero-value for a 32-bit float
        /// </summary>
        public const float z32f = Z.z32f;

        /// <summary>
        /// The zero-value for a 64-bit float
        /// </summary>
        public const double z64f = Z.z64f;

        /// <summary>
        /// The zero-value for a 128-bit float
        /// </summary>
        public const decimal z128f = 0;

        /// <summary>
        /// The zero-value for a bool
        /// </summary>
        public const bool z8b = Z.z8b;

        /// <summary>
        /// Specifies the <see cref='CC.StdCall'/> calling convention where the
        /// callee is responsible for stack management
        /// </summary>
        /// <remarks>
        /// This is the default PInvoke convention
        /// </remarks>
        public const CC StdCall = CC.StdCall;

        /// <summary>
        /// Specifies the <see cref='CC.Cdecl'/> calling convention where the caller
        /// is responsible for stack management
        /// </summary>
        /// <remarks>
        /// According to the runtime documentation, "This enables calling functions with varargs, which
        /// makes it appropriate to use for methods that accept a variable number of parameters,
        /// such as Printf".
        /// </remarks>
        public const CC Cdecl = CC.Cdecl;

        /// <summary>
        /// Specifies the <see cref='CC.ThisCall'/> calling convention where first argument is <see cref='this'/> and is placed in ECX/RCX
        /// </summary>
        public const CC ThisCall = CC.ThisCall;

        /// <summary>
        /// An abbreviation for the ridiculously long "StringComparison.InvariantCultureIgnoreCase"
        /// </summary>
        public const StringComparison NoCase = StringComparison.InvariantCultureIgnoreCase;

        /// <summary>
        /// An abbreviation for the somewhat verbose "StringComparison.InvariantCulture"
        /// </summary>
        public const StringComparison Cased = StringComparison.InvariantCulture;

        public static Uncased uncased() => default;

        /// <summary>
        /// The end-of-line escape sequence
        /// </summary>
        public const string Eol = Chars.Eol;

        /// <summary>
        /// The default delimiter to use when formatting structured text
        /// </summary>
        public const char FieldDelimiter = Chars.Pipe;

        /// <summary>
        /// What else could this be?
        /// </summary>
        public const char Space = ' ';

        /// <summary>
        /// Evidence of absence
        /// </summary>
        public const char AsciNone = '\0';

        public const TE unicode = TE.Unicode;

        public const TE ASCII = TE.Asci;

        public const TE UTF8 = TE.Utf8;

        /// <summary>
        /// Canonical return value for search operation that returns a nonnegative value upon success
        /// </summary>
        public const int NotFound = -1;

        /// <summary>
        /// Indicates that emitted content should overwrite whatever file content may exist
        /// </summary>
        public const FileWriteMode Overwrite = FileWriteMode.Overwrite;

        /// <summary>
        /// The number of bytes in a page of memory
        /// </summary>
        public const ushort PageSize = 0x1000;


        public const MethodImplOptions NotInline = MethodImplOptions.NoInlining;

        public const char ListDelimiter = Chars.Comma;


        public const LayoutKind StructLayout = LayoutKind.Sequential;
    }
}