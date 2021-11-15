//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct Math128
    {
        [MethodImpl(Inline), Dec]
        public static ref uint128 dec(ref uint128 x)
        {
            sub(ref x, (1ul,0ul));
            return ref x;
        }
    }
}