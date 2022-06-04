//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public readonly struct HeapEntry
    {
        public readonly uint Index;

        public readonly uint Offset;

        public readonly uint Length;

        readonly uint Pad;

        [MethodImpl(Inline)]
        public HeapEntry(uint index, uint offset, uint length)
        {
            Index = index;
            Offset = offset;
            Length = length;
            Pad = 0;
        }
    }
}