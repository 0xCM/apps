//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XTend
    {
        public static Index<T> Partition<T>(this Interval<T> src, T width, int? precision = null)
            where T : unmanaged
                => gcalc.partition(src,width,precision);

        public static Index<T> Partition<T>(this Interval<T> src)
            where T : unmanaged
                => gcalc.partition(src);

        public static Index<T> Partition<T>(this ClosedInterval<T> src)
            where T : unmanaged
                => gcalc.partition<T>(src);
    }
}