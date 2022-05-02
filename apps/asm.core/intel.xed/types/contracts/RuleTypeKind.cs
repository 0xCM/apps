//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedDataTypes
    {
        [DataWidth(4,8)]
        public enum TypeKind : byte
        {
            None,

            Primitive,

            Numeric,

            Literal,

            Cell,

            /// <summary>
            /// Characterizes a named literal
            /// </summary>
            TypedLiteral,

            Field,

            Operator,

            Expression,

            SegField,

            SegVal,

            Rule,

            BitLiteral,

            IntLiteral,

            HexLiteral,

            Keyword
        }
    }
}