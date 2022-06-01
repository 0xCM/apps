//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class Heaps
    {
        [MethodImpl(Inline)]
        public static HeapEntry<K,V,L> entry<K,V,L>(K index, V offset, L length)
            where K : unmanaged
            where V : unmanaged
            where L : unmanaged
                => new HeapEntry<K,V,L>(index, offset, length);
    }
}