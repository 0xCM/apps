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

    public readonly struct LabelAllocation : IDisposable
    {
        public static LabelAllocation allocate(ReadOnlySpan<string> src)
        {
            var count = src.Length;
            var total = 0;
            for(var i=0; i<count; i++)
                total += skip(src,i).Length;

            var buffer  = strings.buffer(total);
            var allocator = buffer.LabelAllocator();
            var labels = core.alloc<Label>(count);
            for(var i=0; i<count; i++)
                allocator.Allocate(skip(src,i), out seek(labels,i));
            return new LabelAllocation(buffer, labels);
        }

        readonly StringBuffer Buffer;

        readonly Index<Label> Labels;

        [MethodImpl(Inline)]
        public LabelAllocation(StringBuffer buffer, Label[] labels)
        {
            Buffer = buffer;
            Labels = labels;
        }

        public ReadOnlySpan<Label> Allocated
        {
            [MethodImpl(Inline)]
            get => Labels;
        }

        public void Dispose()
        {
            Buffer.Dispose();
        }
    }
}