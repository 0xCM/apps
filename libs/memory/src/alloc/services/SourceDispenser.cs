//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class SourceDispenser : IAllocDispenser
    {
        const uint Capacity = MemoryPage.PageSize*8;

        readonly Dictionary<long,SourceAllocator> Allocators;

        object locker;

        public SourceDispenser(uint capacity = Capacity)
        {
            locker = new();
            Allocators = new();
            Allocators[Seq] = SourceAllocator.alloc(Capacity);
        }

        public void Dispose()
        {
            core.iter(Allocators.Values, a => a.Dispose());
        }

        public AllocationKind Kind
            => AllocationKind.Source;

        public SourceText Store(string src)
        {
            var dst = SourceText.Empty;
            lock(locker)
            {
                var alloc = Allocators[Seq];
                if(!alloc.Alloc(src, out dst))
                {
                    alloc = SourceAllocator.alloc(Capacity);
                    alloc.Alloc(src, out dst);
                    Allocators[next()] = alloc;
                }
            }
            return dst;
        }

        public SourceText Store(ReadOnlySpan<string> src)
        {
            var dst = text.buffer();
            iter(src, x => dst.AppendLine(x));
            return Store(dst.Emit());
        }

        static long Seq;

        [MethodImpl(Inline)]
        static uint next()
            => (uint)inc(ref Seq);
   }
}