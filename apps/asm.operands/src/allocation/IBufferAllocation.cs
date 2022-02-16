//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    public interface IBufferAllocation<T> : IBufferAllocation
        where T : unmanaged
    {
        ReadOnlySpan<T> Allocated {get;}
    }
}