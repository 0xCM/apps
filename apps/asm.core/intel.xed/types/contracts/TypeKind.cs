//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedDataTypes
    {
        [DataWidth(num5.Width)]
        public enum TypeKind : byte
        {
            None,

            Primitive,

            Numeric,

            Literal,

            Cell,

            /// <summary>
            /// Classifies a named literal
            /// </summary>
            TypedLiteral,

            Operator,

            Field,

            FieldSeg,

            SegVal,

            SegVar,

            Rule,

            BitLiteral,

         Expression,

           IntLiteral,

            HexLiteral,

            Keyword
        }
    }
}