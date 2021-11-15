//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Types
{
    using N = DataKindNames;

    public readonly struct DataType
    {
        public DataKind Kind {get;}

        public uint Width {get;}

        public DataType(DataKind kind, uint width)
        {
            Kind = kind;
            Width = width;
        }
    }

    [SymSource]
    public enum DataKind : byte
    {
        /// <summary>
        /// Mystery kind
        /// </summary>
        [Symbol(N.Unknown)]
        Unknown = 0,

        /// <summary>
        /// Indicates a type represents an unsigned integral value
        /// </summary>
        [Symbol(N.Unsigned)]
        UnsignedInt,

        /// <summary>
        /// Indicates a type represents a signed integral value
        /// </summary>
        [Symbol(N.Signed)]
        SignedInt,

        /// <summary>
        /// Indicates a type represents a floating-point value
        /// </summary>
        [Symbol(N.Float)]
        Float,

        /// <summary>
        /// Indicates a type represents a character value
        /// </summary>
        [Symbol(N.Char)]
        Char,

        /// <summary>
        /// Indicates (parametric) unit of data
        /// </summary>
        [Symbol(N.Cell)]
        Cell,

        /// <summary>
        /// Indicates a (parametric) sequence
        /// </summary>
        /// <example>
        /// A sequence {x0,x1,...xN} of N values
        /// </example>
        [Symbol(N.Seq)]
        Seq,

        /// <summary>
        /// Indicates a contiguous cell sequence
        /// </summary>
        [Symbol(N.Block)]
        Block,

        /// <summary>
        /// A finite sequence of characters
        /// </summary>
        [Symbol(N.String)]
        String,

        /// <summary>
        /// Indicates a type over the integral domain that specified list of named values
        /// </summary>
        [Symbol(N.Enum)]
        Enum,

        /// <summary>
        /// Indicates a composite type that uniformly partitions a sequence of bits over a finite number of homogenously-typed values
        /// </summary>
        /// <example>
        /// v8x32u := a packed sequence of 8 u32 values
        /// v13x3i := a packed sequence of 13 i32 values
        /// </example>
        [Symbol(N.Vector)]
        Vector,

        /// <summary>
        /// Indicates a composite type that uniformly partitions a sequence of bits over a finite number of typed values of potentially non-uniform type
        /// </summary>
        [Symbol(N.Array)]
        Array,

        /// <summary>
        /// Indicates a composite type covers a finite sequence of <see cref='Vector'/> values of potentially non-uniform type
        /// </summary>
        /// <example>
        /// t:[v3x32u, v5x1u, v1x8c]
        /// </example>
        [Symbol(N.Tensor)]
        Tensor,

        /// <summary>
        /// Indicates a (parametric) grid
        /// </summary>
        [Symbol(N.Grid)]
        Grid,

        /// <summary>
        /// Indicates a type that represents a sequence of bits
        /// </summary>
        [Symbol(N.BitVector)]
        BitVector,

        /// <summary>
        /// Indicates a type that defines a function
        /// </summary>
        [Symbol(N.Function)]
        Function,

        /// <summary>
        /// Indicates a type that defines an action with potential side-effects
        /// </summary>
        [Symbol(N.Function)]
        Effect,

        /// <summary>
        /// Indicates an N-tuple (a0,...,aN)
        /// </summary>
        [Symbol(N.Tuple)]
        Tuple,

        /// <summary>
        /// A tuple with named fields
        /// </summary>
        Record,

        /// <summary>
        /// Indicates a memory location
        /// </summary>
        Address,

        /// <summary>
        /// Indicates a (parametric) memory location
        /// </summary>
        Pointer,

        [Symbol(N.Tuple)]
        Isomorp
    }

    [LiteralProvider]
    readonly struct DataKindNames
    {
        public const string Unknown = "?";

        public const string Unsigned = "u";

        public const string Signed = "i";

        public const string Float = "f";

        public const string Char = "c";

        public const string String = "string";

        public const string Enum = "enum";

        public const string Vector = "v";

        public const string Array = "array";

        public const string Tensor = "tensor";

        public const string Domain = "domain";

        public const string Seq = "seq";

        public const string Grid = "grid";

        public const string Name = "name";

        public const string BitVector = "bv";

        public const string Tuple = "tuple";

        public const string Function = "fx";

        public const string Effect = "ef";

        public const string Cell = "cell";

        public const string Block = "block";
    }
}