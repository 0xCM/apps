//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    public interface IStringAllocator<T> : IBufferAllocator<string,T>
        where T : IMemoryString
    {
        bool Alloc(ReadOnlySpan<char> src, out T dst);
    }
}