//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface ITypedMutableSeq<T> : ITypedSeq<T>
        where T : ITyped
    {
        Span<T> Edit {get;}
    }
}