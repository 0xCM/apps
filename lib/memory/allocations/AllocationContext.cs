//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    using static core;

    public abstract class AllocationContext<C> : IDisposable
        where C : IBufferAllocation
    {
        protected C Allocation {get;}

        public void Dispose()
            => Allocation.Dispose();

        protected AllocationContext(C allocation)
        {
            Allocation = allocation;
        }
    }

    public sealed class LiteralAllocation<T> : AllocationContext<LabelBuffer>
    {
        readonly Index<Literal<T>> _Literals;

        internal LiteralAllocation(LabelBuffer labels, Index<Literal<T>> literals)
            : base(labels)
        {
            _Literals = literals;
        }

        public ReadOnlySpan<Literal<T>> Literals
        {
            [MethodImpl(Inline)]
            get => _Literals;
        }
    }
}