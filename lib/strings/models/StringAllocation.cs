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
        readonly StringBuffer Buffer;

        readonly Index<StringRef> _Allocated;

        [MethodImpl(Inline)]
        internal StringAllocation(StringBuffer buffer, StringRef[] allocated)
        {
            Buffer = buffer;
            _Allocated = allocated;
        }

        public ReadOnlySpan<StringRef> Allocated
        {
            [MethodImpl(Inline)]
            get => _Allocated;
        }

        public void Dispose()
        {
            Buffer.Dispose();
        }
    }
}