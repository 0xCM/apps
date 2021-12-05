//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    partial struct SpanRes
    {
        [MethodImpl(Inline), Op]
        public static unsafe SpanResInfo load(SpanResAccessor src)
        {
            var data = description(src);
            var address = slice(data, 8, 8).TakeUInt64();
            var size = slice(data, 22, 4).TakeUInt32();
            return new SpanResInfo(src, address, size);
        }
    }
}