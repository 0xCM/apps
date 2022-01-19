//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    public interface IStringAllocator<T> : IBufferAllocator
        where T : IMemoryString
    {
        bool Allocate(ReadOnlySpan<char> src, out T dst);
    }
}