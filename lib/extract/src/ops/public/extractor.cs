//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

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