//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class Heaps
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static BinaryHeap<T> retype<T>(in BinaryHeap src)
            where T : unmanaged
                => src;
    }
}