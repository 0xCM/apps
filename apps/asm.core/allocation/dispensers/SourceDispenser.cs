//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class SourceDispenser : IAllocationDispenser
    {
        public static SourceAllocation allocation(ReadOnlySpan<string> src)
        {
            var count = src.Length;
            var total = 0u;
            for(var i=0u; i<count; i++)
                total += (uint)skip(src,i).Length;

            var buffer  = StringBuffers.buffer(total);
            var alloc = SourceAllocator.from(buffer);
            var dst = core.alloc<SourceText>(count);
            for(var i=0; i<count; i++)
                alloc.Alloc(skip(src,i), out seek(dst,i));

            return new SourceAllocation(alloc, dst);
        }

        const uint Capacity = PageBlock.PageSize*8;

        readonly Dictionary<long,SourceAllocator> Allocators;

        object locker;

        internal SourceDispenser(uint capacity = Capacity)
        {
            locker = new();
            Allocators = new();
            Allocators[Seq] = SourceAllocator.alloc(Capacity);
        }

        public void Dispose()
        {
            core.iter(Allocators.Values, a => a.Dispose());
        }

        public AllocationKind DispensedKind
            => AllocationKind.Source;

        public SourceText DispenseSource(@string src)
        {
            var dst = SourceText.Empty;
            lock(locker)
            {
                var alloc = Allocators[Seq];
                if(!alloc.Alloc(src.Value, out dst))
                {
                    alloc = SourceAllocator.alloc(Capacity);
                    alloc.Alloc(src.Value, out dst);
                    Allocators[next()] = alloc;
                }
            }
            return dst;
        }

        public SourceText Source(ReadOnlySpan<string> src)
        {
            var dst = text.buffer();
            iter(src, x => dst.AppendLine(x));
            return DispenseSource(dst.Emit());
        }

        static long Seq;

        [MethodImpl(Inline)]
        static uint next()
            => (uint)inc(ref Seq);
   }
}