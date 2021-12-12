//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Collections.Generic;

    partial class XTend
    {
        public static IEnumerable<T> PartitionPoints<T>(this Interval<T> src, T width, int? precision = null)
            where T : unmanaged
                => gcalc.partition(src,width,precision);
    }
}