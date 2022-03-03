//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public readonly struct PatternParseResult
        {
            public readonly byte SourceCount;

            public readonly byte ParsedCount;

            public readonly bool Succeeded;

            [MethodImpl(Inline)]
            public PatternParseResult(byte src, byte dst, bool ok)
            {
                SourceCount = src;
                ParsedCount = dst;
                Succeeded = ok;
            }
        }
    }
}