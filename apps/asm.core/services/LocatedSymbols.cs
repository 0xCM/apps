//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class LocatedSymbols : IDisposable
    {
        public static LocatedSymbols alloc(ByteSize capacity)
            => new LocatedSymbols(capacity);

        public static LocatedSymbols alloc()
            => new LocatedSymbols();

        const uint Capacity = PageBlock.PageSize;

        readonly ConcurrentDictionary<string,LocatedSymbol> NameLookup;

        readonly ConcurrentDictionary<MemoryAddress,LocatedSymbol> AddressLookup;

        readonly Dictionary<long,LabelAllocator> Allocators;

        object locker;

        LocatedSymbols(uint capacity = Capacity)
        {
            NameLookup = new();
            Allocators = new();
            AddressLookup = new();
            locker = new();
            Allocators[Seq] = LabelAllocator.alloc(Capacity);
        }

        public LocatedSymbol Add(MemoryAddress location, @string name)
        {
            var symbol = CreateSymbol(name,location);
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
                var symbol = new LocatedSymbol(src.Name, dst);
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

        public void Dispose()
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

        LocatedSymbol CreateSymbol(@string name, MemoryAddress location)
            => new LocatedSymbol(Allocate(name), location);

        static long Seq;

        [MethodImpl(Inline)]
        static uint next()
            => (uint)inc(ref Seq);
    }
}