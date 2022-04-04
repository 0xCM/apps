//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedParsers;
    using static XedFields;
    using static XedModels;
    using static XedPatterns;

    partial class XedRules
    {
        public readonly struct RuleParser
        {
            public static string normalize(string src)
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

            public static Outcome parse(string src, out InstPatternBody dst)
            {
                var result = Outcome.Success;
                var parts = text.trim(text.split(text.despace(src), Chars.Space));
                var count = parts.Length;
                dst = alloc<InstDefField>(count);
                for(var i=0; i<count; i++)
                {
                    result = XedRules.RuleParser.parse(skip(parts,i), out dst[i]);
                    if(result.Fail)
                        break;
                }
                return result;
            }

            public static Outcome parse(string src, out InstDefField dst)
            {
                dst = InstDefField.Empty;
                Outcome result = (false, string.Format("Unrecognized segment '{0}'", src));
                if(IsHexLiteral(src))
                {
                    result = XedParsers.parse(src, out Hex8 x);
                    if(result)
                        dst = part(x);
                    else
                        result = (false, AppMsg.ParseFailure.Format(nameof(Hex8), src));
                }
                else if(IsBinaryLiteral(src))
                {
                    result = XedParsers.parse(src, out uint5 x);
                    if(result)
                        dst = part(x);
                    else
                        result = (false, AppMsg.ParseFailure.Format(nameof(uint5), src));

                }
                else if(IsBfSeg(src))
                {
                    result = XedParsers.parse(src, out BfSeg x);
                    if(result)
                        dst = part(x);
                    else
                        result = (false, AppMsg.ParseFailure.Format(nameof(BfSeg), src));
                }
                else if (IsFieldExpr(src))
                {
                    result = XedParsers.parse(src, out FieldExpr x);
                    if(result)
                        dst = part(x);
                    else
                        result = (false, AppMsg.ParseFailure.Format(nameof(FieldExpr), src));
                }
                else if(IsNontermCall(src))
                {
                    result = XedParsers.parse(src, out Nonterminal x);
                    if(result)
                        dst = part(x);
                    else
                        result = (false, AppMsg.ParseFailure.Format(nameof(Nonterminal), src));
                }
                else if (XedParsers.parse(src, out byte a))
                {
                    result = true;
                    dst = new(a);
                }

                return result;
            }

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

            public static bool parse(string spec, out RuleCriterion dst)
            {
                var input = normalize(spec);
                var fk = FieldKind.INVALID;
                var op = OperatorKind.None;
                var fv = input;
                var i = -1;
                dst = RuleCriterion.Empty;
                var result = false;

                if(IsNontermCall(spec))
                {
                    result = nonterm(spec, out dst);
                }
                else if(IsBfSeg(input))
                {
                    if(XedParsers.parse(input, out BfSeg x))
                    {
                        dst = XedRules.criterion(x);
                        result = true;
                    }
                }
                else if(IsBfSpec(input))
                {
                    if(XedParsers.parse(input, out BfSpec x))
                    {
                        dst = XedRules.criterion(x);
                        result = true;
                    }
                }
                else if(IsFieldExpr(input))
                {
                    result = XedParsers.parse(input, out FieldExpr x);
                    if(result)
                        dst = XedRules.criterion(x);
                }
                else
                {
                    result = FieldLiteral.parse(input, out FieldLiteral x);
                    if(result)
                        dst = x.ToCriterion();
                }
                return result;
            }

            static bool nonterm(string src, out RuleCriterion dst)
            {
                dst = RuleCriterion.Empty;
                var fk = FieldKind.INVALID;
                var nt = Nonterminal.Empty;
                XedParsers.parse(src, out OperatorKind op);
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

                    dst = XedRules.criterion(fk, op, nt);
                }
                else
                {
                    name = text.left(src,i);
                    result = XedParsers.parse(name, out nt);
                    dst = XedRules.criterion(fk, op, nt);
                }

                return result;
            }
        }
    }
}