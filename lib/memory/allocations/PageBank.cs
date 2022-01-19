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

    public class PageBank : IBufferAllocation
    {
        public const uint PageSize = PageBlock.PageSize;

        public static PageBank alloc(uint pages)
            => new PageBank(pages);

        readonly NativeBuffer Buffer;

        public uint PageCount {get;}

        internal PageBank(uint pages)
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

        public ByteSize Capacity
        {
            [MethodImpl(Inline)]
            get => Buffer.Capacity;
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