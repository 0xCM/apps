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

    public class SourceAllocation : IBufferAllocation
    {
        public static SourceAllocation allocate(ReadOnlySpan<string> src)
        {
            var count = src.Length;
            var total = 0u;
            for(var i=0u; i<count; i++)
                total += (uint)skip(src,i).Length;

            var storage  = StringBuffers.buffer(total);
            var allocator = storage.SourceAllocator();
            var dst = core.alloc<SourceText>(count);
            for(var i=0; i<count; i++)
                allocator.Allocate(skip(src,i), out seek(dst,i));
            return new SourceAllocation(allocator, dst);
        }

        readonly IBufferAllocator Allocator;

        readonly Index<SourceText> Sources;

        public MemoryAddress BaseAddress {get;}

        public ByteSize Capacity {get;}

        [MethodImpl(Inline)]
        internal SourceAllocation(IBufferAllocator allocator, SourceText[] sources)
        {
            Allocator = allocator;
            BaseAddress = allocator.BaseAddress;
            Capacity = allocator.Capacity;
            Sources = sources;
        }

        public ReadOnlySpan<SourceText> Allocated
        {
            [MethodImpl(Inline)]
            get => Sources;
        }

        public void Dispose()
        {
            Allocator.Dispose();
        }
    }
}