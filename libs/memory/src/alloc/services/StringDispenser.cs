//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class StringDispenser : IAllocDispenser
    {
        const uint Capacity = MemoryPage.PageSize;

        readonly Dictionary<long,StringAllocator> Allocators;

        object locker;

        public StringDispenser(uint capacity = Capacity)
        {
            Allocators = new();
            locker = new();
            Allocators[Seq] = StringAllocator.alloc(Capacity);
        }

        void IDisposable.Dispose()
        {
            core.iter(Allocators.Values, a => a.Dispose());
        }


        public AllocationKind Kind
            => AllocationKind.String;

        public StringRef String(string content)
        {
            var dst = StringRef.Empty;
            lock(locker)
            {
                var alloc = Allocators[Seq];
                if(!alloc.Alloc(content, out dst))
                {
                    alloc = StringAllocator.alloc(Capacity);
                    alloc.Alloc(content, out dst);
                    Allocators[next()] = alloc;
                }
            }
            return dst;
        }


        static long Seq;

        [MethodImpl(Inline)]
        static uint next()
            => (uint)inc(ref Seq);
   }
}