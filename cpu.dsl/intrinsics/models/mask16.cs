//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Vdsl
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct Intrinsics
    {
        public struct mmask16
        {
            ushort Data;

            [MethodImpl(Inline)]
            public mmask16(ushort src)
                => Data = src;

            [MethodImpl(Inline)]
            public static implicit operator mmask16(ushort src)
                => new mmask16(src);

            [MethodImpl(Inline)]
            public static implicit operator ushort(mmask16 src)
                => src.Data;
        }
    }
}