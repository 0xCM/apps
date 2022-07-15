//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct core
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static DataEvent<T> edata<T>(T src)
            => new DataEvent<T>(src);
    }
}