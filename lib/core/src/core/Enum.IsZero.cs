//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    partial class XTend
    {
        [MethodImpl(Inline)]
        public static bool IsZero<T>(this T src)
            where T : unmanaged, Enum
                => bw64(src) == 0;

        [MethodImpl(Inline)]
        public static bool IsNonZero<T>(this T src)
            where T : unmanaged, Enum
                => bw64(src) != 0;
    }
}