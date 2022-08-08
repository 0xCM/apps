//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IAllocation<T> : IBufferAllocation, ICellular<T>
        where T : unmanaged
    {
        new ByteSize Size
            => core.size<T>();

        ByteSize IBufferAllocation.Size
            => core.size<T>();
    }
}