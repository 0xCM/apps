//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    /// <summary>
    /// Defines a symbolized literal
    /// </summary>
    [Record(TableId), StructLayout(StructLayout)]
    public struct SymLiteralRow : IRecord<SymLiteralRow>
    {
        const string TableId = "symbolic.literals";

        public const byte FieldCount = 12;

        [Parser]
        public static Outcome parse(string src, out SymLiteralRow dst)
        {
            var outcome = Outcome.Success;
            var j=0;
            var cells = text.split(src,Chars.Pipe);
            if(cells.Length != SymLiteralRow.FieldCount)
            {
                dst = default;
                return (false, AppMsg.FieldCountMismatch.Format(SymLiteralRow.FieldCount, cells.Length));
            }

            DataParser.parse(skip(cells,j++), out dst.Component);
            DataParser.parse(skip(cells,j++), out dst.Type);
            DataParser.parse(skip(cells,j++), out dst.Class);
            DataParser.parse(skip(cells,j++), out dst.Position);
            DataParser.parse(skip(cells,j++), out dst.Name);
            DataParser.parse(skip(cells,j++), out dst.Symbol);
            DataParser.eparse(skip(cells,j++), out dst.DataType);
            DataParser.parse(skip(cells,j++), out dst.Value);
            DataParser.eparse(skip(cells,j++), out dst.NumericBase);
            DataParser.parse(skip(cells,j++), out dst.Hidden);
            DataParser.parse(skip(cells,j++), out dst.Description);
            DataParser.parse(skip(cells,j++), out dst.Identity);
            return outcome;
        }

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
        [Render(64)]
        public Identifier Name;

        /// <summary>
        /// The symbol, if so attributed, otherwise, the identifier
        /// </summary>
        [Render(64)]
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

    }
}