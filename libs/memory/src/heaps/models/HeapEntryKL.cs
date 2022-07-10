//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public readonly struct HeapEntry<K,L>
        where K : unmanaged
        where L : unmanaged
    {
        public readonly K Index;

        public readonly uint Offset;

        public readonly L Length;

        [MethodImpl(Inline)]
        public HeapEntry(K index, uint offset, L length)
        {
            Index = index;
            Offset = offset;
            Length = length;
        }
    }
}