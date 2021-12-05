//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    partial class XTend
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static void Iter<T>(this Span<T> src, Action<T> f)
            => iter(src,f);
    }
}