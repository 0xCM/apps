//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;

    public class Alloc : IDisposable, IAllocProvider
    {
        public static Alloc allocate()
            => new Alloc();

        public static LabelAllocation labels(ReadOnlySpan<string> src)
        {
            var count = src.Length;
            var total = 0u;
            for(var i=0; i<count; i++)
                total += (uint)skip(src,i).Length;
            var alloc = LabelAllocator.cover(StringBuffers.buffer(total));
            var labels = core.alloc<Label>(count);
            for(var i=0; i<count; i++)
                alloc.Alloc(skip(src,i), out seek(labels,i));
            return new LabelAllocation(alloc, labels);
        }

        public static SourceAllocation source(ReadOnlySpan<string> src)
        {
            var count = src.Length;
            var total = 0u;
            for(var i=0u; i<count; i++)
                total += (uint)skip(src,i).Length;

            var buffer  = StringBuffers.buffer(total);
            var alloc = SourceAllocator.from(buffer);
            var dst = core.alloc<SourceText>(count);
            for(var i=0; i<count; i++)
                alloc.Alloc(skip(src,i), out seek(dst,i));
            return new SourceAllocation(alloc, dst);
        }

        public static StringAllocation strings(ReadOnlySpan<string> src)
        {
            var count = src.Length;
            var total = 0u;
            for(var i=0; i<count; i++)
                total += (uint)skip(src,i).Length;
            var storage = StringBuffers.buffer(total);
            var allocator = StringAllocator.cover(storage);
            var dst = core.alloc<StringRef>(count);
            for(var i=0; i<count; i++)
                allocator.Alloc(skip(src,i), out seek(dst,i));
            return new StringAllocation(allocator, dst);
        }

        public static LabelDispenser labels(ByteSize capacity)
            => new LabelDispenser(capacity);

        public static LabelDispenser labels()
            => new LabelDispenser();

        public static AsmCodeDispenser asm()
            => new AsmCodeDispenser();

        public static MemDispenser mem(ByteSize capacity)
            => new MemDispenser(capacity);

        public static MemDispenser mem()
            => new MemDispenser();

        public static SourceDispenser source(ByteSize capacity)
            => new SourceDispenser(capacity);

        public static SourceDispenser source()
            => new SourceDispenser();

        public static SymbolDispenser symbols(ByteSize capacity)
            => new SymbolDispenser(capacity);

        public static SymbolDispenser symbols()
            => new SymbolDispenser();

        public static StringDispenser strings()
            => new StringDispenser();

        public static StringDispenser strings(ByteSize capacity)
            => new StringDispenser(capacity);

        public static PageDispenser pages()
            => new PageDispenser();

        public static PageDispenser pages(uint count)
            => new PageDispenser(count);

        ConcurrentDictionary<AllocationKind, IAllocDispenser> Data;

        public LabelDispenser Labels()
            => (LabelDispenser)Data.GetOrAdd(AllocationKind.Label, k => Alloc.labels());

        public MemDispenser Mem()
            => (MemDispenser)Data.GetOrAdd(AllocationKind.Memory, k => Alloc.mem());

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

        public NativeSigDispenser Sigs()
            =>(NativeSigDispenser)Data.GetOrAdd(AllocationKind.Sig, k => new NativeSigDispenser(Mem(), Strings(), Labels()));

        public Alloc()
        {
            Data = new();
        }

        public void Dispose()
        {
            iter(Data.Keys, k => Data[k].Dispose());
        }

        public Label Label(string content)
            => Labels().Label(content);

        public MemorySeg MemAlloc(ByteSize size)
            => Mem().DispenseMemory(size);

        public MemorySeg Page()
            => Pages().Page();

        public SourceText Source(string src)
            => Sources().DispenseSource(src);

        public NativeSig Sig(string scope, string name, NativeType ret, params NativeOpDef[] ops)
            => Sigs().Sig(scope, name,ret,ops);

        public NativeSig Sig(NativeSigSpec spec)
            => Sigs().Sig(spec);

        public SourceText Source(Identifier name, ReadOnlySpan<string> src)
            => Sources().Source(src);

        public StringRef String(string content)
            => Strings().String(content);

        public LocatedSymbol Symbol(MemoryAddress location, string name)
            => Symbols().DispenseSymbol(location,name);

        public LocatedSymbol Symbol(SymAddress location, string name)
            => Symbols().DispenseSymbol(location,name);

        public AsmHexRef AsmEncoding(ByteSize size)
            => AsmCodes().AsmEncoding(size);

        [MethodImpl(Inline)]
        public AsmHexRef AsmEncoding(ReadOnlySpan<byte> src)
            => AsmCodes().AsmEncoding(src);

        public AsmCode AsmCode(in AsmEncodingInfo src)
            => AsmCodes().AsmCode(src);
    }
}