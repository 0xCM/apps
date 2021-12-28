//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface IReadOnlySpanProvider<T> : IDataProvider
    {
        ReadOnlySpan<T> Data();
    }

    [Free]
    public interface ISpanProvider<T> : IReadOnlySpanProvider<T>
    {
        new Span<T> Data();

        ReadOnlySpan<T> IReadOnlySpanProvider<T>.Data()
            => Data();
    }
}