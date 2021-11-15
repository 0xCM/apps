//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;

    public interface IAsmText
    {
        StringAddress Source {get;}

        AsmTextKind Kind {get;}

        uint Render(ref uint i, Span<char> dst);
    }

    public interface IAsmText<T> : IAsmText
        where T : unmanaged
    {

    }
}