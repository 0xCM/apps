//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using K = XedRules.RuleFormKind;

    using static XedRules.SyntaxLiterals;
    using static XedModels;

    partial class XedRules
    {
        internal readonly struct RuleParser
        {
            public static bool IsCall(string src)
                => src.Contains(CallSyntax);

            public static bool IsSeqDecl(string src)
                => src.StartsWith(SeqDeclSyntax);

            public static K classify(TextLine src)
            {
                var i = text.index(src.Content, Chars.Hash);
                var content = (i> 0 ? text.left(src.Content,i) : src.Content).Trim();

                if(content.EndsWith(TableDeclSyntax))
                    return K.RuleDeclaration;
                if(content.Contains(EncStep))
                    return K.EncodeStep;
                if(content.Contains(DecStep))
                    return K.DecodeStep;
                if(IsCall(content))
                    return K.Invocation;
                if(IsSeqDecl(content))
                    return K.SeqDeclaration;
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