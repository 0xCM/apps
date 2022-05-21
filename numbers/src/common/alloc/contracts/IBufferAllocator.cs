
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

        ByteSize Size {get;}
    }

    public interface IBufferAllocator<S,T> : IBufferAllocator
    {
        bool Alloc(S src, out T dst);
    }
}