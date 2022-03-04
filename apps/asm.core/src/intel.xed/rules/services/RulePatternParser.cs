//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedModels;
    using static XedRules.RuleParser;

    partial class XedRules
    {
        public ref struct RulePatternParser
        {
            Span<RuleToken> Tokens;

            byte Index;

            byte SourceCount;

            [MethodImpl(Inline)]
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

            public PatternParseResult Parse(string src)
            {
                Reset();
                var i = text.index(src,Chars.Hash);
                var input = text.despace(i > 0 ? text.left(src,i) : src);
                var result = Parse(text.split(input, Chars.Space));
                return new (SourceCount, Index, result);
            }

            static bool parse(string src, out RuleToken dst)
            {
                var result = false;
                dst = RuleToken.Empty;
                if(seg(src, out var bfs))
                {
                    dst = new(bfs);
                    result = true;
                }
                else if(BinaryLiteral(src, out var bin))
                {
                    dst = new(bin);
                    result = true;
                }
                else if(HexLiteral(src, out var hex))
                {
                    dst = new(hex);
                    result = true;
                }
                else if(nonterm(src, out var nt))
                {
                    dst = new(nt);
                    result = true;
                }
                else if(RuleParser.macro(src, out var m))
                {
                    dst = new(MacroNames[m].Kind);
                    result = true;
                }
                else if(constraintkind(src, out var ck))
                {
                    var expr = ConstraintKinds[ck].Expr.Text;
                    var i = text.index(src,expr);
                    if(i > 0)
                    {
                        var a = text.left(src,i);
                        var b = text.right(src,i + expr.Length - 1);
                        result = RuleParser.constraint(src, ck, out var c);
                        dst = new(c);
                    }
                }
                else if(assignment(src, out var assign))
                {
                    dst = new(assign);
                    result = true;
                }
                return result;
            }

            static RulePatternParser()
            {
                Nonterms = Symbols.index<NonterminalKind>();
                MacroNames = Symbols.index<RuleMacroKind>();
                Operators = Symbols.index<RuleOperator>();
                Fields = Symbols.index<FieldKind>();
                ConstraintKinds = Symbols.index<ConstraintKind>();
            }

            static Symbols<RuleMacroKind> MacroNames;

            static Symbols<NonterminalKind> Nonterms;

            static Symbols<RuleOperator> Operators;

            static Symbols<FieldKind> Fields;

            static Symbols<ConstraintKind> ConstraintKinds;
        }
    }
}