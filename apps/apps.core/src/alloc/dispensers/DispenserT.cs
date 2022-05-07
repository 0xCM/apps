//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public abstract class Dispenser<T> : IAllocationDispenser
        where T : Dispenser<T>
    {
        public AllocationKind DispensedKind {get;}

        protected static long Seq;

        [MethodImpl(Inline)]
        protected static uint next()
            => (uint)inc(ref Seq);

        public abstract void Dispose();

        protected Dispenser(AllocationKind kind)
        {
            DispensedKind = kind;
        }
    }
}