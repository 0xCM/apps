//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static Root;

    [ApiHost]
    public readonly struct TypeSyntax
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

        internal const string Kind = "kind<k:{0}>";

        internal const string Block = "block<n:{0},t:{1}>";

        internal const string Address = "address";

        internal const string Address8 = "address<w:8>";

        internal const string Address16 = "address<w:16>";

        internal const string Address32 = "address<w:32>";

        internal const string Address64 = "address<w:64>";

        internal const string AddressW = "address<w:{0}>";

        internal const string Enum = "enum<name:{0},base:{1}>";

        internal const string Scalar = "{0}{1}";

        internal const string Array = "array<t:{0}>";

        internal const string Clr = "clr.{0}";

        internal const string Literal = "literal<t:{0}>";

        internal const string Constant = "const<t:{0}>";

        internal const string Num = "num<t:{0}>";

        internal const string Span = "span<t:{0}>";

        internal const string ConstSpan = "cspan<t:{0}>";

        internal const string Disp = "disp<w:{0}>";

        internal const string Disp8 = "disp<w:8>";

        internal const string Disp16 = "disp<w:16>";

        internal const string Disp32 = "disp<w:32>";

        internal const string Disp64 = "disp<w:64>";

        internal const string Imm = "imm<w:{0}>";

        internal const string Imm8 = "imm<w:8>";

        internal const string Imm16 = "imm<w:16>";

        internal const string Imm32 = "imm<w:32>";

        internal const string Imm64 = "imm<w:64>";

        internal const string Mem = "mem<w:{0}>";

        internal const string Mem8 = "mem<w:8>";

        internal const string Mem16 = "mem<w:16>";

        internal const string Mem32 = "mem<w:32>";

        internal const string Mem64 = "mem<w:64>";

        internal const string Mem128 = "mem<w:128>";

        internal const string Mem256 = "mem<w:256>";

        internal const string Mem512 = "mem<w:512>";

        internal const string Lookup = "lookup<k:{0},v:{1}>";

        internal static string symbol<K>(K kind)
            where K : unmanaged, Enum
                => Symbols.expr(kind).Format();

        [TypeSyntax(Num)]
        public static TypeSpec num(TypeSpec type) => string.Format(Num, type);

        [TypeSyntax(Clr)]
        public static TypeSpec clr(ClrPrimitiveKind kind) => string.Format(Clr, symbol(kind));

        [TypeSyntax(Disp)]
        public static TypeSpec disp(BitWidth w) => string.Format(Disp, w);

        [TypeSyntax(Imm)]
        public static TypeSpec imm(BitWidth w) => string.Format(Imm, w);

        [TypeSyntax(Mem)]
        public static TypeSpec mem(BitWidth w) => string.Format(Mem, w);

        /// <summary>
        /// Defines a scalar type of specified class and width
        /// </summary>
        [TypeSyntax(Scalar)]
        public static TypeSpec scalar(ScalarClass @class, BitWidth w) => string.Format(Scalar, symbol(@class), w);

        /// <summary>
        /// Defines a scalar type predicated on a specified underlying type
        /// </summary>
        [TypeSyntax(Scalar)]
        public static TypeSpec scalar(TypeSpec type) => string.Format(Scalar, type);

        /// <summary>
        /// Defines a refined literal sequence
        /// </summary>
        /// <param name="n">The sequence name</param>
        /// <param name="@base">The sequence term type</param>
        [TypeSyntax(Enum)]
        public static TypeSpec @enum(string name, TypeSpec @base) => string.Format(Enum, name, @base);

        /// <summary>
        /// Defines an address type with default width
        /// </summary>
        [TypeSyntax(AddressW)]
        public static TypeSpec address() => Address;

        /// <summary>
        /// Defines an address type of specified width
        /// </summary>
        /// <param name="n">The bit-width</param>
        [TypeSyntax(AddressW)]
        public static TypeSpec address(uint w) => string.Format(I,w);

        /// <summary>
        /// Defines a signed integer type of specified bit-width
        /// </summary>
        /// <param name="n">The width</param>
        [TypeSyntax(I)]
        public static TypeSpec i(uint n) => string.Format(I,n);

        /// <summary>
        /// Defines an unsigned integer type of specified bit-width
        /// </summary>
        /// <param name="n">The width</param>
        [TypeSyntax(U)]
        public static TypeSpec u(uint n) => string.Format(U,n);

        /// <summary>
        /// Defines a sequence of arbitrary length over a parametric type
        /// </summary>
        /// <param name="type">The element type</param>
        [TypeSyntax(Seq)]
        public static TypeSpec seq(TypeSpec type) => string.Format(Seq, type.Format());

        /// <summary>
        /// Defines a sequence of parametric length over a parametric type
        /// </summary>
        /// <param name="n">The sequence length</param>
        /// <param name="type">The element type</param>
        [TypeSyntax(SeqN)]
        public static TypeSpec seq(uint n, TypeSpec type) => string.Format(SeqN, type.Format(), n);

        /// <summary>
        /// Defines a 1-dimensional array over a specified element type
        /// </summary>
        /// <param name="e">The array element type</param>
        [TypeSyntax(Scalar)]
        public static TypeSpec array(TypeSpec e) => string.Format(Array, e.Format());

        /// <summary>
        /// Defines a character type of parametric width no greater than 32
        /// </summary>
        /// <param name="n">The bit width</param>
        [TypeSyntax(C)]
        public static TypeSpec c(byte n) => n <= 32 ? string.Format(C, n) : EmptyString;

        /// <summary>
        /// Defines a type that represents a readonly span over a specified element type
        /// </summary>
        /// <param name="element">The element type</param>
        [TypeSyntax(ConstSpan)]
        public static TypeSpec cspan(TypeSpec element) => string.Format(ConstSpan, element);

        /// <summary>
        /// Defines a type that represents a span over a specified element type
        /// </summary>
        /// <param name="element">The element type</param>
        [TypeSyntax(Span)]
        public static TypeSpec span(TypeSpec element) => string.Format(Span, element);

        /// <summary>
        /// Defines a type that represents a span or readonly span over a specified element type
        /// </summary>
        /// <param name="element">The element type</param>
        /// <param name="@const">Whether the type is readonly</param>
        public static TypeSpec span(TypeSpec element, bool @const) => @const ? cspan(element) : span(element);

        /// <summary>
        /// Defines a character type of parametric kind and parametric width no greater than 32
        /// </summary>
        /// <param name="n">The bit width</param>
        [TypeSyntax(C)]
        public static TypeSpec ct(byte n, TypeSpec t) => n <= 32 ? string.Format(C, n, t.Format()) : EmptyString;

        /// <summary>
        /// Defines a type classifier
        /// </summary>
        /// <param name="name">The class name</param>
        [TypeSyntax(S)]
        public static NamedKind kind(string name) => string.Format(Kind,name);

        /// <summary>
        /// Defines a string of arbitrary length
        /// </summary>
        [TypeSyntax(S)]
        public static TypeSpec s() => S;

        /// <summary>
        /// Defines teh bit type
        /// </summary>
        [TypeSyntax(Bit)]
        public static TypeSpec bit() => Bit;

        /// <summary>
        /// Defines a string of parametric length
        /// </summary>
        /// <param name="n">The string length</param>
        [TypeSyntax(Sn)]
        public static TypeSpec s(uint n) => string.Format(Sn, n);

        /// <summary>
        /// Defines a string of arbitrary length over a parametric character type
        /// </summary>
        /// <param name="c">The character type</param>
        [TypeSyntax(St)]
        public static TypeSpec s(TypeSpec c) => string.Format(St, c.Format());

        /// <summary>
        /// Defines a string of parametric length over a parametric character type
        /// </summary>
        /// <param name="t">The character type</param>
        [TypeSyntax(Snt)]
        public static TypeSpec s(uint n, TypeSpec t) => string.Format(Snt, t.Format());

        /// <summary>
        /// Defines a character block specification
        /// </summary>
        /// <param name="n">The number of characters in the block</param>
        /// <param name="t">The character type</param>
        [TypeSyntax(Block)]
        public static TypeSpec block(uint n, TypeSpec t) => string.Format(Block, n, t.Format());

        /// <summary>
        /// Defines a sequence of bits of length bounded by a parametric type
        /// </summary>
        /// <param name="t">The type</param>
        [TypeSyntax(Bits)]
        public static TypeSpec bits(TypeSpec t) => string.Format(Bits, t.Format());

        /// <summary>
        /// Defines a sequence of bits of length bounded by both parametric type and length
        /// </summary>
        /// <param name="t">The type</param>
        /// <param name="t">The length</param>
        [TypeSyntax(BitsN)]
        public static TypeSpec bits(uint n, TypeSpec t) => string.Format(BitsN, t.Format());

        /// <summary>
        /// Defines a bitvector type of content width n
        /// </summary>
        /// <param name="n">The bitvector width</param>
        [TypeSyntax(Bv)]
        public static TypeSpec bv(uint n) => string.Format(Bv, n);

        /// <summary>
        /// Defines an n-component vector over a specified cell type
        /// </summary>
        /// <param name="cells">The cell type</param>
        /// <param name="n">The number of vector components</param>
        [TypeSyntax(V)]
        public static TypeSpec v(uint n, TypeSpec cells) => string.Format(V, n, cells.Format());

        public static TypeSpec infer(Type src)
        {
            var spec = new TypeSpec(src.DisplayName());
            if(src.IsConreteClrPrimitive())
                spec = string.Format(Clr, src.ClrPrimitiveKind().ToString().ToLower());
            else if(src.IsEnum)
            {
                var kind = (ClrPrimitiveKind)src.EnumScalarKind();
                var width = (uint)kind.BitWidth();
                var @base = kind.IsSigned() ? i(width) : u(width);
                spec = @enum(src.Name, @base);
            }
            else if(src.IsArray)
            {
                spec = array(infer(src.GetElementType()));
            }
            else if(src.IsSpan())
            {
                if(src.IsOpenGeneric())
                {
                    var parameters = src.GenericParameters();
                    if(parameters.Length == 1)
                        spec = span(infer(core.first(parameters)));
                }
                else
                {
                    var args = src.GetGenericArguments();
                    if(args.Length == 1)
                        spec = span(infer(core.first(args)));
                }

            }
            else if(src.IsReadOnlySpan())
            {
                if(src.IsOpenGeneric())
                {
                    var parameters = src.GenericParameters();
                    if(parameters.Length == 1)
                        spec = cspan(infer(core.first(parameters)));
                }
                else
                {
                    var args = src.GetGenericArguments();
                    if(args.Length == 1)
                        spec = cspan(infer(core.first(args)));
                }
            }
            else
            {
                var tag = src.Tag<DataTypeAttribute>();
                if(tag)
                    spec = tag.Require().NameSyntax;
            }

            return spec;
        }

        public static TypeSpec infer<T>()
            => infer(typeof(T));
    }
}