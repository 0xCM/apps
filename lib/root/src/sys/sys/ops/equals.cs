//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    partial struct sys
    {
        [MethodImpl(Options), Op]
        public static bool equals(object a, object b)
            => proxy.equals(a,b);

        [MethodImpl(Options), Op, Closures(Closure)]
        public static bool equals<T>(T a, T b)
            where T : struct
                => proxy.equals(a,b);

        [MethodImpl(Options), Op]
        public static bool equals(string a, string b)
            => proxy.equals(a,b);

        [MethodImpl(Options), Op]
        public static bool equals(string a, string b, StringComparison options)
            => proxy.equals(a, b, options);
    }
}