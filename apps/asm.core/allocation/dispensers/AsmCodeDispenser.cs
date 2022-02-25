//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using Asm;

    public class AsmCodeDispenser : IAllocationDispenser
    {
        SymbolDispenser Symbols;

        SourceDispenser Sources;

        MemoryDispenser Encodings;

        LabelDispenser Labels;

        bool Owner;

        internal AsmCodeDispenser(SymbolDispenser symbols, SourceDispenser source, MemoryDispenser encodings, LabelDispenser labels)
        {
            Symbols = symbols;
            Sources = source;
            Encodings = encodings;
            Labels = labels;
            Owner = false;
        }

        internal AsmCodeDispenser()
        {
            Symbols = Alloc.symbols();
            Sources = Alloc.source();
            Encodings = Alloc.mem();
            Labels = Alloc.labels();
            Owner = true;
        }

        public void Dispose()
        {
            if(Owner)
            {
                (Symbols as IDisposable).Dispose();
                (Sources as IDisposable).Dispose();
                (Encodings  as IDisposable).Dispose();
                (Labels as IDisposable).Dispose();
            }
        }

        public AllocationKind DispensedKind
            => AllocationKind.AsmCode;

        public LocatedSymbol DispenseSymbol(MemoryAddress location, string name)
            => Symbols.DispenseSymbol(location, name);

        public SourceText DispenseSource(string src)
            => Sources.DispenseSource(src);

        public AsmHexRef AsmEncoding(ByteSize size)
            => Encodings.DispenseMemory(size);

        [MethodImpl(Inline)]
        public AsmHexRef AsmEncoding(ReadOnlySpan<byte> src)
        {
            var size = src.Length;
            var hex = AsmEncoding(size);
            var dst = hex.Edit;
            for(var j=0; j<size; j++)
                seek(dst,j) = skip(src,j);
            return hex;
        }

        public AsmCode AsmCode(in AsmEncodingRecord src)
        {
            ref readonly var code = ref src.Encoded;
            var size = code.Size;
            var hex = AsmEncoding(size);
            var hexsrc = code.View;
            var hexdst = hex.Edit;
            for(var j=0; j<size; j++)
                seek(hexdst,j) = skip(hexsrc,j);
            return new AsmCode(AsmBytes.encid(src.IP, code), src.Seq, src.DocSeq, src.OriginId, DispenseSource(src.Asm.Format()), src.IP, hex);
        }
    }
}