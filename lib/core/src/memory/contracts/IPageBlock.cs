//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static Root;

    public interface IPageBlock<T>
        where T : unmanaged, IPageBlock<T>
    {
        ByteSize Size
            => size<T>();

        uint PageCount
            => size<T>()/PageSize;
    }
}