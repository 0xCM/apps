//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class SymbolDispenser : IAllocationDispenser
    {
        public static SymbolDispenser alloc(ByteSize capacity)
            => new SymbolDispenser(capacity);

        public static SymbolDispenser alloc()
            => new SymbolDispenser();

        const uint Capacity = PageBlock.PageSize;

        readonly ConcurrentDictionary<string,LocatedSymbol> NameLookup;

        readonly ConcurrentDictionary<MemoryAddress,LocatedSymbol> AddressLookup;

        readonly Dictionary<long,LabelAllocator> Allocators;

        object locker;

        SymbolDispenser(uint capacity = Capacity)
        {
            NameLookup = new();
            Allocators = new();
            AddressLookup = new();
            locker = new();
            Allocators[Seq] = LabelAllocator.alloc(Capacity);
        }

        public LocatedSymbol Dispense(MemoryAddress location, @string name)
        {
            var symbol = CreateSymbol(location,name);
            NameLookup[name] = symbol;
            AddressLookup[location] = symbol;
            return symbol;
        }

        public LocatedSymbol this[@string name]
        {
            get
            {
                if(Search(name, out var symbol))
                    return symbol;
                else
                    return LocatedSymbol.Empty;
            }
        }

        public LocatedSymbol this[MemoryAddress name]
        {
            get
            {
                if(Search(name, out var symbol))
                    return symbol;
                else
                    return LocatedSymbol.Empty;
            }
        }

        public LocatedSymbol Relocate(LocatedSymbol src, MemoryAddress dst)
        {
            var name = src.Name.Format();
            if(AddressLookup.Remove(src.Location, out var removed) && NameLookup.Remove(name, out _))
            {
                var symbol = new LocatedSymbol(dst, src.Name);
                NameLookup.TryAdd(name, symbol);
                AddressLookup.TryAdd(dst,symbol);
                return symbol;
            }
            return src;
        }

        public bool Search(MemoryAddress location, out LocatedSymbol dst)
            => AddressLookup.TryGetValue(location, out dst);

        public bool Search(@string name, out LocatedSymbol dst)
            => NameLookup.TryGetValue(name, out dst);

        public bool Locate(@string name, out MemoryAddress location)
        {
            if(NameLookup.TryGetValue(name, out var symbol))
            {
                location = symbol.Location;
                return true;
            }
            else
            {
                location = MemoryAddress.Zero;
                return false;
            }
        }

        void IDisposable.Dispose()
        {
            core.iter(Allocators.Values, a => a.Dispose());
        }

        Label Allocate(@string content)
        {
            var label = Label.Empty;
            lock(locker)
            {
                var allocator = Allocators[Seq];
                if(!allocator.Allocate(content.Value, out label))
                {
                    allocator = LabelAllocator.alloc(Capacity);
                    allocator.Allocate(content.Value, out label);
                    Allocators[next()] = allocator;
                }
            }
            return label;
        }

        LocatedSymbol CreateSymbol(MemoryAddress location, @string name)
            => new LocatedSymbol(location, Allocate(name));

        static long Seq;

        [MethodImpl(Inline)]
        static uint next()
            => (uint)inc(ref Seq);
    }
}