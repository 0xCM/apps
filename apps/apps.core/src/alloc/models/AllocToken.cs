//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct AllocToken
    {
        public readonly MemoryAddress Base;

        public readonly uint Offset;

        public readonly uint Size;

        [MethodImpl(Inline)]
        public AllocToken(MemoryAddress @base, uint offset, uint size)
        {
            Base = @base;
            Offset = offset;
            Size = size;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Size == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Size != 0;
        }

        public static AllocToken Empty => default;
    }
}