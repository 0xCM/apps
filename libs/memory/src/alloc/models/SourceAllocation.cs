//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    /// <summary>
    /// Owns a sequence of <see cref='SourceText'/> allocations
    /// </summary>
    public sealed class SourceAllocation : Allocation<SourceText>
    {
        public static SourceAllocation alloc(ReadOnlySpan<string> src)
        {
            var count = src.Length;
            var total = 0u;
            for(var i=0u; i<count; i++)
                total += (uint)skip(src,i).Length;

            var buffer  = StringBuffers.buffer(total);
            var alloc = SourceAllocator.from(buffer);
            var dst = core.alloc<SourceText>(count);
            for(var i=0; i<count; i++)
                alloc.Alloc(skip(src,i), out seek(dst,i));
            return new SourceAllocation(alloc, dst);
        }

        public SourceAllocation(IBufferAllocator allocator, SourceText[] allocated)
            : base(allocator, allocated)
        {
        }
    }
}