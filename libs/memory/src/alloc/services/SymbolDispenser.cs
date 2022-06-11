//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class SymbolDispenser : IAllocDispenser
    {
        const uint Capacity = MemoryPage.PageSize;

        readonly Dictionary<long,LabelAllocator> Allocators;

        object locker;

        public SymbolDispenser(uint capacity = Capacity)
        {
            Allocators = new();
            locker = new();
            Allocators[Seq] = LabelAllocator.alloc(Capacity);
        }

        void IDisposable.Dispose()
        {
            core.iter(Allocators.Values, a => a.Dispose());
        }

        public AllocationKind Kind
            => AllocationKind.Symbol;

        Label DispenseLabel(string content)
        {
            var label = Label.Empty;
            lock(locker)
            {
                var allocator = Allocators[Seq];
                if(!allocator.Alloc(content, out label))
                {
                    allocator = LabelAllocator.alloc(Capacity);
                    allocator.Alloc(content, out label);
                    Allocators[next()] = allocator;
                }
            }
            return label;
        }

        public LocatedSymbol Symbol(MemoryAddress location, string name)
            => Symbol(new SymAddress(0,location), name);

        public LocatedSymbol Symbol(SymAddress location, string name)
            => new LocatedSymbol(location, DispenseLabel(name));

        static long Seq;

        [MethodImpl(Inline)]
        static uint next()
            => (uint)inc(ref Seq);
    }
}