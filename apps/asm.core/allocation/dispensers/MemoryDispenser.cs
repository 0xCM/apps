//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class MemoryDispenser : IAllocationDispenser
    {
        public static MemoryDispenser alloc(ByteSize capacity)
            => new MemoryDispenser(capacity);

        public static MemoryDispenser alloc()
            => new MemoryDispenser();

       static long Seq;

        [MethodImpl(Inline)]
        static uint next()
            => (uint)inc(ref Seq);

        const uint Capacity = PageBlock.PageSize*8;

        readonly Dictionary<long,MemAllocator> Allocators;

        object locker;

        MemoryDispenser(uint capacity = Capacity)
        {
            locker = new();
            Allocators = new();
            Allocators[Seq] = MemAllocator.alloc(Capacity);
        }

        public void Dispose()
        {
            core.iter(Allocators.Values, a => a.Dispose());
        }

        MemorySeg Allocate(ByteSize size)
        {
            var dst = MemorySeg.Empty;
            lock(locker)
            {
                var allocator = Allocators[Seq];
                if(!allocator.Allocate(size, out dst))
                {
                    if(size < Capacity)
                        allocator = MemAllocator.alloc(Capacity);
                    else
                        allocator = MemAllocator.alloc(size);

                    allocator.Allocate(size, out dst);
                    Allocators[next()] = allocator;
                }
            }
            return dst;
        }

        public MemorySeg Dispense(ByteSize size)
        {
            var dst = Allocate(size);
            return dst;
        }
    }
}