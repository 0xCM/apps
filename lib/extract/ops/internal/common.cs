//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct ApiExtracts
    {
        [MethodImpl(Inline), Op]
        internal static bool failed(EncodingParserState state)
            => state == EncodingParserState.Failed;

        [MethodImpl(Inline), Op]
        internal static ExtractTermCode termcode(EncodingPatternKind src)
        {
            if(src != 0)
                return (ExtractTermCode)src;
            else
                return ExtractTermCode.Fail;
        }

        [MethodImpl(Inline), Op]
        internal static ReadOnlySpan<byte> parsed(in EncodingParser parser)
            => (parser.Offset + parser.Delta - 1) > 0 ? parser.Buffer.Slice(0, parser.Offset + parser.Delta - 1) : Array.Empty<byte>();
    }
}