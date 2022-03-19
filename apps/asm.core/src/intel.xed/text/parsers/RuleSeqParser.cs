//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedRules.SyntaxLiterals;
    using static XedParsers;

    partial class XedRules
    {
        public readonly struct RuleSeqParser
        {
            public Index<RuleSeq> Parse(FS.FilePath src)
                => Parse(src.ReadNumberedLines());

            public Index<RuleSeq> Parse(ReadOnlySpan<TextLine> src)
            {
                var count = src.Length;
                var buffer = list<RuleSeq>();
                var terms = list<RuleSeqTerm>();
                var result = Outcome.Success;
                for(var j=0u; j<count; j++)
                {
                    ref readonly var line = ref skip(src,j);
                    if(line.IsEmpty)
                        continue;

                    var @class = RuleTableParser.form(line.Content);
                    if(@class == RuleFormKind.SeqDecl)
                    {
                        var content = text.despace(line.Content);
                        var i = text.index(content, Chars.Space);
                        var name = text.right(content, i);
                        terms.Clear();
                        j++;

                        if(ParseTerms(src, ref j, terms) != 0)
                        {
                            buffer.Add(new RuleSeq(name, terms.ToArray()));
                            terms.Clear();
                            content = text.despace(skip(src,j).Content);
                            if(IsSeqDecl(content))
                            {
                                i = text.index(content, Chars.Space);
                                name = text.right(content, i);
                                ParseSeq(name, src, ref j, buffer);
                            }
                        }
                    }
                }
                return buffer.ToArray();
            }

            void ParseSeq(Identifier name, ReadOnlySpan<TextLine> src, ref uint j, List<RuleSeq> dst)
            {
                var content = text.despace(skip(src,j).Content);
                var terms = list<RuleSeqTerm>();
                if(ParseTerms(src, ref j, terms) != 0)
                {
                    dst.Add(new RuleSeq(name, terms.ToArray()));
                    content = text.despace(skip(src,j).Content);
                    if(IsSeqDecl(content))
                    {
                        var i = text.index(content, Chars.Space);
                        name = text.right(content, i);
                        ParseSeq(name, src, ref j, dst);
                    }
                }
            }

            uint ParseTerms(ReadOnlySpan<TextLine> src, ref uint j, List<RuleSeqTerm> terms)
            {
                var i0 = j;
                for(;j<src.Length; j++)
                {
                    ref readonly var line = ref skip(src,j);
                    if(line.IsEmpty)
                        break;

                    if(!text.begins(line.Content, "   "))
                        break;

                    var content = line.Content.Trim();
                    if(text.begins(content, Chars.Hash))
                        continue;

                    var q = text.index(content, Chars.Hash);
                    if(q > 0)
                        content = text.left(content, q);

                    if(IsNonterminal(content))
                    {
                        var k = text.index(content, CallSyntax);
                        terms.Add(new RuleSeqTerm(text.left(content,k), IsNonterminal(content)));
                    }
                    else
                        terms.Add(new RuleSeqTerm(content, false));
                }
                return (uint)terms.Count;
            }
       }
    }
}