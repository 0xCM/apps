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

    public unsafe class MemAlloc : IDisposable
    {
        public static MemAlloc alloc(uint pages)
            => new MemAlloc(pages);

        PageBank Memory;

        Index<int> Allocations;

        public uint PageCapacity {get;}

        internal MemAlloc(uint pages)
        {
            PageCapacity = pages;
            Memory = PageBank.alloc(PageCapacity);
            Allocations = alloc<int>(PageCapacity);
            for(var i=0; i<PageCapacity; i++)
                Allocations[i] = -1;
        }

        [MethodImpl(Inline)]
        MemoryAddress PageAddress(uint index)
            => Memory.PageAddress(index);

        public MemoryAddress AllocPage()
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