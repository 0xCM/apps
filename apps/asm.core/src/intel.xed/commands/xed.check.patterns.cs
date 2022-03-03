//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    using static core;
    using static XedRules;
    using static XedModels;

    public ref struct RulePatternParser
    {
        Span<RuleToken> Tokens;

        byte Index;

        byte SourceCount;

        public RulePatternParser(Span<RuleToken> buffer)
        {
            Tokens = buffer;
            Index = 0;
            SourceCount = 0;
        }

        bool ParseToken(string src)
        {
            var result = parse(src, out var token);
            if(result)
                seek(Tokens,Index++) = token;
            return result;
        }

        bool Parse(ReadOnlySpan<string> src)
        {
            SourceCount = (byte)src.Length;
            var result = true;
            for(var i=0; i<SourceCount; i++)
            {
                result = ParseToken(skip(src,i));
                if(!result)
                    break;
            }
            return result;
        }

        void Reset()
        {
            Index = 0;
            SourceCount = 0;
            Tokens.Clear();
        }

        public Tripled<bool,byte,byte> Parse(string src)
        {
            Reset();
            var i = text.index(src,Chars.Hash);
            var input = text.despace(i > 0 ? text.left(src,i) : src);
            var result = Parse(text.split(input, Chars.Space));
            if(result)
                return (true, SourceCount, Index);
            else
                return (false, SourceCount, Index);
        }

        static bool parse(string src, out RuleToken dst)
        {
            var result = false;
            dst = default;
            if(Seg(src, out var seg))
            {
                dst = new RuleToken(RuleTokenKind.FieldSeg, seg.Format());
                result = true;
            }
            else if(BinaryLiteral(src, out var binlit))
            {
                dst = new RuleToken(RuleTokenKind.BinLit, binlit.Format());
                result = true;
            }
            else if(HexLiteral(src, out var hexlit))
            {
                dst = new RuleToken(RuleTokenKind.HexLit, hexlit.Format());
                result = true;
            }
            else if(NontermCall(src, out var nonterm))
            {
                dst = new RuleToken(RuleTokenKind.Nonterm, nonterm);
                result = true;
            }
            else if(Macro(src, out var macro))
            {
                dst = new RuleToken(RuleTokenKind.Macro, MacroNames[macro].Expr.Format());
                result = true;
            }
            else if(IsConstraint(src, out var ck))
            {
                var expr = ConstraintKinds[ck].Expr.Text;
                var i = text.index(src,expr);
                if(i > 0)
                {
                    var a = text.left(src,i);
                    var b = text.right(src,i + expr.Length - 1);
                    if(IsHexLiteral(a))
                    {
                        result = constraint<Hex8>(src, ck, out var constraint);
                        dst = new RuleToken(RuleTokenKind.Constraint, constraint.Format());
                    }
                    else if(IsBinaryLiteral(a))
                    {
                        result = constraint<uint8b>(src, ck, out var constraint);
                        dst = new RuleToken(RuleTokenKind.Constraint, constraint.Format());
                    }
                    else
                    {
                        result = constraint<byte>(src, ck, out var constraint);
                        dst = new RuleToken(RuleTokenKind.Constraint, constraint.Format());
                    }
                }
            }
            return result;
        }

        static bool Macro(string src, out RuleMacroName dst)
        {
            if(MacroNames.Lookup(src, out var sym))
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

        [MethodImpl(Inline)]
        static bool Seg(string src, out BitfieldSeg dst)
        {
            var name = EmptyString;
            var content = EmptyString;
            dst = default;
            var i = text.index(src,Chars.LBracket);
            var j = text.index(src,Chars.RBracket);
            var result = false;
            if(i > 0 && j > i)
            {
                name = text.left(src,i);
                content = text.inside(src,i,j);
                if(Fields.Lookup(name, out var sym))
                {
                    dst = new BitfieldSeg(sym.Kind, content);
                    result = true;
                }
            }
            return result;
        }

        static bool BinaryLiteral(string src, out uint8b dst)
        {
            if(IsBinaryLiteral(src))
                return DataParser.parse(src, out dst);
            else
            {
                dst = default;
                return false;
            }
        }

        static bool constraint<T>(string src, ConstraintKind kind, out FieldConstraint<T> dst)
            where T : unmanaged
        {
            var expr = ConstraintKinds[kind].Expr.Text;
            var i = text.index(src, expr);
            var a = FieldKind.INVALID;
            var b = EmptyString;
            dst = default;
            var result = false;
            if(i > 0)
            {
                if(Fields.Lookup(text.left(src,i), out var sym))
                {
                    a = sym.Kind;
                    b = text.right(src,i + expr.Length - 1);
                    result = NumericParser.num8<T>(b, out var n);
                    if(result)
                        dst = new FieldConstraint<T>(a, kind, n);
                }

            }

            return result;
        }

        static bool NontermCall(string src, out string name)
        {
            if(Call(src, out name))
            {
                if(Nonterms.Lookup(name, out var sym))
                {
                    name = sym.Expr.Text;
                    return true;
                }
            }
            name = EmptyString;
            return false;
        }

        static bool Call(string src, out string name)
        {
            if(text.ends(src, "()"))
            {
                var i = text.index(src,Chars.LParen);
                name = text.left(src,i);
                return true;
            }
            else
            {
                name = EmptyString;
                return false;
            }
        }

        [MethodImpl(Inline)]
        static bool IsHexLiteral(string src)
            => text.begins(src, HexFormatSpecs.PreSpec);

        [MethodImpl(Inline)]
        static bool HexLiteral(string src, out Hex16 dst)
        {
            if(IsHexLiteral(src))
                return DataParser.parse(src, out dst);

            dst = default;
            return false;
        }

        [MethodImpl(Inline)]
        static bool IsBinaryLiteral(string src)
            => text.begins(src, "0b");

        static bool IsConstraint(string src, out ConstraintKind kind)
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

        static RulePatternParser()
        {
            Nonterms = Symbols.index<NonterminalKind>();
            MacroNames = Symbols.index<RuleMacroName>();
            Operators = Symbols.index<RuleOperator>();
            Fields = Symbols.index<FieldKind>();
            ConstraintKinds = Symbols.index<ConstraintKind>();
        }

        static Symbols<RuleMacroName> MacroNames;

        static Symbols<NonterminalKind> Nonterms;

        static Symbols<RuleOperator> Operators;

        static Symbols<FieldKind> Fields;

        static Symbols<ConstraintKind> ConstraintKinds;
    }

    partial class XedCmdProvider
    {
        [CmdOp("xed/check/patterns")]
        Outcome CheckPatterns(CmdArgs args)
        {
            var result = Outcome.Success;
            var patterns = Xed.Rules.LoadPatternInfo(RuleSetKind.Enc);
            var opcodes = Xed.Rules.CalcOpCodes(patterns);
            var count = patterns.Count;
            var buffer = span<RuleToken>(32);
            var parser = new RulePatternParser(buffer);
            var path = AppDb.XedPath("xed.rules.patterns.checks", FileKind.Csv);
            var emitting = EmittingFile(path);
            using var writer = path.AsciWriter();
            for(var i=0; i<count; i++)
            {
                ref readonly var pattern = ref patterns[i];
                var expr = pattern.Expression;
                (var ok, var sk, var tk) = parser.Parse(expr);
                var parsed = slice(buffer,0,tk);
                var parts = text.split(text.despace(text.trim(expr)), Chars.Space);
                //Require.equal(tk, (byte)parts.Length);
                var pad = -32;
                var sep = " | ";
                writer.WriteLine(expr);
                writer.WriteLine(delimit(parts, sep, pad));
                writer.WriteLine(delimit(parsed.Map(format), sep, pad));
                writer.WriteLine(RP.PageBreak1024);
                if(!ok)
                {
                    result = (false,string.Format("Parse incomplete: {0}/{1} succeeded", tk, sk));
                    break;
                }
            }

            EmittedFile(emitting,count);
            return result;
        }

        static string delimit<T>(ReadOnlySpan<T> src,string sep, int pad = 0)
        {
            var dst = text.buffer();
            var count = src.Length;
            for(var i=0; i<count; i++)
            {
                if(i!=0)
                    dst.Append(sep);
                dst.AppendFormat(RP.pad(pad), skip(src,i));
            }
            return dst.Emit();

        }

        static string delimit<T>(T[] src,string sep, int pad = 0)
            => delimit(@readonly(src), sep, pad);

        static string delimit<T>(Span<T> src,string sep, int pad = 0)
            => delimit(@readonly(src), sep, pad);

        static string format(RuleToken token)
        {
            var value = token.Value;
            switch(token.Kind)
            {
                case RuleTokenKind.Nonterm:
                    value = string.Format("{0}()", token.Value);
                break;
                default:
                break;
            }
            return string.Format("<{0}:{1}>", value, token.Kind);
        }
    }
}