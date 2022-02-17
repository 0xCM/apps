//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class PageAllocation : IBufferAllocation
    {
        public const uint PageSize = PageBlock.PageSize;

        public static PageAllocation alloc(uint pages)
            => new PageAllocation(pages);

        readonly NativeBuffer Buffer;

        public uint PageCount {get;}

        internal PageAllocation(uint pages)
        {
            PageCount = pages;
            Buffer = memory.native(PageSize*PageCount);
        }


        public void Dispose()
        {
            Buffer.Dispose();
        }

        public MemoryAddress BaseAddress
        {
            [MethodImpl(Inline)]
            get => Buffer.BaseAddress;
        }

        public ByteSize Size
        {
            [MethodImpl(Inline)]
            get => Buffer.Size;
        }

        public BitWidth Width
        {
            [MethodImpl(Inline)]
            get => Buffer.Width;
        }

        [MethodImpl(Inline)]
        public Span<byte> PageBuffer(uint index)
            => page(Buffer,index);

        [MethodImpl(Inline)]
        public MemoryAddress PageAddress(uint index)
            => address(Buffer,index);

        [MethodImpl(Inline)]
        static Span<byte> page(NativeBuffer src,  uint index)
            => slice(src.Edit, index*PageSize, PageSize);

        [MethodImpl(Inline)]
        static MemoryAddress address(NativeBuffer src,  uint index)
            => core.address(first(page(src,index)));

        static Index<MemorySeg> segments(NativeBuffer src, uint count)
        {
            var dst = alloc<MemorySeg>(count);
            for(var i=0u; i<count; i++)
            {
                var a = address(src,i);
                seek(dst,i) = new MemorySeg(address(src,i), PageSize);
            }
            return dst;
        }
    }
}