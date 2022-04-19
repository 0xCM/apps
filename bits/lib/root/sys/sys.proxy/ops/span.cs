//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Linq;
    using System.Collections.Generic;

    using static ApiOpaqueClass;

    partial struct proxy
    {
        [MethodImpl(Options), Opaque(AllocSpan), Closures(Closure)]
        public static Span<T> span<T>(int count)
            => new T[count];

        [MethodImpl(Options), Opaque(AllocSpan), Closures(Closure)]
        public static Span<T> span<T>(long count)
            => new T[count];

        [MethodImpl(Options), Opaque(AllocSpan), Closures(Closure)]
        public static Span<T> span<T>(ulong count)
            => new T[count];

        [MethodImpl(Options), Opaque(AllocSpan), Closures(Closure)]
        public static Span<T> span<T>(uint count)
            => new T[count];

        [MethodImpl(Options), Opaque(EnumerableToSpan), Closures(Closure)]
        public static Span<T> span<T>(IEnumerable<T> src)
            => src.ToArray();
    }
}