//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class StringDispenser : IAllocationDispenser
    {
        public static StringAllocation allocation(ReadOnlySpan<string> src)
        {
            var count = src.Length;
            var total = 0u;
            for(var i=0; i<count; i++)
                total += (uint)skip(src,i).Length;

            var storage = StringBuffers.buffer(total);
            var allocator = new StringAllocator(storage);
            var dst = core.alloc<StringRef>(count);
            for(var i=0; i<count; i++)
                allocator.Alloc(skip(src,i), out seek(dst,i));
            return new StringAllocation(allocator, dst);
        }

        const uint Capacity = PageBlock.PageSize;

        readonly Dictionary<long,StringAllocator> Allocators;

        object locker;

        internal StringDispenser(uint capacity = Capacity)
        {
            Allocators = new();
            locker = new();
            Allocators[Seq] = StringAllocator.alloc(Capacity);
        }

        public StringRef Dispense(@string content)
        {
            var dst = StringRef.Empty;
            lock(locker)
            {
                var alloc = Allocators[Seq];
                if(!alloc.Alloc(content.Value, out dst))
                {
                    alloc = StringAllocator.alloc(Capacity);
                    alloc.Alloc(content.Value, out dst);
                    Allocators[next()] = alloc;
                }
            }
            return dst;
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