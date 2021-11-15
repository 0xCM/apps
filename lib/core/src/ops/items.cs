// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static Root;

    partial struct core
    {
        [Op, Closures(Closure)]
        public static Index<ListItem<T>> items<T>(ReadOnlySpan<T> src)
        {
            var count = src.Length;
            var buffer = alloc<ListItem<T>>(count);
            ref var dst = ref first(buffer);
            for(var i=0u; i<count; i++)
                seek(dst,i) = (i,skip(src,i));
            return buffer;
        }
    }
}