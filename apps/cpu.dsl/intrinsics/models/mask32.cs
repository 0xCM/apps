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
        public struct mask32
        {
            ushort Data;

            [MethodImpl(Inline)]
            public mask32(ushort src)
                => Data = src;

            [MethodImpl(Inline)]
            public static implicit operator mask32(ushort src)
                => new mask32(src);

            [MethodImpl(Inline)]
            public static implicit operator ushort(mask32 src)
                => src.Data;
        }
    }
}