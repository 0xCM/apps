//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost("api")]
    public partial class ApiCode
    {
        [MethodImpl(Inline), Op]
        public static ApiCodeParser parser(byte[] buffer)
            => new ApiCodeParser(EncodingPatterns.Default, buffer);        
    }
}