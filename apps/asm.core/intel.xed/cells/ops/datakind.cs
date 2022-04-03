//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using DK = XedRules.CellDataKind;
    using CK = XedRules.RuleCellKind;

    partial class XedRules
    {
        public static CellDataKind datakind(RuleCellKind src)
        {
            var nt = src.Test(CK.Nonterminal);
            var bfseg = src.Test(CK.BfSeg);
            var eq = src.Test(CK.Eq);
            var neq = src.Test(CK.Neq);
            var expr = eq || neq;
            if(expr && nt)
                return DK.NontermExpr;
            else if(expr && bfseg)
                return DK.BfSegExpr;
            else if(eq)
                return DK.FieldEq;
            else if(neq)
                return DK.FieldNeq;
            else if(bfseg)
                return DK.BfSeg;
            else if(src.Test(CK.Bits) || src.Test(CK.Hex) || src.Test(CK.Int))
                return DK.Number;
            else if(nt)
                return DK.Nonterminal;
            else if(src.Test(CK.BfSpec))
                return DK.BfSpec;

            switch(src)
            {
                case CK.Branch:
                    return DK.Branch;
                case CK.Null:
                    return DK.Null;
                case CK.Error:
                    return DK.Error;
                case CK.FieldLiteral:
                    return DK.FieldLiteral;
            }

            return DK.Unknown;
        }
    }
}