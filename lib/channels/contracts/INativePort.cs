//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    using Flows;
    using System;

    [Free]
    public interface INativePort
    {
        ReadOnlySpan<NativeChannel> Inputs {get;}

        ReadOnlySpan<NativeChannel> Outputs {get;}
    }
}