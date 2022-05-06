//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class XTend
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static void Iter<T>(this Span<T> src, Action<T> f)
            => iter(src,f);
    }
}