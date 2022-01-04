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
        readonly StringBuffer Buffer;

        readonly Index<SourceText> Sources;

        [MethodImpl(Inline)]
        internal SourceAllocation(StringBuffer buffer, SourceText[] sources)
        {
            Buffer = buffer;
            Sources = sources;
        }

        public ReadOnlySpan<SourceText> Allocated
        {
            [MethodImpl(Inline)]
            get => Sources;
        }

        public void Dispose()
        {
            Buffer.Dispose();
        }
    }
}