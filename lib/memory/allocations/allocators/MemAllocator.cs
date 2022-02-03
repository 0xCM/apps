//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class MemAllocator : IBufferAllocator<ByteSize,MemorySeg>
    {
        public static MemAllocator alloc(ByteSize capacity)
            => new MemAllocator(capacity);

        NativeBuffer Buffer;

        uint Offset;

        MemoryAddress MaxAddress;

        MemAllocator(ByteSize size)
        {
            Size = size;
            Buffer = memory.native(size);
        }

        public ByteSize Size {get;}

        public ByteSize Consumed
        {
            [MethodImpl(Inline)]
            get => Offset;
        }

        public ByteSize Remaining
        {
            [MethodImpl(Inline)]
            get => Size - Offset;
        }

        public MemoryAddress BaseAddress
        {
            [MethodImpl(Inline)]
            get => Buffer.BaseAddress;
        }

        public bool Allocate(ByteSize size, out MemorySeg dst)
        {
            var right = Buffer.Address(Offset + size);
            if(right > MaxAddress)
            {
                dst = MemorySeg.Empty;
                return false;
            }
            else
            {
                var left = Buffer.Address(Offset);
                dst = (left,right);
                Offset += (size + 1);
                return true;
            }
        }

        public void Clear()
        {
            Offset = 0;
        }

        public void Dispose()
        {
            Buffer.Dispose();
        }
    }
}