//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct Hex
    {
        const char Zero = (char)0;

        [MethodImpl(Inline), Op]
        public static bool nonzero(char c0, char c1)
            => c0 != Zero && c1 != Zero;
    }
}