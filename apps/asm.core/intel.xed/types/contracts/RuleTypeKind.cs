//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedDataTypes
    {
        [DataWidth(4,8)]
        public enum RuleTypeKind : byte
        {
            None,

            Primitive,

            Numeric,

            Literal,

            Cell,

            TypedLiteral,

            Field,

            Operator,

            Expression,

            SegField,

            SegVal,
        }
    }
}