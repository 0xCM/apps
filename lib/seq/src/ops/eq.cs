//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    partial struct seq
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static bool eq<T>(ReadOnlySpan<T> a, ReadOnlySpan<T> b)
            where T : IEquatable<T>
        {
            var count = a.Length;
            if(count != b.Length)
                return false;

            ref readonly var left = ref first(a);
            ref readonly var right = ref first(b);
            for(var i=0u; i<count; i++)
                if(!skip(left, i).Equals(skip(right, i)))
                    return false;
            return true;
        }
    }
}