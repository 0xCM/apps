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
        public static T[] create<T>(IEnumerable<T> src)
            => array(src);
    }
}