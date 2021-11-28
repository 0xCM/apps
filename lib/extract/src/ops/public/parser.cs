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
        public static ApiExtractParser parser()
            => new ApiExtractParser(buffer());

        [MethodImpl(Inline), Op]
        public static ApiExtractParser parser(byte[] buffer)
            => new ApiExtractParser(buffer);
    }
}