//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class StringAllocation : IBufferAllocation
    {
        public static StringAllocation allocate(ReadOnlySpan<string> src)
        {
            var count = src.Length;
            var total = 0u;
            for(var i=0; i<count; i++)
                total += (uint)skip(src,i).Length;

            var storage = StringBuffers.buffer(total);
            var allocator = new StringAllocator(storage);
            var dst = core.alloc<StringRef>(count);
            for(var i=0; i<count; i++)
                allocator.Allocate(skip(src,i), out seek(dst,i));
            return new StringAllocation(allocator, dst);
        }

        readonly IBufferAllocator Allocator;

        readonly Index<StringRef> _Allocated;

        public MemoryAddress BaseAddress {get;}

        public ByteSize Size {get;}

        [MethodImpl(Inline)]
        internal StringAllocation(IBufferAllocator allocator, StringRef[] allocated)
        {
            Allocator = allocator;
            _Allocated = allocated;
            BaseAddress = allocator.BaseAddress;
            Size = allocator.Size;
        }

        public ReadOnlySpan<StringRef> Allocated
        {
            [MethodImpl(Inline)]
            get => _Allocated;
        }

        public void Dispose()
        {
            Allocator.Dispose();
        }
    }
}