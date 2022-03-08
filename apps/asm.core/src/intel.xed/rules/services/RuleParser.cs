//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static XedRules.SyntaxLiterals;
    using static XedModels;
    using static core;

    using FK = XedRules.RuleFormKind;

    partial class XedRules
    {
        internal readonly struct RuleParser
        {
            public static bool IsCall(string src)
                => src.Contains(CallSyntax);

            public static bool IsSeqDecl(string src)
                => src.StartsWith(SeqDeclSyntax);

            public static FK classify(TextLine src)
            {
                var i = text.index(src.Content, Chars.Hash);
                var content = (i> 0 ? text.left(src.Content,i) : src.Content).Trim();

                if(content.EndsWith(TableDeclSyntax))
                    return FK.RuleDeclaration;
                if(content.Contains(EncStep))
                    return FK.EncodeStep;
                if(content.Contains(DecStep))
                    return FK.DecodeStep;
                if(IsCall(content))
                    return FK.Invocation;
                if(IsSeqDecl(content))
                    return FK.SeqDeclaration;
                return 0;
            }

            [MethodImpl(Inline)]
            public static bool IsHexLiteral(string src)
                => text.begins(src, HexFormatSpecs.PreSpec);

            [MethodImpl(Inline)]
            public static bool HexLiteral(string src, out Hex8 dst)
            {
                if(IsHexLiteral(src))
                    return DataParser.parse(src, out dst);

                dst = default;
                return false;
            }

            public static bool assignment(string src, out FieldAssign dst)
            {
                var i = text.index(src,Chars.Eq);
                dst = FieldAssign.Empty;
                var result = false;
                if(i > 0)
                {
                    var name = text.left(src,i);
                    var val = text.right(src,i);
                    if(FieldKinds.Lookup(name, out var fk))
                    {
                        if(BinaryLiteral(src, out var b))
                        {
                            dst = assign(fk,b);
                            result = true;
                        }
                        else if(HexLiteral(src, out var h))
                        {
                            dst = assign(fk,h);
                            result = true;
                        }
                        else if(ulong.TryParse(src, out var d))
                        {
                            dst = assign(fk,d);
                            result = true;
                        }
                    }
                }
                return result;
            }

            public static bool BinaryLiteral(string src, out uint8b dst)
            {
                if(IsBinaryLiteral(src))
                    return DataParser.parse(src, out dst);
                else
                {
                    dst = default;
                    return false;
                }
            }

            [MethodImpl(Inline)]
            public static bool IsBinaryLiteral(string src)
                => text.begins(src, "0b");

            public static bool nonterm(string src, out NonterminalKind kind)
            {
                kind = default;
                var result = false;
                if(call(src, out var name))
                {
                    if(Nonterminals.Lookup(name, out var sym))
                    {
                        kind = sym.Kind;
                        result = true;
                    }
                }
                return result;
            }

            public static bool constraintkind(string src, out ConstraintKind kind)
            {
                kind = 0;
                if(text.contains(src, "!="))
                {
                    kind = ConstraintKind.Neq;
                }
                else if(text.contains(src, "="))
                {
                    kind = ConstraintKind.Eq;
                }
                return kind != 0;
            }

            static bool call(string src, out string name)
            {
                var result = false;
                name = EmptyString;
                if(text.ends(src, "()"))
                {
                    var i = text.index(src,Chars.LParen);
                    name = text.left(src,i);
                    result = true;
                }
                return result;
            }

            public static bool macro(string src, out RuleMacroKind dst)
            {
                if(MacroKinds.Lookup(src, out var sym))
                {
                    dst = sym.Kind;
                    return true;
                }
                else
                {
                    dst = 0;
                    return false;
                }
            }

            public static Outcome xedreg(string src, out XedRegId dst)
            {
                var result = XedRegs.Lookup(src, out var reg);
                if(result)
                    dst = reg.Kind;
                else
                {
                    if(src == "MM0")
                    {
                        dst = XedRegId.MMX0;
                        result = true;
                    }
                    else if(src == "MM1")
                    {
                        dst = XedRegId.MMX1;
                        result = true;
                    }
                    else if(src == "MM2")
                    {
                        dst = XedRegId.MMX2;
                        result = true;
                    }

                    dst = default;

                }
                return result;
            }

            public static Outcome immfield(string src, out ImmFieldSpec dst)
            {
                var i = text.index(src, Chars.LBracket);
                var j = text.index(src, Chars.RBracket);
                var kind = Chars.x;
                var width = z8;
                var index = z8;
                var result = Outcome.Success;

                if(text.contains(src,"UIMM1"))
                    index = 1;

                if(i > 0 && j > i)
                {
                    var inside = text.inside(src,i,j);
                    var quotient = text.split(inside,Chars.FSlash);
                    if(quotient.Length != 2)
                        result = (false,AppMsg.ParseFailure.Format(nameof(DispFieldSpec), src));

                    else
                    {
                        ref readonly var upper = ref skip(quotient,0);
                        ref readonly var lower = ref skip(quotient,1);

                        if(upper.Length == 1)
                            kind = upper[0];
                        if(!byte.TryParse(lower, out width))
                            result = (false,AppMsg.ParseFailure.Format(nameof(width), lower));
                    }

                }

                dst = new ImmFieldSpec(index, width);
                return result;
            }

            public static bool seg(string src, out BitfieldSeg dst)
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
                    if(FieldKinds.Lookup(name, out var sym))
                    {
                        var literal = text.begins(content,"0b");
                        dst = new BitfieldSeg(sym.Kind, text.remove(content,"0b"), literal);
                        result = true;
                    }
                }
                return result;
            }

            public static bool constraint(string src, ConstraintKind kind, out FieldConstraint dst)
            {
                dst = FieldConstraint.Empty;
                var result = false;
                if(constraintkind(src, out var ck))
                {
                    var expr = ConstraintKinds[ck].Expr.Text;
                    var i = text.index(src,expr);
                    if(i > 0)
                    {
                        var a = text.left(src,i);
                        var b = text.right(src,i + expr.Length - 1);
                        result = FieldKinds.Lookup(a, out var sym);
                        Require.invariant(result);
                        var fk = sym.Kind;
                        if(IsHexLiteral(a))
                        {
                            result = NumericParser.num8<Hex8>(b, out var value);
                            dst = new FieldConstraint(fk, ck, value, FieldLiteralKind.HexLiteral);
                        }
                        else if(IsBinaryLiteral(a))
                        {
                            result = NumericParser.num8<uint8b>(b, out var value);
                            dst = new FieldConstraint(fk, ck, value, FieldLiteralKind.BinaryLiteral);
                        }
                        else
                        {
                            result = NumericParser.num8<uint8b>(b, out var value);
                            dst = new FieldConstraint(fk, ck, value, FieldLiteralKind.DecimalLiteral);
                        }
                    }
                }
                return result;
            }
        }
    }
}