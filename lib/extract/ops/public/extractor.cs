//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct ApiExtracts
    {
        [Op]
        public static ApiMemberExtractor extractor()
            => new ApiMemberExtractor(buffer());

        [MethodImpl(Inline), Op]
        public static ApiMemberExtractor extractor(byte[] buffer)
            => new ApiMemberExtractor(buffer);
    }
}