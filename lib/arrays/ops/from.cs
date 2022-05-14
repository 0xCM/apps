//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    partial struct Arrays
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T[] from<T>(IEnumerable<T> src)
            => src.ToArray();

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T[] from<T>(params T[] src)
            => src;
    }
}