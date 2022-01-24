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

    public class LabelAllocation : IBufferAllocation
    {
        public static LabelAllocation allocate(ReadOnlySpan<string> src)
        {
            var count = src.Length;
            var total = 0u;
            for(var i=0; i<count; i++)
                total += (uint)skip(src,i).Length;

            var storage  = StringBuffers.buffer(total);
            var allocator = storage.LabelAllocator();
            var labels = core.alloc<Label>(count);
            for(var i=0; i<count; i++)
                allocator.Allocate(skip(src,i), out seek(labels,i));
            return new LabelAllocation(allocator, labels);
        }

        readonly IBufferAllocator Allocator;

        readonly Index<Label> Labels;

        public MemoryAddress BaseAddress {get;}

        public ByteSize Size {get;}

        public BitWidth Width
            => Size;

        [MethodImpl(Inline)]
        internal LabelAllocation(IBufferAllocator allocator, Label[] labels)
        {
            Allocator = allocator;
            Labels = labels;
            Size = allocator.Size;
        }

        public ReadOnlySpan<Label> Allocated
        {
            [MethodImpl(Inline)]
            get => Labels;
        }

        public void Dispose()
        {
            Allocator.Dispose();
        }
    }
}