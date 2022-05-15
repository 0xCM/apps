//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    using static core;

    partial struct Arrays
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static bool equal<T>(ReadOnlySpan<T> src, ReadOnlySpan<T> dst)
            where T : IEquatable<T>
        {
            var count = src.Length;
            if(count != dst.Length)
                return false;

            if(count == 0)
                return true;

            ref readonly var a = ref core.first(src);
            ref readonly var b = ref core.first(dst);
            for(var i=0; i<count; i++)
                if(!skip(a,i).Equals(skip(b,i)))
                    return false;

            return true;
        }

    }
}