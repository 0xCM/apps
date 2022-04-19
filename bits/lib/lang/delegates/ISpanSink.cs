//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface ISpanSink<H,T> : ISink<T>
        where H : struct, ISpanSink<H,T>
    {
        void Deposit(ReadOnlySpan<T> src);
    }
}