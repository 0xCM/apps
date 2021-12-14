//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    public class LabelAllocator
    {
        StringBuffer Buffer;

        MemoryAddress MaxAddress;

        uint Position;

        internal LabelAllocator(StringBuffer buffer)
        {
            Buffer = buffer;
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
    }
}