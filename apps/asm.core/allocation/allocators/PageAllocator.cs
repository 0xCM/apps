//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public unsafe class PageAllocator : IBufferAllocation
    {
        public static PageAllocator alloc(uint count)
            => new PageAllocator(count);

        PageAllocation Memory;

        Index<int> Allocations;

        public uint PageCapacity {get;}

        public MemoryAddress BaseAddress
        {
            [MethodImpl(Inline)]
            get => Memory.BaseAddress;
        }

        public ByteSize Size
        {
            [MethodImpl(Inline)]
            get => Memory.Size;
        }

        public BitWidth Width
        {
            [MethodImpl(Inline)]
            get => Memory.Width;
        }

        internal PageAllocator(uint pages)
        {
            PageCapacity = pages;
            Memory = PageAllocation.alloc(PageCapacity);
            Allocations = alloc<int>(PageCapacity);
            for(var i=0; i<PageCapacity; i++)
                Allocations[i] = -1;
        }

        [MethodImpl(Inline)]
        MemoryAddress PageAddress(uint index)
            => Memory.PageAddress(index);

        public MemoryAddress Alloc()
        {
            for(var i=0u; i<PageCapacity; i++)
            {
                if(Allocations[i] < 0)
                {
                    Allocations[i] = (int)i;
                    return PageAddress(i);
                }
            }
            return MemoryAddress.Zero;
        }

        public void FreePage(MemoryAddress src)
        {
            for(var i=0u; i<PageCapacity; i++)
            {
                ref readonly var index = ref Allocations[i];
                if(Allocations[i] > 0 && PageAddress(i) == src)
                    Allocations[i] = -1;
            }
        }

        public void Dispose()
        {
            Memory.Dispose();
        }
    }
}