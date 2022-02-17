//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class PageBank<N> : IBufferAllocation
        where N : unmanaged, ITypeNat
    {
        public const uint PageSize = PageBlock.PageSize;

        public static PageBank<N> alloc()
            => new PageBank<N>();

        readonly NativeBuffer Buffer;

        internal PageBank()
        {
            Buffer = memory.native(PageSize*nat32u<N>());
        }

        public void Dispose()
        {
            Buffer.Dispose();
        }

        public uint PageCount
        {
            [MethodImpl(Inline)]
            get => nat32u<N>();
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
            => slice(Buffer.Edit, index*PageSize, PageSize);

        [MethodImpl(Inline)]
        public MemoryAddress PageAddress(uint index)
            => address(first(PageBuffer(index)));
    }
}