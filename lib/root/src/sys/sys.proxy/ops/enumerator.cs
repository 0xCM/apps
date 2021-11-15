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

    using static ApiOpaqueClass;

    partial struct proxy
    {
        [MethodImpl(Options), Opaque(GetEnumerator), Closures(Closure)]
        public static IEnumerator<T> enumerator<T>(IEnumerable<T> src)
            => src.GetEnumerator();

        [MethodImpl(Options), Opaque(MoveNext), Closures(Closure)]
        public static bool next<T>(IEnumerator<T> src)
            => src.MoveNext();

        [MethodImpl(Options), Opaque(Current), Closures(Closure)]
        public static T current<T>(IEnumerator<T> src)
            => src.Current;
    }
}