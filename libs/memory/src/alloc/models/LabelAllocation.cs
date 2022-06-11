//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    /// <summary>
    /// Owns a sequence of <see cref='Label'/> allocations
    /// </summary>
    public sealed class LabelAllocation : Allocation<Label>
    {
        public static LabelAllocation alloc(ReadOnlySpan<string> src)
        {
            var count = src.Length;
            var total = 0u;
            for(var i=0; i<count; i++)
                total += (uint)skip(src,i).Length;
            var alloc = LabelAllocator.cover(StringBuffers.buffer(total));
            var labels = core.alloc<Label>(count);
            for(var i=0; i<count; i++)
                alloc.Alloc(skip(src,i), out seek(labels,i));
            return new LabelAllocation(alloc, labels);
        }

        public LabelAllocation(IBufferAllocator allocator, Label[] labels)
            : base(allocator, labels)
        {
        }
    }
}