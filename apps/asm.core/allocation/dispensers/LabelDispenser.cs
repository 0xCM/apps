//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class LabelDispenser : IAllocationDispenser
    {
        public static LabelAllocation allocation(ReadOnlySpan<string> src)
        {
            var count = src.Length;
            var total = 0u;
            for(var i=0; i<count; i++)
                total += (uint)skip(src,i).Length;

            var storage  = StringBuffers.buffer(total);
            var alloc = LabelAllocator.alloc(storage);
            var labels = core.alloc<Label>(count);
            for(var i=0; i<count; i++)
                alloc.Alloc(skip(src,i), out seek(labels,i));
            return new LabelAllocation(alloc, labels);
        }

        const uint Capacity = PageBlock.PageSize;

        readonly Dictionary<long,LabelAllocator> Allocators;

        object locker;

        internal LabelDispenser(uint capacity = Capacity)
        {
            Allocators = new();
            locker = new();
            Allocators[Seq] = LabelAllocator.alloc(Capacity);
        }

        public Label Dispense(@string content)
        {
            var label = Label.Empty;
            lock(locker)
            {
                var alloc = Allocators[Seq];
                if(!alloc.Alloc(content.Value, out label))
                {
                    alloc = LabelAllocator.alloc(Capacity);
                    alloc.Alloc(content.Value, out label);
                    Allocators[next()] = alloc;
                }
            }
            return label;
        }


        void IDisposable.Dispose()
            => core.iter(Allocators.Values, a => a.Dispose());

        static long Seq;

        [MethodImpl(Inline)]
        static uint next()
            => (uint)inc(ref Seq);
    }
}