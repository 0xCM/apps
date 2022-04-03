//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using DK = XedRules.CellDataKind;

    partial class XedRules
    {
        public static string format(RuleCellKind src)
        {
            var dst = EmptyString;
            dst = XedRender.format(datakind(src));
            return dst;
        }

        public static string format(in RuleCriterion src)
        {
            var result = EmptyString;
            switch(src.DataKind)
            {
                case DK.BfSegExpr:
                case DK.NontermExpr:
                case DK.FieldEq:
                case DK.FieldNeq:
                    result = src.ToFieldExpr().Format();
                break;
                case DK.BfSeg:
                    result = src.ToBfSeg().Format();
                break;
                case DK.BfSpec:
                    result = src.ToBfSpec().Format();
                break;
                case DK.Branch:
                case DK.Null:
                case DK.FieldLiteral:
                case DK.Error:
                    result = src.ToFieldLiteral().Format();
                break;
                case DK.Nonterminal:
                    result = src.ToNonTerminal().Format();
                break;
                default:
                    Errors.Throw($"{src.Field} | {src.Operator} | {src.DataKind}");
                break;

            }
            return result;
        }
    }
}