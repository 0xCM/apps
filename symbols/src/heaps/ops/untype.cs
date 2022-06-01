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
        public static BinaryHeap untype<T>(in BinaryHeap<T> src)
            where T : unmanaged
                => src;
    }
}