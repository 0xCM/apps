//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public class AsmDispenser : IDisposable
    {
        public static AsmDispenser create()
            => new AsmDispenser();

        SymbolDispenser Symbols;

        SourceDispenser Sources;

        MemoryDispenser Encodings;

        AsmDispenser()
        {
            Symbols = SymbolDispenser.alloc();
            Sources = SourceDispenser.alloc();
            Encodings = MemoryDispenser.alloc();
        }

        public void Dispose()
        {
            Symbols.Dispose();
            Sources.Dispose();
            Encodings.Dispose();
        }

        public LocatedSymbol Symbol(MemoryAddress location, string name)
            => Symbols.Dispense(location, name);

        public SourceText Source(Identifier name, string src)
            => Sources.Dispense(name,src);

        public MemorySeg Encoding(ByteSize size)
            => Encodings.Dispense(size);
    }
}