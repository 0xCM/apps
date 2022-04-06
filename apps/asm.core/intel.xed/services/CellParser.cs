//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedParsers;
    using static XedModels;
    using static XedPatterns;

    partial class XedRules
    {
        public readonly struct CellParser
        {
            public static bool IsEq(string src)
                => !src.Contains("!=") && src.Contains("=");

            public static bool IsNeq(string src)
                => src.Contains("!=");

            public static bool IsImpl(string src)
                => src.Contains("=>");

            public static bool IsBfSeg(string src)
            {
                if(!IsDispSeg(src) && !IsImmSeg(src))
                {
                    var i = text.index(src, Chars.LBracket);
                    var j = text.index(src, Chars.RBracket);
                    return i > 0 && j > i;
                }
                else
                    return false;
            }

            public static bool IsBfSpec(string src)
                => XedParsers.parse(src, out BfSpecKind _);

            public static bool IsDispSpec(string src)
                => XedParsers.parse(src, out DispSpec _);

            public static bool IsDispSeg(string src)
            {
                var result = false;
                var i = text.index(src, Chars.LBracket);
                var j = text.index(src, Chars.RBracket);
                if(i >0 && j>0)
                    result = IsDispSpec(text.inside(src,i,j));
                return result;
            }

            public static bool IsImmSpec(string src)
                => XedParsers.parse(src, out ImmSpec _);

            public static bool IsImmSeg(string src)
            {
                var result = false;
                var i = text.index(src, Chars.LBracket);
                var j = text.index(src, Chars.RBracket);
                if(i >0 && j>0)
                    result = IsImmSpec(text.inside(src,i,j));
                return result;
            }

            public static bool IsExpr(string src)
                => IsEq(src) || IsNeq(src);


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

            public static bool parse(string src, out OperatorKind dst)
            {
                if(IsNeq(src))
                {
                    dst = OperatorKind.Neq;
                    return true;
                }
                else if(IsEq(src))
                {
                    dst = OperatorKind.Eq;
                    return true;
                }
                else if(IsImpl(src))
                {
                    dst = OperatorKind.Impl;
                    return true;
                }
                else
                {
                    dst = 0;
                    return false;
                }
            }

            public static bool parse(string src, out RuleOperator dst)
            {
                if(parse(src, out OperatorKind k))
                {
                    dst = k;
                    return true;
                }
                else
                {
                    dst = default;
                    return false;
                }
            }

            public static bool parse(string src, out CellRowSpec dst)
            {
                var input = normalize(src);
                var i = text.index(input,"=>");
                dst = CellRowSpec.Empty;
                if(i > 0)
                {
                    var left = text.trim(text.left(input, i));
                    var premise = text.nonempty(left) ? cells(true, left) : Index<CellSpec>.Empty;
                    var right = text.trim(text.right(input, i+1));
                    var consequent = text.nonempty(right) ? cells(false, right) : Index<CellSpec>.Empty;
                    if(premise.Count != 0 || consequent.Count != 0)
                        dst = new CellRowSpec(premise,consequent);
                }
                else
                    Errors.Throw(AppMsg.ParseFailure.Format(nameof(CellRowSpec), src));

                return dst.IsNonEmpty;
            }

            public static bool parse(string src, out BfSeg dst)
            {
                var name = EmptyString;
                var content = EmptyString;
                dst = default;
                var i = text.index(src, Chars.LBracket);
                var j = text.index(src, Chars.RBracket);
                var result = false;
                if(i > 0 && j > i)
                {
                    name = text.left(src,i);
                    content = text.inside(src,i,j);
                    if(XedParsers.parse(name, out FieldKind kind))
                    {
                        dst = new BfSeg(kind, text.remove(content,"0b"), text.begins(content,"0b"));
                        result = true;
                    }
                }
                return result;
            }

            static bool Value(string data, out RuleCriterion dst)
            {
                var result = false;
                var input = normalize(data);
                var fk = FieldKind.INVALID;
                var op = OperatorKind.None;
                var fv = input;
                dst = RuleCriterion.Empty;
                if(spec(input, out var expr))
                {
                    dst = criterion(expr);
                    result = true;
                }
                else if(XedParsers.parse(input, out DispSeg disp))
                {
                    dst = criterion(disp);
                    result = true;
                }
                else if(XedParsers.parse(input, out ImmSeg imm))
                {
                    dst = criterion(imm);
                    result = true;
                }
                else if(IsBfSeg(input))
                {
                    if(parse(input, out BfSeg x))
                    {
                        dst = criterion(x);
                        result = true;
                    }
                }
                else if(RuleKeyword.parse(input, out var kw))
                {
                    dst = criterion(kw);
                    result = true;
                }
                else if(IsBinaryLiteral(input))
                {
                    if(XedParsers.parse(input, out uint8b x))
                    {
                        dst = criterion(x);
                        result = true;
                    }
                }
                else if(IsHexLiteral(input))
                {
                    if(XedParsers.parse(input, out Hex8 x))
                    {
                        dst = criterion(x);
                        result = true;
                    }
                }
                else if(IsNontermCall(input))
                {
                    if(XedParsers.parse(input, out Nonterminal x))
                    {
                        dst = criterion(x);
                        result = true;
                    }
                }
                return result;
            }

            public static bool parse(string data, out RuleCriterion dst)
            {
                var result = false;
                var input = normalize(data);
                var fk = FieldKind.INVALID;
                var op = OperatorKind.None;
                var fv = input;
                var i = -1;
                dst = RuleCriterion.Empty;
                result = true;
                if(!IsExpr(data))
                {
                    result = Value(data, out dst);
                    if(!result)
                        Errors.Throw(AppMsg.ParseFailure.Format(nameof(RuleCriterion), input));
                }
                else
                {
                    if(parse(input, out CellExpr fx))
                    {
                        dst = criterion(fx);
                        result = true;
                    }
                    if(!result)
                        Errors.Throw(AppMsg.ParseFailure.Format(nameof(RuleCriterion), input));
                }

                return result;
            }

            static bool spec(string src, out CellExpr dst)
            {
                var result = false;
                if(XedParsers.parse(src, out ImmSpec imm))
                {
                    dst = new CellExpr(OperatorKind.None, new (imm));
                    result = true;
                }
                else if(XedParsers.parse(src, out DispSpec disp))
                {
                    dst = new CellExpr(OperatorKind.None, new (disp));
                    result = true;

                }
                else if(XedParsers.parse(src, out BfSpec bf))
                {
                    dst = new CellExpr(OperatorKind.None, new (bf));
                    result = true;
                }
                else
                    dst = CellExpr.Empty;
                return result;
            }

            static bool parse(string src, out CellExpr dst)
            {
                dst = CellExpr.Empty;
                Require.invariant(IsExpr(src));

                var i = text.index(src, "!=");
                var j = text.index(src, "=");
                var right = EmptyString;
                var left = EmptyString;
                var fv = CellValue.Empty;
                var fk = FieldKind.INVALID;
                var op = OperatorKind.None;
                if(i > 0)
                {
                    right = text.right(src, i + 1);
                    op = OperatorKind.Neq;
                    left = text.left(src,i);
                }
                else if (j>0)
                {
                    right = text.right(src, j);
                    op = OperatorKind.Eq;
                    left = text.left(src,j);
                }

                Require.nonempty(left);
                if(IsBfSeg(left))
                {
                    var k = text.index(left,Chars.LBracket);
                    left = text.left(left,k);
                }

                XedParsers.parse(left, out fk);
                Require.nonzero(fk);

                var result = spec(right, out dst);

                if(!result)
                {
                    result = CellValueParser.parse(fk, right, out fv);
                    dst = new CellExpr(op, fv);
                }

                if(!result)
                    Errors.Throw(AppMsg.ParseFailure.Format(nameof(CellExpr), src));

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
                    result = parse(src, out BfSeg x);
                    if(result)
                        dst = part(x);
                    else
                        result = (false, AppMsg.ParseFailure.Format(nameof(BfSeg), src));
                }
                else if (IsExpr(src))
                {
                    result = parse(src, out CellExpr x);
                    if(result)
                        dst = part(x);
                    else
                        result = (false, AppMsg.ParseFailure.Format(nameof(CellExpr), src));
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

            // static bool nonterm(string src, out RuleCriterion dst)
            // {
            //     dst = RuleCriterion.Empty;
            //     var fk = FieldKind.INVALID;
            //     var nt = Nonterminal.Empty;
            //     parse(src, out OperatorKind op);
            //     var fv = EmptyString;
            //     var name = EmptyString;
            //     var result = false;
            //     var i = text.index(src,"()");
            //     if(XedParsers.IsNontermCall(src) && op != 0)
            //     {
            //         var input = text.left(src,i);
            //         var j = text.index(input, Chars.Eq);
            //         var k = text.index(input, Chars.Bang);
            //         if(j > 0)
            //         {
            //             name = text.left(input, j);
            //             fv = text.right(input, j);
            //         }
            //         else if(k > 0)
            //         {
            //             name = text.left(input, k);
            //             fv = text.right(input, k+1);
            //         }

            //         result = XedParsers.parse(name, out fk);
            //         Require.invariant(result);

            //         result = XedParsers.parse(fv, out nt);
            //         if(!result)
            //             Errors.Throw(AppMsg.ParseFailure.Format(nameof(Nonterminal), fv));

            //         dst = criterion(fk, op, nt);
            //     }
            //     else
            //     {
            //         name = text.left(src,i);
            //         result = XedParsers.parse(name, out nt);
            //         dst = criterion(fk, op, nt);
            //     }

            //     return result;
            // }

            static Index<CellSpec> cells(bool premise, string src)
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

                return cells.Map(x => new CellSpec(premise,x));
            }

            public static string normalize(string src)
            {
                var dst = EmptyString;
                var i = text.index(src, Chars.Hash);
                if(i>0)
                    dst = text.despace(text.trim(text.left(src, i)));
                else
                    dst = text.despace(text.trim(src));

                return dst.Replace("->", "=>").Replace("|", "=>").Remove("XED_RESET");
            }
        }
    }
}