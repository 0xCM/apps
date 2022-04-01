//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public static CellDataKind datakind(RuleCellKind src)
        {
            var isexpr = src.Test(RuleCellKind.Assignment) || src.Test(RuleCellKind.CmpNeq) || src.Test(RuleCellKind.CmpEq);
            var nt = src.Test(RuleCellKind.Nonterminal);
            var bfseg = src.Test(RuleCellKind.BfSeg);
            var number = src.Test(RuleCellKind.Bits) || src.Test(RuleCellKind.Hex)  || src.Test(RuleCellKind.Int);
            var bfspec = src.Test(RuleCellKind.BfSpec);
            var literal = src.Test(RuleCellKind.FieldLiteral);
            if(isexpr && nt)
                return CellDataKind.NontermExpr;
            else if(isexpr && bfseg)
                return CellDataKind.BfSegExpr;
            else if(isexpr)
                return CellDataKind.FieldExpr;
            else if(bfseg)
                return CellDataKind.BfSeg;
            else if(number)
                return CellDataKind.NumericLiteral;
            else if(nt)
                return CellDataKind.Nonterminal;
            else if(bfspec)
                return CellDataKind.BfSpec;
            else if(literal)
                return CellDataKind.FieldLiteral;
            else
                return CellDataKind.Unknown;
        }
    }
}