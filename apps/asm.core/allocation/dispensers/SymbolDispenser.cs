//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class SymbolDispenser : IAllocationDispenser
    {
        const uint Capacity = PageBlock.PageSize;

        readonly LocatedSymbols Lookup;

        readonly Dictionary<long,LabelAllocator> Allocators;

        object locker;

        internal SymbolDispenser(uint capacity = Capacity)
        {
            Allocators = new();
            Lookup = new();
            locker = new();
            Allocators[Seq] = LabelAllocator.alloc(Capacity);
        }

        public AllocationKind DispensedKind
            => AllocationKind.Symbol;

        public Label DispenseLabel(@string content)
        {
            var label = Label.Empty;
            lock(locker)
            {
                var allocator = Allocators[Seq];
                if(!allocator.Alloc(content.Value, out label))
                {
                    allocator = LabelAllocator.alloc(Capacity);
                    allocator.Alloc(content.Value, out label);
                    Allocators[next()] = allocator;
                }
            }
            return label;
        }

        public LocatedSymbol Symbol(MemoryAddress location, @string name)
            => Symbol(SymAddress.define(location), name);

        public LocatedSymbol Symbol(SymAddress location, @string name)
        {
            if(Lookup.TryGetValue(location, out var found))
                return found;
            else
            {
                var symbol = CreateSymbol(location, name);
                Lookup[location] = symbol;
                return symbol;
            }
        }

        public uint Count
            => (uint)Lookup.Count;

        public ICollection<LocatedSymbol> Dispensed()
            => Lookup.Values;

        public void Dispensed(Span<LocatedSymbol> dst)
        {
            var i=0;
            var max = dst.Length;
            var dispensed = Dispensed();
            foreach(var symbol in dispensed)
            {
                if(i < max)
                    seek(dst,i++) = symbol;
            }
        }

        public bool Search(SymAddress location, out LocatedSymbol dst)
            => Lookup.TryGetValue(location, out dst);

        void IDisposable.Dispose()
        {
            core.iter(Allocators.Values, a => a.Dispose());
        }

        LocatedSymbol CreateSymbol(SymAddress location, @string name)
            => new LocatedSymbol(location, DispenseLabel(name));

        static long Seq;

        [MethodImpl(Inline)]
        static uint next()
            => (uint)inc(ref Seq);
    }
}