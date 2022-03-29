//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static Root;
    using static XedModels;
    using static XedParsers;

    using K = XedRules.FieldKind;
    using RO = XedRules.RuleOperator;
    using R = XedRules;

    partial class XedRules
    {
        public static bool parse(string src, out StatementSpec dst)
        {
            var input = normalize(src);
            var i = text.index(input,"=>");
            dst = StatementSpec.Empty;
            if(i > 0)
            {
                var left = text.trim(text.left(input, i));
                var premise = text.nonempty(left) ? cells(true, left) : Index<RuleCell>.Empty;
                var right = text.trim(text.right(input, i+1));
                var consequent = text.nonempty(right) ? cells(false, right) : Index<RuleCell>.Empty;
                if(premise.Count != 0 || consequent.Count != 0)
                    dst = new StatementSpec(premise,consequent);
            }
            else
                Errors.Throw(AppMsg.ParseFailure.Format(nameof(StatementSpec), src));

            return dst.IsNonEmpty;
        }

        static bool constraint(string input, out RuleCriterion dst)
        {
            dst = RuleCriterion.Empty;
            var constraint = FieldConstraint.Empty;
            var result = XedParsers.parse(input, out constraint);
            if(result)
                dst = criterion(true, constraint);
            return result;
        }

        static bool assign(bool premise, string input, out FieldKind fk, out string fv)
        {
            fk = 0;
            fv = EmptyString;
            var result = XedParsers.IsAssignment(input);
            if(result)
            {
                var i = text.index(input, "=");
                fv = text.right(input, i);
                result = XedParsers.parse(text.left(input, i), out fk);
            }
            return result;
        }

        static bool parse(bool premise, string spec, out RuleCriterion dst)
        {
            var input = normalize(spec);
            var fk = K.INVALID;
            var op = RO.None;
            var fv = input;
            var i = -1;
            dst = RuleCriterion.Empty;
            var result = false;

            if(parse(premise, spec, out fk, out op, out Nonterminal nt))
            {
                dst = criterion(premise, fk, op, nt);
                result = true;
            }
            else if(IsNonterminal(input))
            {
                var name = text.remove(input,"()");
                parse(premise, name, out fk, out fv, out op);
                dst = criterion(premise, call(fk, op, text.ifempty(fv,name)));
                result = true;
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
            else if(premise && IsConstraint(input))
            {
                result = constraint(input, out dst);
            }
            else if(IsAssignment(input))
            {
                if(assign(premise, input, out fk, out fv))
                    result = parse(premise, fk, RO.Assign, fv, out dst);
            }
            else
            {
                result = XedParsers.parse(input, out FieldLiteral literal);
                if(result)
                    dst = literal.ToCriterion(premise);
            }
            return result;
        }

        static bool parse(bool premise, string input, out FieldKind fk, out RuleOperator op, out Nonterminal nt)
        {
            fk = 0;
            nt = Nonterminal.Empty;
            op = RuleOperator.None;
            var result = false;
            var i = text.index(input,"()");
            if(i > 0)
            {
                if(assign(premise, text.left(input,i), out fk, out var fv))
                {
                    if(XedParsers.parse(fv, out nt))
                    {
                        result = true;
                        op = RuleOperator.Assign;
                    }
                }
            }
            return result;
        }

        static string normalize(string src)
        {
            var dst = EmptyString;
            var i = text.index(src, Chars.Hash);
            if(i>0)
                dst = text.despace(text.trim(text.left(src, i)));
            else
                dst = text.despace(text.trim(src));
            if(dst == "otherwise")
                return "else";
            else if(dst == "nothing")
                return "null";
            else
                return dst.Replace("->", "=>").Replace("|", "=>").Remove("XED_RESET");
        }

        static bool parse(bool premise, string input, out FieldKind fk, out string fv, out RuleOperator op)
        {
            var i = text.index(input, "!=");
            fv = EmptyString;
            op = 0;
            fk = 0;
            if(i > 0)
            {
                op = RO.CmpNeq;
                fv = text.right(input, i + 1);
            }
            else
            {
                i = text.index(input, "=");
                if(i > 0)
                {
                    if(premise)
                        op = RO.CmpEq;
                    else
                        op = RO.Assign;

                    fv = text.right(input, i);
                }
            }

            return XedParsers.parse(text.left(input, i), out fk);
        }

        [Op]
        static bool parse(bool premise, FieldKind field, RuleOperator op, string value, out RuleCriterion dst)
        {
            var result = XedFields.parse(field, value, out R.FieldValue z);
            dst = criterion(premise, op, z);
            return result;
        }
    }
}