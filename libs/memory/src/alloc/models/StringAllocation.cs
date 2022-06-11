//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    /// <summary>
    /// Owns a sequence of <see cref='StringRef'/> allocations
    /// </summary>
    public sealed class StringAllocation : Allocation<StringRef>
    {
        public static StringAllocation alloc(ReadOnlySpan<string> src)
        {
            var count = src.Length;
            var total = 0u;
            for(var i=0; i<count; i++)
                total += (uint)skip(src,i).Length;
            var storage = StringBuffers.buffer(total);
            var allocator = StringAllocator.cover(storage);
            var dst = core.alloc<StringRef>(count);
            for(var i=0; i<count; i++)
                allocator.Alloc(skip(src,i), out seek(dst,i));
            return new StringAllocation(allocator, dst);
        }

        public StringAllocation(IBufferAllocator allocator, StringRef[] allocated)
            : base(allocator, allocated)
        {
        }
    }
}