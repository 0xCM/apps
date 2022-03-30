//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedModels;
    using static XedParsers;
    using static XedFields;

    partial class XedRules
    {
        static bool parse(bool premise, string spec, out RuleCriterion dst)
        {
            var input = normalize(spec);
            var fk = FieldKind.INVALID;
            var op = RuleOperator.None;
            var fv = input;
            var i = -1;
            dst = RuleCriterion.Empty;
            var result = false;

            if(IsNonterminal(spec))
            {
                result = nonterm(premise, spec, out dst);
            }
            else if(IsBfSeg(input))
            {
                if(XedParsers.parse(input, out BitfieldSeg seg))
                {
                    dst = criterion(premise, seg);
                    result = true;
                }
            }
            else if(IsBfSpec(input))
            {
                dst = criterion(premise, new BitfieldSpec(input));
                result = true;
            }
            else if(IsFieldExpr(input))
            {
                result = XedParsers.parse(input, out FieldExpr expr);
                if(result)
                    dst = criterion(premise, expr);
            }
            else
            {
                result = XedParsers.parse(input, out FieldLiteral literal);
                if(result)
                    dst = literal.ToCriterion(premise);
            }
            return result;
        }

        static RuleOperator ruleop(string src)
        {
            if(text.contains(src, "!="))
                return RuleOperator.CmpNeq;
            else if(text.contains(src,"=="))
                return RuleOperator.CmpEq;
            else if(text.contains(src,"="))
                return RuleOperator.Assign;
            else
                return 0;
        }

        static bool nonterm(bool premise, string input, out RuleCriterion dst)
        {
            dst = RuleCriterion.Empty;
            var fk = FieldKind.INVALID;
            var nt = Nonterminal.Empty;
            var op = RuleOperator.None;
            var fv = EmptyString;
            var name = EmptyString;
            var result = false;
            if(XedParsers.IsNonterminal(input))
            {
                var i = text.index(input,"()");
                name = text.left(input,i);
                op = ruleop(input);
                if(op != 0)
                {
                    var j = text.index(input, Chars.Eq);
                    var k = text.index(input, Chars.Bang);
                    if(j >0)
                    {
                        name = text.left(input, j);
                        fv = text.right(input, j);
                        result = XedParsers.parse(name, out fk);
                    }
                    else if(k > 0)
                    {
                        name = text.left(input, k);
                        fv = text.right(input, k+1);
                        result = XedParsers.parse(name, out fk);
                    }

                    Require.invariant(result);
                    nt = new(fv);
                    dst = criterion(premise, fk, op, nt);

                }
                else
                {
                    nt = new(name);
                    dst = criterion(premise, fk, op, nt);
                    result = true;
                }
            }

            return result;
        }
    }
}