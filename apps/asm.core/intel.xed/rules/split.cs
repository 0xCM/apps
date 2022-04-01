//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public static Outcome split(RuleCell src, out RuleCellKind kind, out string value)
        {
            var result = Outcome.Success;
            var data = src.Data;
            value = data;
            kind = RuleCellKind.None;
            var left = EmptyString;
            if(src.Premise)
            {
                if(XedParsers.IsCmpNeq(data))
                {
                    kind = RuleCellKind.CmpNeq;
                    XedParsers.CmpNeq(data, out left, out value);
                }
                else if (text.contains(data, Chars.Eq))
                {
                    kind = RuleCellKind.CmpEq;
                    XedParsers.Assignment(data, out left, out value);
                }
            }
            else
            {
                if(XedParsers.IsAssignment(data))
                {
                    kind = RuleCellKind.Assignment;
                    XedParsers.Assignment(data, out left, out value);
                }
                else if(XedParsers.IsCmpNeq(data))
                {
                    kind = RuleCellKind.CmpNeq;
                    XedParsers.CmpNeq(data, out left, out value);
                }
            }

            if(XedParsers.parse(data, out FieldLiteral lit))
                kind |= RuleCellKind.FieldLiteral;
            if(XedParsers.IsBfSeg(data))
                kind |= RuleCellKind.BfSeg;
            else if(XedParsers.IsBfSpec(data))
                kind |= RuleCellKind.BfSpec;
            if(XedParsers.IsNontermCall(value))
                kind |= RuleCellKind.Nonterminal;
            if(XedParsers.IsBinaryLiteral(value))
                kind |= RuleCellKind.Bits;
            else if(XedParsers.IsHexLiteral(value))
                kind |= RuleCellKind.Hex;
            else if(XedParsers.IsIntLiteral(value))
                kind |= RuleCellKind.Int;
            return result;
        }
    }
}