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

        public LocatedSymbol Symbol(MemoryAddress location, string name)
            => Symbols.Symbol(location, name);

        public SourceText Source(Identifier name, string src)
            => Sources.Source(name,src);

        public AsmHexRef AsmEncoding(ByteSize size)
            => Encodings.Memory(size);

        public AsmCode AsmCode(in AsmEncoding src)
        {
            ref readonly var code = ref src.Encoded;
            var size = code.Size;
            var hex = AsmEncoding(size);
            var hexsrc = code.View;
            var hexdst = hex.Edit;
            for(var j=0; j<size; j++)
                seek(hexdst,j) = skip(hexsrc,j);
            return new AsmCode(Source(src.Id.Format(), src.Asm.Format()), src.IP, hex);
        }

        public AsmCode AsmCode(in AsmEncodingRow src)
        {
            ref readonly var code = ref src.Encoded;
            var size = code.Size;
            var hex = AsmEncoding(size);
            var hexsrc = code.Bytes;
            var hexdst = hex.Edit;
            for(var j=0; j<size; j++)
                seek(hexdst,j) = skip(hexsrc,j);
            return new AsmCode(Source(src.Id.Format(), src.Asm.Format()), src.IP, hex);
        }

        public AsmCodeBlock AsmCodeBlock(in AsmBlockEncoding src)
        {
            var encodings = src.Encoded;
            var count = encodings.Count;
            var code = alloc<AsmCode>(count);
            for(var i=0; i<count; i++)
                seek(code,i) = AsmCode(encodings[i]);
            return new AsmCodeBlock(Symbol(src.BlockAddress, src.BlockName), code);
        }

        public AsmCodeBlocks AsmCodeBlocks(string origin, ReadOnlySpan<AsmBlockEncoding> src)
        {
            var dst = alloc<AsmCodeBlock>(src.Length);
            for(var i=0; i<src.Length; i++)
                seek(dst,i) = AsmCodeBlock(skip(src,i));
            return new AsmCodeBlocks(Labels.Label(origin), dst);
        }
    }
}