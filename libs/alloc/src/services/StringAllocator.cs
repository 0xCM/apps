//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Spans;

    /// <summary>
    /// Allocates strings from a suplied <see cref='StringBuffer'/>
    /// </summary>
    public class StringAllocator : IStringAllocator<StringRef>
    {
        public static StringAllocator alloc(ByteSize capacity)
            => new StringAllocator(StringBuffers.buffer(capacity/2));

        public static StringAllocator cover(StringBuffer src)
            => new StringAllocator(src);

        StringBuffer Buffer;

        MemoryAddress MaxAddress;

        uint Position;

        public MemoryAddress BaseAddress {get;}

        public ByteSize Size {get;}

        internal StringAllocator(StringBuffer buffer)
        {
            Buffer = buffer;
            BaseAddress = buffer.BaseAddress;
            Size = buffer.Size;
            MaxAddress =  buffer.Address(buffer.Length);
            Position = 0;
        }

        public bool Alloc(string src, out StringRef dst)
            => Alloc(span(src), out dst);

        /// <summary>
        /// Populates a <see cref='StringRef'/> that represents the input if the buffer has sufficient capacity and returns true; otherwise,
        /// returns false
        /// </summary>
        /// <param name="src">The input sequence</param>
        /// <param name="dst">The input sequence reference, if successful, otherwise a reference to the empty string</param>
        public bool Alloc(ReadOnlySpan<char> src, out StringRef dst)
        {
            var length = (uint)src.Length;
            dst = StringRef.Empty;

            if(Buffer.Address(Position + length) > MaxAddress)
                return false;

            dst = Buffer.StoreString(src, Position);
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