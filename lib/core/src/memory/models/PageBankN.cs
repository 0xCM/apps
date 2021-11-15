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

    public class PageBank<N> : IDisposable
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

        [MethodImpl(Inline)]
        public Span<byte> PageBuffer(uint index)
            => slice(Buffer.Edit, index*PageSize, PageSize);

        [MethodImpl(Inline)]
        public MemoryAddress PageAddress(uint index)
            => address(first(PageBuffer(index)));
    }
}