//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Flows
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    using System;

    [Free]
    public interface INativePort
    {
        ReadOnlySpan<NativeChannel> Inputs {get;}

        ReadOnlySpan<NativeChannel> Outputs {get;}
    }
}