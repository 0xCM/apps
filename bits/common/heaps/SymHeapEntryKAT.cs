//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public readonly struct SymHeapEntry<K,A,T>
        where K : unmanaged
        where A : unmanaged
        where T : unmanaged
    {
        public readonly K Key;

        public readonly A Offset;

        public readonly T Length;

        [MethodImpl(Inline)]
        public SymHeapEntry(K index, A offset, T length)
        {
            Key = index;
            Offset = offset;
            Length = length;
        }
    }
}