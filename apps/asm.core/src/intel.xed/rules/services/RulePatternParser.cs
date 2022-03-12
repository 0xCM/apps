//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

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
                var result = XedParsers.parse(src, out RuleToken token);
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

            static RulePatternParser()
            {
            }
       }
    }
}