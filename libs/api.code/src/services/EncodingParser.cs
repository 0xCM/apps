//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using K = EncodingPatternKind;
    using S = EncodingParserState;

    [ApiHost]
    public ref struct EncodingParser
    {
        [MethodImpl(Inline), Op]
        internal static ReadOnlySpan<byte> parsed(in EncodingParser parser)
            => (parser.Offset + parser.Delta - 1) > 0 ? parser.Buffer.Slice(0, parser.Offset + parser.Delta - 1) : sys.empty<byte>();

        [MethodImpl(Inline), Op]
        public static bool failed(EncodingParserState state)
            => state == EncodingParserState.Failed;

        [MethodImpl(Inline), Op]
        public static ExtractTermCode termcode(EncodingPatternKind src)
        {
            if (src != 0)
                return (ExtractTermCode)src;
            else
                return ExtractTermCode.Fail;
        }

        [MethodImpl(Inline), Op]
        public static EncodingParser create(byte[] buffer)
            => new EncodingParser(EncodingPatterns.Default, buffer);

        public readonly Span<byte> Buffer;

        public int Offset;

        public S State;

        internal K Outcome;

        public int Delta;

        readonly EncodingPatterns Patterns;

        public byte[] Parsed
            => ParsedSlice.ToArray();

        ReadOnlySpan<byte> ParsedSlice
            => parsed(this);

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
        public S Parse(ReadOnlySpan<byte> src)
        {
            Start();

            var i = 0;

            while (i < src.Length && !Finished())
                Parse(src[i++]);

            if (State == S.Accepting)
                State = S.Unmatched;

            return State;
        }

        public K Result
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
            if (State == S.Accepting && Offset < Buffer.Length)
            {
                seek(Buffer, Offset++) = src;
                if (TryMatch(out Outcome, out Delta))
                {
                    if (Patterns.IsSuccessPattern(Outcome))
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

            for (var i = 0; i < Patterns.Count; i++)
            {
                ref readonly var match = ref Patterns[i];
                var pattern = Patterns.Pattern(match);
                var len = pattern.Length;
                var matched = Offset > len ? Buffer.Slice(Offset - 1 - len, len).EndsWith(pattern) : false;
                if (matched)
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