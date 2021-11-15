//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Globalization;

    using static HexFormatSpecs;

    [ApiHost]
    public readonly struct HexNumericParser
    {
        public static ParseResult<ulong> parse64u(string src)
        {
            if(ulong.TryParse(ClearSpecs(src), NumberStyles.HexNumber, null, out ulong value))
                return ParseResult.parsed(src,value);
            else
                return ParseResult.unparsed<ulong>(src);
        }
    }
}