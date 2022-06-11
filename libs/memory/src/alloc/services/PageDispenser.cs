//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class PageDispenser : IAllocDispenser
    {
        readonly Dictionary<long,PageAllocator> Allocators;

        object locker;

        const uint Capacity = 64;

        static ByteSize PageSize => PageBlocks.PageSize;

        public PageDispenser(uint capacity = Capacity)
        {
            Allocators = new();
            locker = new();
            Allocators[Seq] = PageAllocator.alloc(Capacity);
        }

        public AllocationKind Kind
            => AllocationKind.Page;

        public MemorySeg Page()
        {
            var address = MemoryAddress.Zero;
            lock(locker)
            {
                address = Allocators[Seq].Alloc();
                if(address == 0)
                {
                    var allocator = PageAllocator.alloc(Capacity);
                    Allocators[next()] = allocator;
                    address = allocator.Alloc();
                }
            }
            return new MemorySeg(address, PageSize);
        }

        static long Seq;

        [MethodImpl(Inline)]
        static uint next()
            => (uint)inc(ref Seq);

        public void Dispose()
            => core.iter(Allocators.Values, a => a.Dispose());
    }

}