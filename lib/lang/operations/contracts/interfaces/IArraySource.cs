//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface IArraySource<T> : ISpanProvider<T>
    {
        new T[] Data();

        Span<T> ISpanProvider<T>.Data()
            => Data();
    }
}