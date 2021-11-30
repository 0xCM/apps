//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface INativeModule : IDisposable
    {
        string Name {get;}

        IntPtr Handle {get;}
    }

    [Free]
    public interface INativeModule<T> : INativeModule
        where T : unmanaged
    {

    }
}