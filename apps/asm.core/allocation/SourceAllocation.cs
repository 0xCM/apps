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

    public class SourceAllocation : Allocation<SourceText>
    {
        public static SourceAllocation allocate(ReadOnlySpan<string> src)
        {
            var count = src.Length;
            var total = 0u;
            for(var i=0u; i<count; i++)
                total += (uint)skip(src,i).Length;

            var buffer  = StringBuffers.buffer(total);
            var allocator = buffer.SourceAllocator();
            var dst = core.alloc<SourceText>(count);
            for(var i=0; i<count; i++)
                allocator.Allocate(skip(src,i), out seek(dst,i));

            return new SourceAllocation(allocator, dst);
        }

        [MethodImpl(Inline)]
        internal SourceAllocation(IBufferAllocator allocator, SourceText[] allocated)
            : base(allocator, allocated)
        {
        }
    }
}