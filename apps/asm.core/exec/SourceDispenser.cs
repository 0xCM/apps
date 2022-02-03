//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class SourceDispenser : IAllocationDispenser
    {
        public static SourceDispenser alloc(ByteSize capacity)
            => new SourceDispenser(capacity);

        public static SourceDispenser alloc()
            => new SourceDispenser();

       static long Seq;

        [MethodImpl(Inline)]
        static uint next()
            => (uint)inc(ref Seq);

        const uint Capacity = PageBlock.PageSize*8;

        readonly Dictionary<long,SourceAllocator> Allocators;

        readonly ConcurrentDictionary<Identifier,SourceText> Allocated;

        object locker;

        SourceDispenser(uint capacity = Capacity)
        {
            locker = new();
            Allocated = new();
            Allocators = new();
            Allocators[Seq] = SourceAllocator.alloc(Capacity);
        }

        public void Dispose()
        {
            core.iter(Allocators.Values, a => a.Dispose());
        }

        SourceText Allocate(@string content)
        {
            var dst = SourceText.Empty;
            lock(locker)
            {
                var allocator = Allocators[Seq];
                if(!allocator.Allocate(content.Value, out dst))
                {
                    allocator = SourceAllocator.alloc(Capacity);
                    allocator.Allocate(content.Value, out dst);
                    Allocators[next()] = allocator;
                }
            }
            return dst;
        }

        public SourceText Dispense(Identifier name, string src)
        {
            var dst = Allocate(src);
            Allocated[name] = dst;
            return dst;
        }

        public SourceText Dispense(Identifier name, ReadOnlySpan<string> src)
        {
            var dst = text.buffer();
            iter(src, x => dst.AppendLine(x));
            return Dispense(name, dst.Emit());
        }
    }
}