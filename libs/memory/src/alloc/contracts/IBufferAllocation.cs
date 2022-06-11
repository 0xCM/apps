//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IBufferAllocation<T> : IAllocation<T>
        where T : unmanaged
    {
        ReadOnlySpan<T> Allocated {get;}
    }
}