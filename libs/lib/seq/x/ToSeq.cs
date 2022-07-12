//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XTend
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Seq<T> ToSeq<T>(this IEnumerable<T> src)
            => sys.array(src);
    }
}