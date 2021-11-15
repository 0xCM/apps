//-----------------------------------------------------------------------------
// Copyright   :  (c) Microsoft/.NET Foundation
// License     :  MIT
// Source      : https://github.com/dotnet/runtime/src/libraries/System.Reflection.Metadata
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class SRM
    {
        unsafe partial struct MemoryBlock
        {
            // When reference has tag bits.
            [MethodImpl(Inline), Op]
            public uint PeekTaggedReference(int offset, bool smallRefSize)
                => PeekReferenceUnchecked(offset, smallRefSize);
        }
    }
}