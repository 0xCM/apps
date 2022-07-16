//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    partial class XTend
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Seq<T> ToSeq<T>(this IEnumerable<T> src)
            => sys.array(src);

        public static Seq<T> SelectMany<S,T>(this Seq<S> source, Func<S,IEnumerable<T>> selector)
            => Enumerable.SelectMany(source,selector).ToArray();

        public static ReadOnlySeq<T> SelectMany<S,T>(this ReadOnlySeq<S> source, Func<S,IEnumerable<T>> selector)
            => Enumerable.SelectMany(source,selector).ToArray();
    }
}