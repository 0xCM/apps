//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static core;

    partial struct SpanRes
    {
        [Op]
        public static ApiHostRes hostres(ApiHostBlocks src)
        {
            var count = src.Length;
            var buffer = alloc<BinaryResSpec>(count);
            var dst = span(buffer);
            var blocks = src.Blocks.View;
            for(var i=0u; i<count; i++)
            {
                ref readonly var code = ref skip(blocks,i);
                var name = LegalIdentityBuilder.code(code.Id);
                seek(dst,i) = new BinaryResSpec(name, code.Encoded);
            }
            return new ApiHostRes(src.Host, buffer);
        }

    }
}