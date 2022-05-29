//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using EP = EncodingParser;
    using api = ApiExtracts;

    public readonly struct ApiExtractParser
    {
        readonly byte[] Buffer;

        [MethodImpl(Inline)]
        internal ApiExtractParser(byte[] buffer)
            => Buffer = buffer;

        EP Parser
        {
            [MethodImpl(Inline)]
            get => EncodingParser.create(Buffer.Clear());
        }

        public Index<ApiMemberCode> ParseMembers(ReadOnlySpan<ApiMemberExtract> src)
            => api.parse(Parser,src);

        public bool Parse(in ApiMemberExtract src, out ApiMemberCode code)
            => api.parse(Parser, src, out code);
    }
}