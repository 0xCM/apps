//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    partial class XTend
    {
        public static Span<T> Increments<T>(this Interval<T> src)
            where T : unmanaged
                => gcalc.increments(src.ToClosed());
    }
}