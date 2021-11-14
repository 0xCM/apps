//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static core;

    partial struct ApiExtracts
    {
        [Op]
        public static uint terminals(ReadOnlySpan<ApiMemberCode> src, Span<MemoryBlock> dst)
        {
            var count = src.Length;
            var j = 0u;
            for(var i=0; i<count; i++)
            {
                ref readonly var extract = ref skip(src,i);
                var term = terminal(extract.Encoded.Bytes);
                if(term.TerminalFound)
                    seek(dst, j++) = memblock(extract, term);
            }
            return j;
        }
    }
}