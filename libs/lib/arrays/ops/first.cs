//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct Arrays
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static bool first<T>(T[] src, Func<T,bool> f, out T found)
        {
            var count = src.Length;
            var result = false;
            found = default;
            for(var i=0; i<count; i++)
            {
                ref readonly var candidate = ref skip(src,i);
                if(f(candidate))
                {
                    found = candidate;
                    result = true;
                    break;
                }
            }
            return result;
        }
    }
}