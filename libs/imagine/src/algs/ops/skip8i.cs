//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Algs
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly sbyte skip8i<T>(in T src, long count)
            => ref add(@as<T,sbyte>(edit(src)), (int)count);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly sbyte skip8i<T>(in T src, ulong count)
            => ref add(@as<T,sbyte>(edit(src)), (int)count);
    }
}