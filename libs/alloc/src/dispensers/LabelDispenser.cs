//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class LabelDispenser : IAllocDispenser
    {
        const uint Capacity = MemoryPage.PageSize;

        readonly Dictionary<long,LabelAllocator> Allocators;

        object locker;

        internal LabelDispenser(uint capacity = Capacity)
        {
            Allocators = new();
            locker = new();
            Allocators[Seq] = LabelAllocator.alloc(Capacity);
        }

        public AllocationKind DispensedKind
            => AllocationKind.Label;

        public Label Label(string content)
        {
            var label = Z0.Label.Empty;
            lock(locker)
            {
                var alloc = Allocators[Seq];
                if(!alloc.Alloc(content, out label))
                {
                    alloc = LabelAllocator.alloc(Capacity);
                    alloc.Alloc(content, out label);
                    Allocators[next()] = alloc;
                }
            }
            return label;
        }


        void IDisposable.Dispose()
            => core.iter(Allocators.Values, a => a.Dispose());

        static long Seq;

        [MethodImpl(Inline)]
        static uint next()
            => (uint)inc(ref Seq);
    }
}