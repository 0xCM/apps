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
        public static ReadOnlySpan<byte> definition(SpanResAccessor src)
        {
            const byte size = 29;
            var block = ByteBlocks.alloc(w32);
            var storage = block.Bytes;
            var data = cover<byte>(Resources.jit(src.Member), size);
            for(var i=0; i<size; i++)
                seek(storage,i) = skip(data,i);
            return slice(data,0,size);
        }
    }
}