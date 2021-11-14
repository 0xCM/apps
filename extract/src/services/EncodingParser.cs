//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    using K = EncodingPatternKind;
    using S = EncodingParserState;
    using api = ApiExtracts;

    [ApiHost]
    public ref struct EncodingParser
    {
        internal readonly Span<byte> Buffer;

        internal int Offset;

        internal S State;

        internal K Outcome;

        internal int Delta;

        internal readonly EncodingPatterns Patterns;

        public byte[] Parsed
            => ParsedSlice.ToArray();

        ReadOnlySpan<byte> ParsedSlice
            => api.parsed(this);

        internal EncodingParser(EncodingPatterns patterns, byte[] buffer)
        {
            Buffer = buffer;
            Patterns = patterns;
            Offset = default;
            State = default;
            Outcome = default;
            Delta = default;
        }

        [Op]
        internal S Parse(ReadOnlySpan<byte> src)
        {
            Start();

            var i=0;

            while(i < src.Length && !Finished())
                Parse(src[i++]);

            if(State == S.Accepting)
                State = S.Unmatched;

            return State;
        }

        internal K Result
        {
            [MethodImpl(Inline)]
            get => Finished() ? Outcome : default;
        }

        void Start()
        {
            Buffer.Clear();
            Offset = default;
            State = S.Accepting;
            Outcome = default;
            Delta = default;
        }

        [MethodImpl(Inline)]
        bool Finished()
            => (State & EncodingParserState.Completed) != 0;

        [Op]
        S Parse(byte src)
        {
            if(State == S.Accepting && Offset < Buffer.Length)
            {
                seek(Buffer, Offset++) = src;

                if(TryMatch(out Outcome, out Delta))
                {
                    if(Patterns.IsSuccessPattern(Outcome))
                        State = S.Succeeded;
                    else
                        State = S.Failed;
                }
            }

            return State;
        }

        [Op]
        bool TryMatch(out K kind, out int delta)
        {
            kind = default;
            delta = 0;

            ref readonly var codes = ref first(Patterns.Kinds);
            for(var i=0; i<Patterns.PatternCount; i++)
            {
                var match = skip(codes,i);
                var pattern = Patterns.Pattern(match);
                var len = pattern.Length;
                var matched = Offset > len ? Buffer.Slice(Offset -  1 - len, len).EndsWith(pattern) : false;
                if(matched)
                {
                    kind = match;
                    delta = (int)Patterns.MatchOffset(match);
                    return true;
                }
            }

            return false;
        }
    }
}