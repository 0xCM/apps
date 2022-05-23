//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class SymbolDispenser : IAllocDispenser
    {
        const uint Capacity = PageBlock.PageSize;

        readonly Dictionary<long,LabelAllocator> Allocators;

        object locker;

        internal SymbolDispenser(uint capacity = Capacity)
        {
            Allocators = new();
            locker = new();
            Allocators[Seq] = LabelAllocator.alloc(Capacity);
        }

        void IDisposable.Dispose()
        {
            core.iter(Allocators.Values, a => a.Dispose());
        }

        public AllocationKind DispensedKind
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

        public LocatedSymbol DispenseSymbol(MemoryAddress location, string name)
            => DispenseSymbol(SymAddress.define(location), name);

        public LocatedSymbol DispenseSymbol(SymAddress location, string name)
            => new LocatedSymbol(location, DispenseLabel(name));

        static long Seq;

        [MethodImpl(Inline)]
        static uint next()
            => (uint)inc(ref Seq);
    }
}