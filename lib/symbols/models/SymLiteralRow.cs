//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Defines a symbolized literal
    /// </summary>
    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct SymLiteralRow : IRecord<SymLiteralRow>
    {
        public const string TableId = "symbolic.literals";

        public const byte FieldCount = 11;

        /// <summary>
        /// The component that defines the literal
        /// </summary>
        public Name Component;

        /// <summary>
        /// The literal's declaring type
        /// </summary>
        public Identifier Type;

        /// <summary>
        /// A literal classifier
        /// </summary>
        public SymClass Class;

        /// <summary>
        /// The container-relative declaration order of the literal
        /// </summary>
        public ushort Position;

        /// <summary>
        /// The literal name
        /// </summary>
        public Identifier Name;

        /// <summary>
        /// The symbol, if so attributed, otherwise, the identifier
        /// </summary>
        public SymExpr Symbol;

        /// <summary>
        /// The literal's primitive classifier
        /// </summary>
        public PrimalKind DataType;

        /// <summary>
        /// The encoded literal, possibly an invariant address to a string resource
        /// </summary>
        public ulong ScalarValue;

        /// <summary>
        /// Indicates whether the literal is occluded
        /// </summary>
        public bool Hidden;

        /// <summary>
        /// The meaning of the literal, if available; otherwise empty
        /// </summary>
        public TextBlock Description;

        /// <summary>
        /// A unique identifier
        /// </summary>
        public SymIdentity Identity;

        public static ReadOnlySpan<byte> RenderWidths
            => new byte[FieldCount]{24, 32, 16, 10, 32, 16, 12, 22, 10, 48, 80};
    }
}