//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Collections.Generic;

    partial struct sys
    {
        [MethodImpl(Options), Op, Closures(Closure)]
        public static IEnumerator<T> enumerator<T>(IEnumerable<T> src)
            => proxy.enumerator(src);

        [MethodImpl(Options), Op, Closures(Closure)]
        public static bool next<T>(IEnumerator<T> src)
            => proxy.next(src);

        [MethodImpl(Options), Op, Closures(Closure)]
        public static T current<T>(IEnumerator<T> src)
            => proxy.current(src);
    }
}