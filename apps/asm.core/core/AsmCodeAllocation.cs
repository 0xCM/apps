//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Collections.Generic;
    using Asm;

    using static core;

    public class AsmCodeAllocation : Allocation<AsmCode>
    {
        public static AsmCodeAllocation allocate<T>(ReadOnlySpan<T> src)
            where T : IAsmEncoding
        {
            var alloc = allocator(src);
            var count = src.Length;
            var dst = core.alloc<AsmCode>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var encoding = ref skip(src,i);
                alloc.Allocate(encoding.Asm.Data, out var source);
                seek(dst,i) = new AsmCode(encoding.Offset, source, encoding.Encoding, encoding.CT);
            }
            return new AsmCodeAllocation(dst, alloc);
        }

        static SourceAllocator allocator<T>(ReadOnlySpan<T> src)
            where T : IAsmEncoding
                => SourceAllocator.create(gcalc.sum(src.Select(x => (uint)x.Asm.Data.Length)));

        internal AsmCodeAllocation(AsmCode[] data, IStringAllocator allocator)
            : base(data,allocator)
        {

        }
    }
}