//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.Intrinsics;

    using static Root;

    /// <summary>
    /// Defines a 32-symbol permutation
    /// </summary>
    public readonly struct Perm32
    {
        public readonly Vector256<byte> Data;

        [MethodImpl(Inline)]
        public Perm32(Vector256<byte> src)
            => Data = src;
    }
}