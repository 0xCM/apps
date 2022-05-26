//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class Hashed
    {
        public static uint hash<S,T>(Index<S> src, Func<S,T> hash, Index<T> dst)
        {
            var accumulator = hashset<T>();
            var count = src.Count;
            var view = src.View;
            dst = alloc<T>(count);
            for(var i=0; i<count; i++)
            {
                dst[i] = hash(src[i]);
                accumulator.Add(dst[i]);
            }
            return count - (uint)accumulator.Count;
        }
    }
}