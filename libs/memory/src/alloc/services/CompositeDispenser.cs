//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class CompositeDispenser : IAllocDispenser
    {
        SymbolDispenser Symbols;

        SourceDispenser Sources;

        MemDispenser Memory;

        LabelDispenser Labels;

        bool Owner;

        public CompositeDispenser(SymbolDispenser symbols, SourceDispenser source, MemDispenser encodings, LabelDispenser labels)
        {
            Symbols = symbols;
            Sources = source;
            Memory = encodings;
            Labels = labels;
            Owner = false;
        }

        public CompositeDispenser()
        {
            Symbols = Dispense.symbols();
            Sources = Dispense.source();
            Memory = Dispense.mem();
            Labels = Dispense.labels();
            Owner = true;
        }

        public void Dispose()
        {
            if(Owner)
            {
                (Symbols as IDisposable).Dispose();
                (Sources as IDisposable).Dispose();
                (Memory  as IDisposable).Dispose();
                (Labels as IDisposable).Dispose();
            }
        }

        public AllocationKind Kind
            => AllocationKind.Composite;

        public LocatedSymbol Symbol(MemoryAddress location, string name)
            => Symbols.Symbol(location, name);

        public LocatedSymbol Symbol(SymAddress location, string name)
            => Symbols.Symbol(location,name);

        public HexRef Reserve(ByteSize size)
            => Memory.DispenseMemory(size);

        public SourceText Source(string src)
            => Sources.Store(src);

        public Label Label(string content)
            => Labels.Label(content);

        [MethodImpl(Inline)]
        public HexRef Store(ReadOnlySpan<byte> src)
        {
            var size = src.Length;
            var hex = Reserve(size);
            var dst = hex.Edit;
            for(var j=0; j<size; j++)
                seek(dst,j) = skip(src,j);
            return hex;
        }
    }
}