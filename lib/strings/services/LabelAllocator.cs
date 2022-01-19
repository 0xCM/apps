//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    public class LabelAllocator : IStringAllocator<Label>
    {
        StringBuffer Buffer;

        MemoryAddress MaxAddress;

        uint Position;

        public MemoryAddress BaseAddress {get;}

        public ByteSize Capacity {get;}

        internal LabelAllocator(StringBuffer buffer)
        {
            Buffer = buffer;
            BaseAddress = buffer.BaseAddress;
            Capacity = buffer.Capacity;
            MaxAddress =  buffer.Address(buffer.Length);
            Position = 0;
        }

        public bool Allocate(ReadOnlySpan<char> src, out Label dst)
        {
            var length = (uint)src.Length;
            dst = Label.Empty;
            if(length > 256)
                return false;

            if(Buffer.Address(Position + length) > MaxAddress)
                return false;

            dst = Buffer.StoreLabel(src, Position);
            Position += length;
            return true;
        }

        public void Dispose()
        {
            Buffer.Dispose();
        }
    }
}