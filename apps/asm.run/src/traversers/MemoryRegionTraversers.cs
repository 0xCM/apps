//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using Windows;

    using static Root;
    using static core;

    [ApiHost]
    public readonly struct MemoryRegionTraversers
    {
        [Op, MethodImpl(Inline)]
        public static MemoryRegionTraverser create(ReadOnlySpan<ProcessMemoryRegion> src, bool live)
            => new MemoryRegionTraverser(src, live);

        [Op, MethodImpl(Inline)]
        public static unsafe ByteSize run(MemoryRegionTraverser traverser, delegate* unmanaged<in ProcessMemoryRegion,void> dst)
            => traverser.Traverse(dst);

        [Op]
        public static unsafe Index<ProcessMemoryRegion> filter(ReadOnlySpan<ProcessMemoryRegion> src, PageProtection protect)
        {
            var dst  = alloc<ProcessMemoryRegion>((uint)src.Length);
            var traverser = create(src,false);
            var filter = new MemoryRegionFilter(dst,protect);
            var size = traverser.Traverse(filter);
            return filter.Emit();
        }

        unsafe struct MemoryRegionFilter : IReceiver<ProcessMemoryRegion>
        {
            readonly Index<ProcessMemoryRegion> Accepted;

            readonly PageProtection Protection;

            uint Position;

            [MethodImpl(Inline)]
            public MemoryRegionFilter(Index<ProcessMemoryRegion> dst, PageProtection protection)
            {
                Accepted = dst;
                Protection = protection;
                Position = 0;
            }

            [MethodImpl(Inline)]
            public void Deposit(in ProcessMemoryRegion src)
            {
                if((src.Protection & Protection) != 0)
                {
                    Accepted[Position++] = src;
                }
            }

            public Index<ProcessMemoryRegion> Emit()
                => Accepted;
        }
    }
}