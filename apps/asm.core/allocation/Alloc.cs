//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    public readonly struct Alloc
    {
        public static LabelDispenser labels(ByteSize capacity)
            => new LabelDispenser(capacity);

        public static LabelDispenser labels()
            => new LabelDispenser();

        public static AsmCodeDispenser asm()
            => new AsmCodeDispenser();

        public static MemoryDispenser mem(ByteSize capacity)
            => new MemoryDispenser(capacity);

        public static MemoryDispenser mem()
            => new MemoryDispenser();

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

        public static AllocationDispensers dispensers()
            => new AllocationDispensers();
    }
}