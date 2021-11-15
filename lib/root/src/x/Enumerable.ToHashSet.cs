//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection;
    using System.Collections.Generic;

    partial class XTend
    {
        public static HashSet<T> ToHashSet<T>(this IEnumerable<T> src)
            => new HashSet<T>(src);

        public static HashSet<T> ToHashSet<T>(this T[] src)
            => new HashSet<T>(src);
    }
}