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

    public class SourceAllocation : IDisposable
    {
        readonly IStringAllocator Allocator;

        readonly Index<SourceText> Sources;

        [MethodImpl(Inline)]
        internal SourceAllocation(IStringAllocator allocator, SourceText[] sources)
        {
            Allocator = allocator;
            Sources = sources;
        }

        public ReadOnlySpan<SourceText> Allocated
        {
            [MethodImpl(Inline)]
            get => Sources;
        }

        public void Dispose()
        {
            Allocator.Dispose();
        }
    }
}