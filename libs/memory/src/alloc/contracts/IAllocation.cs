//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IAllocation : IBufferAllocation
    {

    }

    public interface IAllocation<T> : IAllocation
        where T : unmanaged
    {
        new uint Size
            => core.size<T>();

        ByteSize IBufferAllocation.Size
            => core.size<T>();
    }
}