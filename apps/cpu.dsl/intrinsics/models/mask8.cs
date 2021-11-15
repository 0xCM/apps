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
        public struct mask8
        {
            byte Data;

            [MethodImpl(Inline)]
            public mask8(byte src)
                => Data = src;

            [MethodImpl(Inline)]
            public static implicit operator mask8(byte src)
                => new mask8(src);

            [MethodImpl(Inline)]
            public static implicit operator byte(mask8 src)
                => src.Data;
        }
    }
}