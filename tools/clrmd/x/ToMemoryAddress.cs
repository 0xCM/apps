//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;
    using Microsoft.Diagnostics.Runtime.DacInterface;

    using static Root;

    partial class XTend
    {
        [MethodImpl(Inline)]
        public static MemoryAddress ToMemoryAddress(this ClrDataAddress src)
            => (ulong)src;
    }
}