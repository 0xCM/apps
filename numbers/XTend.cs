//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------

namespace Z0
{
    [ApiHost]
    public static partial class XTend
    {
        const NumericKind Closure = Root.UnsignedInts;


        public static void AddRange<T>(this HashSet<T> dst, HashSet<T> src)
        {
            foreach(var item in src)
                dst.Add(item);
        }

        public static void AddRange<T>(this ConcurrentBag<T> dst, HashSet<T> src)
        {
            foreach(var item in src)
                dst.Add(item);
        }
    }
}