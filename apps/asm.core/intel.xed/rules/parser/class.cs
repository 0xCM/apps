//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using CK = XedRules.RuleCellKind;

    partial class XedRules
    {
        partial struct CellParser
        {
            static CellClass @class(FieldKind field, string data)
            {
                var result = false;
                var input = CellParser.normalize(data);
                var dst = CellClass.Empty;
                var isNonTerm = text.contains(input, "()");

                if(IsExpr(input))
                {
                    result = CellParser.ruleop(input, out RuleOperator op);
                    if(!result)
                        Errors.Throw(AppMsg.ParseFailure.Format(nameof(RuleOperator), input));

                    switch(op.Kind)
                    {
                        case OperatorKind.Eq:
                            if(isNonTerm)
                                dst = CK.NontermExpr;
                            else
                                dst = CK.EqExpr;
                        break;
                        case OperatorKind.Neq:
                            dst = CK.NeqExpr;
                        break;
                        case OperatorKind.And:
                        case OperatorKind.Impl:
                            dst = CK.Operator;
                        break;
                    }
                }
                else
                {
                    if(isNonTerm)
                        dst = CK.NontermCall;
                    else if(XedParsers.IsIntLiteral(data))
                        dst = CK.IntLiteral;
                    else if(XedParsers.IsHexLiteral(data))
                        dst = CK.HexLiteral;
                    else if(XedParsers.IsBinaryLiteral(data))
                        dst = CK.BitLiteral;
                    else if(IsImpl(input))
                        dst = CK.Operator;
                    else if(IsSeg(input))
                    {
                        if(field != 0)
                            dst = CK.InstSeg;
                        else
                            Errors.Throw(AppMsg.ParseFailure.Format(nameof(CellClass), input));
                    }
                    else if(XedParsers.parse(input, out RuleKeyword keyword))
                        dst = CK.Keyword;
                    else
                        dst = CK.SegVar;
                }

                Require.invariant(dst.IsNonEmpty);
                return dst;
            }
        }
    }
}