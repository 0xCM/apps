//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection;

    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface IClrRuntimeObject : IClrArtifact
    {

    }

    [Free]
    public interface IClrRuntimeObject<D> : IClrRuntimeObject
    {
        D Definition {get;}
    }

    [Free]
    public interface IClrRuntimeObject<H,D> : IClrRuntimeObject<D>
        where H : IClrRuntimeObject<H,D>
    {

    }
}