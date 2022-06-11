//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class Dispense
    {
        public static D dispenser<D>(Func<D> f)
            where D : IAllocDispenser
        {
            var dispensed = f();
            Dispensed.TryAdd(inc(ref Seq), dispensed);
            return dispensed;
        }

        public static LabelDispenser labels(ByteSize capacity)
            => new LabelDispenser(capacity);

        public static LabelDispenser labels()
            => new LabelDispenser();

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

        static ConcurrentDictionary<uint,IAllocDispenser> Dispensed = new();

        static uint Seq;
    }
}