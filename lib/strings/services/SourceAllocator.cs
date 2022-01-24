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

    public class SourceAllocator : IStringAllocator<SourceText>
    {
        public static SourceAllocator create(uint capacity)
            => new SourceAllocator(StringBuffers.buffer(capacity));

        StringBuffer Buffer;

        MemoryAddress MaxAddress;

        uint Position;

        public MemoryAddress BaseAddress {get;}

        public ByteSize Size {get;}

        internal SourceAllocator(StringBuffer buffer)
        {
            Buffer = buffer;
            Size = buffer.Size;
            BaseAddress = buffer.BaseAddress;
            MaxAddress = buffer.Address(buffer.Length);
            Position = 0;
        }

        public bool Allocate(ReadOnlySpan<char> src, out SourceText dst)
        {
            var length = (uint)src.Length;
            dst = SourceText.Empty;

            if(Buffer.Address(Position + length) > MaxAddress)
                return false;

            dst = Buffer.StoreSource(src, Position);
            Position += length;
            return true;
        }

        public void Dispose()
        {
            Buffer.Dispose();
        }
    }
}