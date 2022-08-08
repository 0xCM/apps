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
            => Sized.size<T>();

        ByteSize IBufferAllocation.Size
            => Sized.size<T>();
    }
}