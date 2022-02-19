//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    public class AsmDispenser : IDisposable
    {
        SymbolDispenser Symbols;

        SourceDispenser Sources;

        MemoryDispenser Encodings;

        LabelDispenser Labels;

        internal AsmDispenser()
        {
            Symbols = Alloc.symbols();
            Sources = Alloc.source();
            Encodings = Alloc.mem();
            Labels = Alloc.labels();
        }

        public void Dispose()
        {
            (Symbols as IDisposable).Dispose();
            Sources.Dispose();
            Encodings.Dispose();
        }

        public LocatedSymbol Symbol(MemoryAddress location, string name)
            => Symbols.Dispense(location, name);

        public SourceText Source(Identifier name, string src)
            => Sources.Dispense(name,src);

        public AsmHexRef Encoding(ByteSize size)
            => Encodings.Dispense(size);

        public AsmCode AsmCode(in AsmEncoding src)
        {
            ref readonly var code = ref src.Encoded;
            var size = code.Size;
            var hex = Encoding(size);
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
            var hex = Encoding(size);
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
            return new AsmCodeBlocks(Labels.Dispense(origin), dst);
        }
    }
}