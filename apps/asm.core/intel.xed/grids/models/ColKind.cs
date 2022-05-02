//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using TK = XedDataTypes.TypeKind;

    partial class XedGrids
    {
        public enum ColKind : byte
        {
            None = 0,

            Keyword = TK.Keyword,

            Field = TK.Field,

            Rule = TK.Rule,

            Operator = TK.Operator,

            Expression = TK.Expression,
        }
    }
}