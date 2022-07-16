//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Heaps
    {
        [MethodImpl(Inline), Op]
        public static HeapEntry entry(uint index, uint offset, uint length)
            => new HeapEntry(index, offset, length);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static HeapEntry<K> entry<K>(K index, uint offset, uint length)
            where K : unmanaged
                => new HeapEntry<K>(index, offset, length);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static HeapEntry<K,L> entry<K,L>(K index, uint offset, L length)
            where K : unmanaged
            where L : unmanaged
                => new HeapEntry<K,L>(index, offset, length);

        [MethodImpl(Inline)]
        public static HeapEntry<K,V,L> entry<K,V,L>(K index, V offset, L length)
            where K : unmanaged
            where V : unmanaged
            where L : unmanaged
                => new HeapEntry<K,V,L>(index, offset, length);
    }
}