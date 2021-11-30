//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface ISeq<T>
    {
        ReadOnlySpan<T> View {get;}
    }

    [Free]
    public interface IMutableSeq<T> : ISeq<T>
    {
        Span<T> Edit {get;}
    }
}
