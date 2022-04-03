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
        public static Outcome split(RuleCell src, out RuleCellKind kind, out string value)
        {
            var data = src.Data;
            value = data;
            kind = CK.None;
            var left = EmptyString;
            if(src.IsExpr)
            {
                if(src.Operator == RuleOperator.Eq)
                {
                    kind = CK.Eq;
                    eq(data, out left, out value);
                }
                else if(src.Operator == RuleOperator.Neq)
                {
                    kind = CK.Neq;
                    neq(data, out left, out value);
                }
                else
                    Errors.Throw($"{data} is not an expression");

                return true;
            }

            if(XedParsers.IsBinaryLiteral(value))
                kind |= CK.Bits;
            else if(XedParsers.IsHexLiteral(value))
                kind |= CK.Hex;
            else if(XedParsers.IsIntLiteral(value))
                kind |= CK.Int;

            if(kind != 0)
                return true;

            if(XedParsers.IsBfSeg(data))
            {
                if(XedParsers.parse(data, out BfSeg bfs))
                {
                    value = bfs.Pattern;
                    kind |= CK.BfSeg;
                    return true;
                }
            }

            if(FieldLiteral.test(data))
            {
                if(parse(data, out FieldLiteral fl))
                {
                    if(fl == FieldLiteral.Branch)
                        kind = CK.Branch;
                    else if(fl == FieldLiteral.Null)
                        kind = CK.Null;
                    else if(fl == FieldLiteral.Error)
                        kind = CK.Error;
                    else
                        kind = CK.FieldLiteral;

                    return true;
                }
            }

            if(XedParsers.IsBfSpec(data))
                kind |= CK.BfSpec;
            else if(XedParsers.IsNontermCall(value))
                kind |= CK.Nonterminal;

            if(kind == 0)
                kind = CK.FieldLiteral;

            return true;
        }

        static bool eq(string src, out string left, out string right)
        {
            var result = false;
            if(XedParsers.IsEq(src))
            {
                var i = text.index(src, Chars.Eq);
                left = text.left(src,i);
                right = text.right(src,i);
                result = true;
            }
            else
            {
                left = EmptyString;
                right = EmptyString;
            }
            return result;
        }

        static bool neq(string src, out string left, out string right)
        {
            var result = false;
            if(XedParsers.IsNeq(src))
            {
                var i = text.index(src, Chars.Bang);
                left = text.left(src,i);
                right = text.right(src,i+1);
                result = true;
            }
            else
            {
                left = EmptyString;
                right = EmptyString;
            }
            return result;
        }
    }
}