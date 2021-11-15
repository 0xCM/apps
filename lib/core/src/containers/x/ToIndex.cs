//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Collections.Concurrent;

    using static Root;

    partial class XTend
    {
        public static Index<T> ToIndex<T>(this ConcurrentBag<T> src)
            => src.ToArray();
    }
}