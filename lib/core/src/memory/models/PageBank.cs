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

    public class PageBank : IDisposable
    {
        public const uint PageSize = PageBlock.PageSize;

        public static PageBank alloc(uint pages)
            => new PageBank(pages);

        readonly NativeBuffer Buffer;

        internal PageBank(uint pages)
        {
            PageCount = pages;
            Buffer = memory.native(PageSize*PageCount);
        }

        public void Dispose()
        {
            Buffer.Dispose();
        }

        public uint PageCount {get;}

        [MethodImpl(Inline)]
        public Span<byte> PageBuffer(uint index)
            => slice(Buffer.Edit, index*PageSize, PageSize);

        [MethodImpl(Inline)]
        public MemoryAddress PageAddress(uint index)
            => address(first(PageBuffer(index)));
    }
}