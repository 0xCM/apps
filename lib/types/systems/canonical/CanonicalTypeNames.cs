//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{

    using static Root;

    [LiteralProvider(ClrLiteralKind.String)]
    public readonly struct CanonicalTypeNames
    {
        public const string V = "v{0}<t:{1}>";

        public const string C = "c{0}";

        public const string I = "i{0}";

        public const string U = "u{0}";

        public const string F = "f{0}";

        public const string S = "string";

        public const string St = "s<t:{0}>";

        public const string Sn = "s<n:{0}>";

        public const string Snt = "s<n:{0},t:{1}>";

        public const string Bv = "bv{0}";

        public const string Seq = "seq<t:{0}>";

        public const string SeqN = "seq<n:{0},t:{1}>";

        public const string Bit = "bit";

        public const string Bits = "bits<t:{0}>";

        public const string BitsN = "bits<n:{0},t:{1}>";

        /// <summary>
        /// Defines a signed integer type of specified bit-width
        /// </summary>
        /// <param name="n">The width</param>
        [TypeFactory(I)]
        public static string i(uint n) => string.Format(I,n);

        /// <summary>
        /// Defines an unsigned integer type of specified bit-width
        /// </summary>
        /// <param name="n">The width</param>
        [TypeFactory(U)]
        public static string u(uint n) => string.Format(U,n);

        /// <summary>
        /// Defines a sequence of arbitrary length over a parametric type
        /// </summary>
        /// <param name="type">The element type</param>
        [TypeFactory(Seq)]
        public static string seq(IType type) => string.Format(Seq, type.Format());

        /// <summary>
        /// Defines a sequence of parametric length over a parametric type
        /// </summary>
        /// <param name="n">The sequence length</param>
        /// <param name="type">The elememnt type</param>
        [TypeFactory(SeqN)]
        public static string seq(uint n, IType type) => string.Format(SeqN, type.Format(), n);

        /// <summary>
        /// Defines a character type of parametric width no greater than 32
        /// </summary>
        /// <param name="n">The bit width</param>
        [TypeFactory(C)]
        public static string c(byte n) => n <= 32 ? string.Format(C, n) : EmptyString;

        /// <summary>
        /// Defines a string of arbitrary length
        /// </summary>
        [TypeFactory(S)]
        public static string s() => S;

        [TypeFactory(Bit)]
        public static string bit() => Bit;

        [TypeFactory(Sn)]
        public static string s(uint n) => string.Format(Sn, n);

        /// <summary>
        /// Defines a string of arbitrary length over a parametric character type
        /// </summary>
        /// <param name="t">The character type</param>
        [TypeFactory(St)]
        public static string s(ICharType t) => string.Format(St, t.Format());

        /// <summary>
        /// Defines a string of parametric length over a parametric character type
        /// </summary>
        /// <param name="t">The character type</param>
        [TypeFactory(Snt)]
        public static string s(uint n, ICharType t) => string.Format(Snt, t.Format());

        /// <summary>
        /// Defines a sequence of bits of length bounded by a parametric type
        /// </summary>
        /// <param name="t">The type</param>
        [TypeFactory(Bits)]
        public static string bits(IScalarType t) => string.Format(Bits, t.Format());

        /// <summary>
        /// Defines a sequence of bits of length bounded by both parametric type and length
        /// </summary>
        /// <param name="t">The type</param>
        /// <param name="t">The length</param>
        [TypeFactory(BitsN)]
        public static string bits(uint n, IScalarType t) => string.Format(BitsN, t.Format());

        /// <summary>
        /// Defines a bitvector type of content width n
        /// </summary>
        /// <param name="n">The bitvector width</param>
        [TypeFactory(Bv)]
        public static string bv(uint n) => string.Format(Bv, n);

        /// <summary>
        /// Defines an n-component vector over a specified cell type
        /// </summary>
        /// <param name="cells">The cell type</param>
        /// <param name="n">The number of vector components</param>
        public static string v(uint n, IScalarType cells) => string.Format(V, n, cells.Format());
    }
}