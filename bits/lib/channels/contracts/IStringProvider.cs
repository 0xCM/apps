//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface IStringProvider : IReadOnlySpanProvider<char>
    {
        new string Data();

        ReadOnlySpan<char> IReadOnlySpanProvider<char>.Data()
            => Data();
    }
}