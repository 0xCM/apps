//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class MemoryDispenser : IAllocationDispenser
    {
        const uint Capacity = PageBlock.PageSize*16;

        readonly Dictionary<long,MemAllocator> Allocators;

        object locker;

        internal MemoryDispenser(uint capacity = Capacity)
        {
            locker = new();
            Allocators = new();
            Allocators[Seq] = MemAllocator.alloc(Capacity);
        }

        public void Dispose()
        {
            core.iter(Allocators.Values, a => a.Dispose());
        }

        public AllocationKind DispensedKind
            => AllocationKind.Memory;

        MemorySeg Allocate(ByteSize size)
        {
            var dst = MemorySeg.Empty;
            lock(locker)
            {
                var allocator = Allocators[Seq];
                if(!allocator.Alloc(size, out dst))
                {
                    if(size < Capacity)
                        allocator = MemAllocator.alloc(Capacity);
                    else
                        allocator = MemAllocator.alloc(size);

                    allocator.Alloc(size, out dst);
                    Allocators[next()] = allocator;
                }
            }
            return dst;
        }

        public MemorySeg Memory(ByteSize size)
        {
            var dst = Allocate(size);
            return dst;
        }

        static long Seq;

        [MethodImpl(Inline)]
        static uint next()
            => (uint)inc(ref Seq);
    }
}