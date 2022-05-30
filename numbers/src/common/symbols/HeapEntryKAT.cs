//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines a key to access a symbol deposited in a <see cref='SymHeap{K,O,L}'/>
    /// </summary>
    /// <typeparam name="K">The linear index type</typeparam>
    /// <typeparam name="O">The offset type</typeparam>
    /// <typeparam name="L">The length type</typeparam>
    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public readonly struct HeapEntry<K,O,L>
        where K : unmanaged
        where O : unmanaged
        where L : unmanaged
    {
        public readonly K Key;

        public readonly O Offset;

        public readonly L Length;

        [MethodImpl(Inline)]
        public HeapEntry(K index, O offset, L length)
        {
            Key = index;
            Offset = offset;
            Length = length;
        }
    }
}