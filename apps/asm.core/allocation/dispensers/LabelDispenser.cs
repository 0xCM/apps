//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class LabelDispenser : IAllocationDispenser
    {
        public static LabelDispenser alloc(ByteSize capacity)
            => new LabelDispenser(capacity);

        public static LabelDispenser alloc()
            => new LabelDispenser();

        const uint Capacity = PageBlock.PageSize;


        readonly Dictionary<long,LabelAllocator> Allocators;

        object locker;

        LabelDispenser(uint capacity = Capacity)
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
                var allocator = Allocators[Seq];
                if(!allocator.Allocate(content.Value, out label))
                {
                    allocator = LabelAllocator.alloc(Capacity);
                    allocator.Allocate(content.Value, out label);
                    Allocators[next()] = allocator;
                }
            }
            return label;
        }


        void IDisposable.Dispose()
        {
            core.iter(Allocators.Values, a => a.Dispose());
        }

        static long Seq;

        [MethodImpl(Inline)]
        static uint next()
            => (uint)inc(ref Seq);
    }
}