
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    public interface IBufferAllocator : IDisposable
    {
        MemoryAddress BaseAddress {get;}

        ByteSize Capacity {get;}
    }

}