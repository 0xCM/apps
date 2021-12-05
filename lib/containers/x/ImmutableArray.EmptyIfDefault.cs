//-----------------------------------------------------------------------------
// Copyright   :  (c) Microsoft/.NET Foundation
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class XTend
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ImmutableArray<T> EmptyIfDefault<T>(this ImmutableArray<T> array)
            => array.IsDefault ? ImmutableArray<T>.Empty : array;
    }
}