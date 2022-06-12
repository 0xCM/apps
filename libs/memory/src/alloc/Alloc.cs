//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class Alloc : IDisposable, IStringAllocProvider
    {
        public static Alloc create()
            => new Alloc();

        public static CompositeDispenser asm()
            => new CompositeDispenser();

        ConcurrentDictionary<AllocationKind,IAllocDispenser> Data;

        public LabelDispenser Labels()
            => (LabelDispenser)Data.GetOrAdd(AllocationKind.Label, k => Dispense.labels());

        public MemDispenser Mem()
            => (MemDispenser)Data.GetOrAdd(AllocationKind.Memory, k => Dispense.mem());

        public PageDispenser Pages()
            => (PageDispenser)Data.GetOrAdd(AllocationKind.Page, k => Dispense.pages());

        public SourceDispenser Sources()
            => (SourceDispenser)Data.GetOrAdd(AllocationKind.Source, k => Dispense.source());

        public StringDispenser Strings()
            => (StringDispenser)Data.GetOrAdd(AllocationKind.String, k => Dispense.strings());

        public SymbolDispenser Symbols()
            => (SymbolDispenser)Data.GetOrAdd(AllocationKind.Symbol, k => Dispense.symbols());

        public CompositeDispenser Composite()
            => (CompositeDispenser)Data.GetOrAdd(AllocationKind.Composite, k => new CompositeDispenser(Symbols(), Sources(), Mem(), Labels()));

        public NativeSigDispenser Sigs()
            =>(NativeSigDispenser)Data.GetOrAdd(AllocationKind.NativeSig, k => new NativeSigDispenser(Mem(), Strings(), Labels()));

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

        public NativeSig Sig(string scope, string name, NativeType ret, params NativeOpDef[] ops)
            => Sigs().Sig(scope, name,ret,ops);

        public NativeSig Sig(NativeSigSpec spec)
            => Sigs().Sig(spec);

        public StringRef String(string content)
            => Strings().String(content);
    }
}