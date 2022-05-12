//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines a symbolized literal
    /// </summary>
    [Record(TableId), StructLayout(StructLayout)]
    public struct SymLiteralRow : IRecord<SymLiteralRow>
    {
        public const string TableId = "symbolic.literals";

        public const byte FieldCount = 12;

        /// <summary>
        /// The component that defines the literal
        /// </summary>
        [Render(24)]
        public Name Component;

        /// <summary>
        /// The literal's declaring type
        /// </summary>
        [Render(32)]
        public Identifier Type;

        /// <summary>
        /// A literal classifier
        /// </summary>
        [Render(16)]
        public SymClass Class;

        /// <summary>
        /// The container-relative declaration order of the literal
        /// </summary>
        [Render(10)]
        public ushort Position;

        /// <summary>
        /// The literal name
        /// </summary>
        [Render(32)]
        public Identifier Name;

        /// <summary>
        /// The symbol, if so attributed, otherwise, the identifier
        /// </summary>
        [Render(32)]
        public SymExpr Symbol;

        /// <summary>
        /// The literal's primitive classifier
        /// </summary>
        [Render(12)]
        public ClrPrimitiveKind DataType;

        /// <summary>
        /// The encoded literal, possibly an invariant address to a string resource
        /// </summary>
        [Render(22)]
        public SymVal Value;

        /// <summary>
        /// The numeric base interpretation given to the literal
        /// </summary>
        [Render(12)]
        public NumericBaseKind NumericBase;

        /// <summary>
        /// Indicates whether the literal is occluded
        /// </summary>
        [Render(10)]
        public bool Hidden;

        /// <summary>
        /// The meaning of the literal, if available; otherwise empty
        /// </summary>
        [Render(48)]
        public TextBlock Description;

        /// <summary>
        /// A unique identifier
        /// </summary>
        [Render(1)]
        public SymIdentity Identity;

        public static ReadOnlySpan<byte> RenderWidths
            => new byte[FieldCount]{24, 32, 16, 10, 32, 16, 12, 22, 12, 10, 48, 80};
    }
}