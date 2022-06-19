//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Collections.Generic;
    using System.Linq;

    using static ApiOpaqueClass;

    partial struct proxy
    {
        [MethodImpl(Options), Opaque(ParameterArray), Closures(Closure)]
        public static T[] array<T>(params T[] src)
            => src;

        [MethodImpl(Options), Opaque(SpanToArray), Closures(Closure)]
        public static T[] array<T>(Span<T> src)
            => src.ToArray();

        [MethodImpl(Options), Opaque(ListToArray), Closures(Closure)]
        public static T[] array<T>(List<T> src)
            => src.ToArray();

        [MethodImpl(Options), Opaque(EnumerableToArray), Closures(Closure)]
        public static T[] array<T>(IEnumerable<T> src)
            => src.ToArray();
    }
}