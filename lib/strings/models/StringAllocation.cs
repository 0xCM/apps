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

    public class StringAllocation : IDisposable
    {
        readonly IStringAllocator Allocator;

        readonly Index<StringRef> _Allocated;

        [MethodImpl(Inline)]
        internal StringAllocation(IStringAllocator allocator, StringRef[] allocated)
        {
            Allocator = allocator;
            _Allocated = allocated;
        }

        public ReadOnlySpan<StringRef> Allocated
        {
            [MethodImpl(Inline)]
            get => _Allocated;
        }

        public void Dispose()
        {
            Allocator.Dispose();
        }
    }
}