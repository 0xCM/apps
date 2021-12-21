//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class BitVectors
    {
        [MethodImpl(Inline)]
        public static BitVector128<T> broadcast<T>(W128 w, T src)
            where T : unmanaged
                => gcpu.vbroadcast(w,src);
    }
}