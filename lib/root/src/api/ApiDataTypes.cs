//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    [ApiHost]
    public readonly struct ApiDataTypes
    {
        [MethodImpl(Inline), Op]
        public static ApiDataType empty()
            => new ApiDataType(new EmptyDataType());

        [MethodImpl(Inline)]
        public static ApiDataType metadata<T>(T src, uint width = 0)
            where T : IDataType
                => new ApiDataType(src, width);
    }
}