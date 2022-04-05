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
            public static bool IsFieldExpr(string src)
            {
                var result = text.contains(src,"!=") || text.contains(src,"=");
                if(result)
                {
                    var i = text.index(src, "!=");
                    var j = text.index(src, "=");
                    if(i>0)
                    {
                        var right = text.right(src,i+1);
                        result = text.nonempty(right);
                    }
                    else if(j>0)
                    {
                        var right = text.right(src,j);
                        result = text.nonempty(right);
                    }
                    else
                        result = false;
                }
                return result;
            }

            public static RuleCellExpr expr(string src)
            {
                var field = FieldKind.INVALID;
                var right = src;
                var op = RuleOperator.Empty;
                if(IsFieldExpr(src))
                {
                    var left = EmptyString;
                    XedParsers.parse(src, out op);
                    if(op == OperatorKind.Eq)
                        eq(src, out left, out right);
                    else if(op == OperatorKind.Neq)
                        neq(src, out left, out right);
                    else
                        Errors.Throw($"{src} is not an expression");

                    XedParsers.parse(left, out field);
                }

                if(XedParsers.IsBfSeg(src) && XedParsers.parse(src, out BfSeg bfs))
                    right = bfs.Pattern;

                return new (field, op, right);
            }

            public static bool eq(string src, out string left, out string right)
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

            public static bool neq(string src, out string left, out string right)
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

            public static void parse(string src, out InstPatternBody dst)
            {
                var result = Outcome.Success;
                var parts = text.trim(text.split(text.despace(src), Chars.Space));
                var count = parts.Length;
                dst = alloc<InstDefField>(count);
                for(var i=0; i<count; i++)
                {
                    result = parse(skip(parts,i), out dst[i]);
                    if(result.Fail)
                        break;
                }

                if(result.Fail)
                    Errors.Throw(AppMsg.ParseFailure.Format(nameof(InstPatternBody), src));
            }

            public static bool parse(string src, out StatementSpec dst)
            {
                var input = normalize(src);
                var i = text.index(input,"=>");
                dst = StatementSpec.Empty;
                if(i > 0)
                {
                    var left = text.trim(text.left(input, i));
                    var premise = text.nonempty(left) ? cells(true, left) : Index<RuleCellSpec>.Empty;
                    var right = text.trim(text.right(input, i+1));
                    var consequent = text.nonempty(right) ? cells(false, right) : Index<RuleCellSpec>.Empty;
                    if(premise.Count != 0 || consequent.Count != 0)
                        dst = new StatementSpec(premise,consequent);
                }
                else
                    Errors.Throw(AppMsg.ParseFailure.Format(nameof(StatementSpec), src));

                return dst.IsNonEmpty;
            }

            public static bool parse(string data, out RuleCriterion dst)
            {
                var input = normalize(data);
                var fk = FieldKind.INVALID;
                var op = OperatorKind.None;
                var fv = input;
                var i = -1;
                dst = RuleCriterion.Empty;
                var result = false;

                if(IsNontermCall(data))
                {
                    result = nonterm(data, out dst);
                }
                else if(IsBfSeg(input) && XedParsers.parse(input, out BfSeg bfseg))
                {
                    dst = criterion(bfseg);
                    result = true;
                }
                else if(IsBfSpec(input) && XedParsers.parse(input, out BfSpec bfspec))
                {
                    dst = criterion(bfspec);
                    result = true;
                }
                else if(IsFieldExpr(input) && parse(input, out FieldExpr fieldx))
                {
                    dst = criterion(fieldx);
                    result = true;
                }
                else
                {
                    result = RuleKeyword.parse(input, out RuleKeyword lit);
                    if(result)
                        dst = lit.ToCriterion();
                }

                return result;
            }

            static bool parse(string src, out FieldExpr dst)
            {
                dst = FieldExpr.Empty;
                var result = false;
                if(IsFieldExpr(src))
                {
                    var i = text.index(src, "!=");
                    var j = text.index(src, "=");
                    var fvExpr = EmptyString;
                    var fv = FieldValue.Empty;
                    var fk = FieldKind.INVALID;
                    var op = OperatorKind.None;
                    if(i > 0)
                    {
                        fvExpr = text.right(src, i + 1);
                        op = OperatorKind.Neq;
                        result = XedParsers.parse(text.left(src,i), out fk);
                    }
                    else if (j>0)
                    {
                        fvExpr = text.right(src, j);
                        op = OperatorKind.Eq;
                        result = XedParsers.parse(text.left(src,j), out fk);
                    }

                    if(result)
                    {
                        result = FieldParser.parse(fk, fvExpr, out fv);
                        if(result)
                            dst = new FieldExpr(fk, op, fv);
                    }
                    else
                        Errors.Throw(AppMsg.ParseFailure.Format(nameof(FieldExpr), src));
                }

                return result;
            }

            static Outcome parse(string src, out InstDefField dst)
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
                    result = parse(src, out FieldExpr x);
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

                    dst = criterion(fk, op, nt);
                }
                else
                {
                    name = text.left(src,i);
                    result = XedParsers.parse(name, out nt);
                    dst = criterion(fk, op, nt);
                }

                return result;
            }

            static Index<RuleCellSpec> cells(bool premise, string src)
            {
                var input = text.trim(text.despace(src));
                var cells = list<string>();
                if(text.contains(input, Chars.Space))
                {
                    var parts = text.split(input, Chars.Space);
                    var count = parts.Length;
                    for(var j=0; j<count; j++)
                    {
                        ref readonly var part = ref skip(parts,j);
                        if(RuleMacros.match(part, out var match))
                        {
                            var expanded = text.trim(match.Expansion);
                            if(text.contains(expanded, Chars.Space))
                            {
                                var expansions = text.split(expanded, Chars.Space);
                                for(var k=0; k<expansions.Length; k++)
                                {
                                    ref readonly var x = ref skip(expansions,k);
                                    cells.Add(x);
                                }
                            }
                            else
                                cells.Add(expanded);
                        }
                        else
                            cells.Add(part);
                    }
                }
                else
                {
                    if(RuleMacros.match(input, out var match))
                        cells.Add(match.Expansion);
                    else
                        cells.Add(input);
                }

                return cells.Map(x => new RuleCellSpec(premise,x));
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
        }
    }
}