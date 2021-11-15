//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using api = PageBlocks;

    public interface IPageBank<N,T>
        where T : unmanaged, IPageBlock<T>
        where N : unmanaged, ITypeNat
    {
        MemoryAddress BaseAddress {get;}

        uint PageCount
            => api.PageCount<T>();

        ByteSize Size => size<T>();

        MemoryRange Range
            => (BaseAddress, BaseAddress + Size);
    }
}