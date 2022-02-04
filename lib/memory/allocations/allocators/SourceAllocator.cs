//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class SourceAllocator : IStringAllocator<SourceText>
    {
        public static SourceAllocator alloc(uint capacity)
            => new SourceAllocator(StringBuffers.buffer(capacity/2));

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

        public bool Allocate(string src, out SourceText dst)
            => Allocate(span(src), out dst);

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

        public ByteSize Consumed
        {
            [MethodImpl(Inline)]
            get => Position*2;
        }

        public ByteSize Remaining
        {
            [MethodImpl(Inline)]
            get => Size - Consumed;
        }


        public void Dispose()
        {
            Buffer.Dispose();
        }
    }
}