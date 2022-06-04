//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedTypes
    {
        [DataWidth(num5.Width)]
        public enum TypeKind : byte
        {
            None,

            Primitive,

            Numeric,

            Literal,

            Cell,

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