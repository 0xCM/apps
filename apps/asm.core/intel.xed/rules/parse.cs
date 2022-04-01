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

            if(IsNontermCall(spec))
            {
                result = nonterm(premise, spec, out dst);
            }
            else if(IsBfSeg(input))
            {
                if(XedParsers.parse(input, out BitfieldSeg x))
                {
                    dst = criterion(premise, x);
                    result = true;
                }
            }
            else if(IsBfSpec(input))
            {
                if(XedParsers.parse(input, out BitfieldSpec x))
                {
                    dst = criterion(premise, x);
                    result = true;
                }
            }
            else if(IsFieldExpr(input))
            {
                result = XedParsers.parse(input, out FieldExpr x);
                if(result)
                    dst = criterion(premise, x);
            }
            else
            {
                result = XedParsers.parse(input, out FieldLiteral x);
                if(result)
                    dst = x.ToCriterion(premise);
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

        static bool nonterm(bool premise, string src, out RuleCriterion dst)
        {
            dst = RuleCriterion.Empty;
            var fk = FieldKind.INVALID;
            var nt = Nonterminal.Empty;
            var op = ruleop(src);
            var fv = EmptyString;
            var name = EmptyString;
            var result = false;
            var i = text.index(src,"()");
            if(XedParsers.IsNontermCall(src) && op != 0)
            {
                var input = text.left(src,i);
                var j = text.index(input, Chars.Eq);
                var k = text.index(input, Chars.Bang);
                if(j > 0)
                {
                    name = text.left(input, j);
                    fv = text.right(input, j);
                }
                else if(k > 0)
                {
                    name = text.left(input, k);
                    fv = text.right(input, k+1);
                }

                result = XedParsers.parse(name, out fk);
                Require.invariant(result);

                result = XedParsers.parse(fv, out nt);
                if(!result)
                    Errors.Throw(AppMsg.ParseFailure.Format(nameof(Nonterminal), fv));

                dst = criterion(premise, fk, op, nt);
            }
            else
            {
                name = text.left(src,i);
                result = XedParsers.parse(name, out nt);
                dst = criterion(premise, fk, op, nt);
            }

            return result;
        }
    }
}