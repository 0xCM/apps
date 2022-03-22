//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class XedRules
    {
        public Index<RuleTableSpec> CalcRuleSpecs(RuleTableKind kind)
            => RuleTables.CalcRuleSpecs(kind);

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
                else
                    kind = RuleCellKind.Literal;
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
                else
                    kind = RuleCellKind.Literal;
            }

            if(XedParsers.IsBfSeg(data))
                kind |= RuleCellKind.BfSeg;
            if(XedParsers.IsNonterminal(value))
                kind |= RuleCellKind.Nonterminal;

            if(XedParsers.IsBinaryLiteral(value))
                kind |= RuleCellKind.Bits;
            else if(XedParsers.IsHexLiteral(value))
                kind |= RuleCellKind.Hex;
            else if(XedParsers.IsIntLiteral(value))
                kind |= RuleCellKind.Int;

            if(src.Field != 0)
                kind |= RuleCellKind.FieldValue;

            return result;
        }
    }
}