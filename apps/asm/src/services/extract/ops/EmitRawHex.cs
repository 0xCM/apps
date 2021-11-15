//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    partial class ApiExtractor
    {
        uint EmitRawHex(ApiHostUri host, ReadOnlySpan<ApiMemberExtract> src)
        {
            var count = (uint)src.Length;
            if(count == 0)
                return 0;

            HexPacks.Emit(ApiHex.blocks(src), PackArchive.RawHexPath(host));
            return count;
        }
    }
}