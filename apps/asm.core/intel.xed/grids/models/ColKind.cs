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

            FieldSeg = TK.FieldSeg,

            Rule = TK.Rule,

            Operator = TK.Operator,

            BitLiteral = TK.BitLiteral,

            HexLiteral = TK.HexLiteral,

            Expr = TK.Expression,

            SegVal = TK.SegVal,

            SegVar = TK.SegVar,

            RuleExpr
        }
    }
}