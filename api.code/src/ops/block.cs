//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ApiCode
    {
        [MethodImpl(Inline), Op]
        public static ApiCodeBlock block(in ApiHexRow src)
            => new ApiCodeBlock(src.Address, src.Uri, src.Data);
    }
}