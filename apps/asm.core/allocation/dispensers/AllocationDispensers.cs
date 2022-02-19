//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using Asm;

    public class AllocationDispensers : IDisposable
    {
        ConcurrentDictionary<AllocationKind, IAllocationDispenser> Data;

        public LabelDispenser Labels()
            => (LabelDispenser)Data.GetOrAdd(AllocationKind.Label, k => Alloc.labels());

        public MemoryDispenser Mem()
            => (MemoryDispenser)Data.GetOrAdd(AllocationKind.Memory, k => Alloc.mem());

        public PageDispenser Pages()
            => (PageDispenser)Data.GetOrAdd(AllocationKind.Page, k => Alloc.pages());

        public SourceDispenser Sources()
            => (SourceDispenser)Data.GetOrAdd(AllocationKind.Source, k => Alloc.source());

        public StringDispenser Strings()
            => (StringDispenser)Data.GetOrAdd(AllocationKind.String, k => Alloc.strings());

        public SymbolDispenser Symbols()
            => (SymbolDispenser)Data.GetOrAdd(AllocationKind.Symbol, k => Alloc.symbols());

        public AsmCodeDispenser AsmCodes()
            => (AsmCodeDispenser)Data.GetOrAdd(AllocationKind.AsmCode, k => new AsmCodeDispenser(Symbols(), Sources(), Mem(), Labels()));

        public AllocationDispensers()
        {
            Data = new();
        }

        public void Dispose()
        {
            iter(Data.Keys, k => Data[k].Dispose());
        }

        public Label Label(@string content)
            => Labels().Label(content);

        public MemorySeg Memory(ByteSize size)
            => Mem().Memory(size);

        public MemorySeg Page()
            => Pages().Page();

        public SourceText Source(Identifier name, string src)
            => Sources().Source(name,src);

        public SourceText Source(Identifier name, ReadOnlySpan<string> src)
            => Sources().Source(name,src);

        public StringRef String(@string content)
            => Strings().String(content);

        public LocatedSymbol Symbol(MemoryAddress location, @string name)
            => Symbols().Symbol(location,name);

        public LocatedSymbol Symbol(SymAddress location, @string name)
            => Symbols().Symbol(location,name);

        public AsmHexRef AsmEncoding(ByteSize size)
            => AsmCodes().AsmEncoding(size);

        public AsmCode AsmCode(in AsmEncoding src)
            => AsmCodes().AsmCode(src);

        public AsmCode AsmCode(in AsmEncodingRow src)
            => AsmCodes().AsmCode(src);

        public AsmCodeBlock AsmCodeBlock(in AsmBlockEncoding src)
            => AsmCodes().AsmCodeBlock(src);

        public AsmCodeBlocks AsmCodeBlocks(string origin, ReadOnlySpan<AsmBlockEncoding> src)
            => AsmCodes().AsmCodeBlocks(origin,src);
    }
}