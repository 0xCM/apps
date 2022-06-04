//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines a key to access a symbol deposited in a <see cref='SymHeap{K,V,L}'/>
    /// </summary>
    /// <typeparam name="K">The linear index type</typeparam>
    /// <typeparam name="V">The offset type</typeparam>
    /// <typeparam name="L">The length type</typeparam>
    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public readonly struct HeapEntry<K,V,L>
        where K : unmanaged
        where V : unmanaged
        where L : unmanaged
    {
        public readonly K Index;

        public readonly V Offset;

        public readonly L Length;

        [MethodImpl(Inline)]
        public HeapEntry(K index, V offset, L length)
        {
            Index = index;
            Offset = offset;
            Length = length;
        }
    }
}