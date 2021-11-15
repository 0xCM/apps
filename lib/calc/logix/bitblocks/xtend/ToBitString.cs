//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class XBitBlocks
    {
        [MethodImpl(Inline)]
        public static BitString ToBitString<N,T>(this BitBlock<N,T> src)
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => BitStrings.scalars(src.Data, (int)src.Width);
    }
}