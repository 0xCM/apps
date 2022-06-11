//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public abstract class Dispenser<T> : IAllocDispenser
        where T : Dispenser<T>
    {
        public AllocationKind Kind {get;}

        protected static long Seq;

        [MethodImpl(Inline)]
        protected static uint next()
            => (uint)inc(ref Seq);

        public abstract void Dispose();

        protected Dispenser(AllocationKind kind)
        {
            Kind = kind;
        }
    }
}