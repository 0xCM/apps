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
        public static ImmutableArray<TOut> SelectAsArray<TIn, TOut>(this ImmutableArray<TIn> array, Func<TIn, TOut> mapper)
        {
            if (array.IsDefaultOrEmpty)
                return ImmutableArray<TOut>.Empty;

            var builder = ImmutableArray.CreateBuilder<TOut>(array.Length);
            foreach (var e in array)
                builder.Add(mapper(e));

            return builder.MoveToImmutable();
        }
    }
}