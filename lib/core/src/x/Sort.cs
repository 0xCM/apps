//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    partial class XTend
    {
        public static IEnumerable<T> Sort<T>(this IEnumerable<T> src)
            where T : IComparable<T>
                => src.OrderBy(x => x);

        public static T[] Sort<T>(this T[] src)
            where T : IComparable<T>
        {
            System.Array.Sort(src);
            return src;
        }

        public static T[] Sort<T,C>(this T[] src, C comparer)
            where C : IComparer<T>
        {
            System.Array.Sort(src,comparer);
            return src;
        }

        public static Index<T> Sort<T,C>(this Index<T> src, C comparer)
            where C : IComparer<T>
        {
            System.Array.Sort(src,comparer);
            return src;
        }
    }
}