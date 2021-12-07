//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Root;

    [ApiHost]
    public readonly struct CanonicalSpecs
    {
        internal const string V = "v{0}<t:{1}>";

        internal const string C = "c{0}";

        internal const string Ct = "c{0}<t:{1}>";

        internal const string I = "i{0}";

        internal const string U = "u{0}";

        internal const string F = "f{0}";

        internal const string S = "string";

        internal const string St = "s<t:{0}>";

        internal const string Sn = "s<n:{0}>";

        internal const string Snt = "s<n:{0},t:{1}>";

        internal const string Bv = "bv{0}";

        internal const string Seq = "seq<t:{0}>";

        internal const string SeqN = "seq<n:{0},t:{1}>";

        internal const string Bit = "bit";

        internal const string Bits = "bits<t:{0}>";

        internal const string BitsN = "bits<n:{0},t:{1}>";

        internal const string Kind = "kind<n:{0}>";

        /// <summary>
        /// Defines a signed integer type of specified bit-width
        /// </summary>
        /// <param name="n">The width</param>
        [TypeFactory(I)]
        public static TypeSpecifier i(uint n) => string.Format(I,n);

        /// <summary>
        /// Defines an unsigned integer type of specified bit-width
        /// </summary>
        /// <param name="n">The width</param>
        [TypeFactory(U)]
        public static TypeSpecifier u(uint n) => string.Format(U,n);

        /// <summary>
        /// Defines a sequence of arbitrary length over a parametric type
        /// </summary>
        /// <param name="type">The element type</param>
        [TypeFactory(Seq)]
        public static TypeSpecifier seq(IType type) => string.Format(Seq, type.Format());

        /// <summary>
        /// Defines a sequence of parametric length over a parametric type
        /// </summary>
        /// <param name="n">The sequence length</param>
        /// <param name="type">The elememnt type</param>
        [TypeFactory(SeqN)]
        public static TypeSpecifier seq(uint n, IType type) => string.Format(SeqN, type.Format(), n);

        /// <summary>
        /// Defines a character type of parametric width no greater than 32
        /// </summary>
        /// <param name="n">The bit width</param>
        [TypeFactory(C)]
        public static TypeSpecifier c(byte n) => n <= 32 ? string.Format(C, n) : EmptyString;

        /// <summary>
        /// Defines a character type of parametric kind and parametric width no greater than 32
        /// </summary>
        /// <param name="n">The bit width</param>
        [TypeFactory(C)]
        public static TypeSpecifier ct(byte n, IType t) => n <= 32 ? string.Format(C, n, t.Format()) : EmptyString;

        /// <summary>
        /// Defines a type classifier
        /// </summary>
        /// <param name="name">The class name</param>
        [TypeFactory(S)]
        public static NamedKind kind(string name) => string.Format(Kind,name);

        /// <summary>
        /// Defines a string of arbitrary length
        /// </summary>
        [TypeFactory(S)]
        public static TypeSpecifier s() => S;

        /// <summary>
        /// Defines teh bit type
        /// </summary>
        [TypeFactory(Bit)]
        public static TypeSpecifier bit() => Bit;

        /// <summary>
        /// Defines a string of parametric length
        /// </summary>
        /// <param name="n">The string length</param>
        [TypeFactory(Sn)]
        public static TypeSpecifier s(uint n) => string.Format(Sn, n);

        /// <summary>
        /// Defines a string of arbitrary length over a parametric character type
        /// </summary>
        /// <param name="t">The character type</param>
        [TypeFactory(St)]
        public static TypeSpecifier s(ICharType t) => string.Format(St, t.Format());

        /// <summary>
        /// Defines a string of parametric length over a parametric character type
        /// </summary>
        /// <param name="t">The character type</param>
        [TypeFactory(Snt)]
        public static TypeSpecifier s(uint n, ICharType t) => string.Format(Snt, t.Format());

        /// <summary>
        /// Defines a sequence of bits of length bounded by a parametric type
        /// </summary>
        /// <param name="t">The type</param>
        [TypeFactory(Bits)]
        public static TypeSpecifier bits(IScalarType t) => string.Format(Bits, t.Format());

        /// <summary>
        /// Defines a sequence of bits of length bounded by both parametric type and length
        /// </summary>
        /// <param name="t">The type</param>
        /// <param name="t">The length</param>
        [TypeFactory(BitsN)]
        public static TypeSpecifier bits(uint n, IScalarType t) => string.Format(BitsN, t.Format());

        /// <summary>
        /// Defines a bitvector type of content width n
        /// </summary>
        /// <param name="n">The bitvector width</param>
        [TypeFactory(Bv)]
        public static TypeSpecifier bv(uint n) => string.Format(Bv, n);

        /// <summary>
        /// Defines an n-component vector over a specified cell type
        /// </summary>
        /// <param name="cells">The cell type</param>
        /// <param name="n">The number of vector components</param>
        public static TypeSpecifier v(uint n, IScalarType cells) => string.Format(V, n, cells.Format());
    }
}