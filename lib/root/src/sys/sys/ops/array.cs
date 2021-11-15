//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Collections.Generic;

    partial struct sys
    {
        [MethodImpl(Options), Op, Closures(Closure)]
        public static T[] array<T>(params T[] src)
            => proxy.array(src);

        [MethodImpl(Options), Op, Closures(Closure)]
        public static T[] array<T>(Span<T> src)
            => proxy.array(src);

        [MethodImpl(Options), Op, Closures(Closure)]
        public static T[] array<T>(List<T> src)
            => proxy.array(src);

        [MethodImpl(Options), Op, Closures(Closure)]
        public static T[] array<T>(IEnumerable<T> src)
            => proxy.array(src);
    }
}