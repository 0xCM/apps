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
    public interface IClrRuntimeMethod : IClrRuntimeMember<MethodInfo>
    {
        ClrArtifactKind IClrArtifact.Kind
            => ClrArtifactKind.Method;
    }

    [Free]
    public interface IClrRuntimeMethod<M> : IClrRuntimeMethod, IClrRuntimeMember<M,MethodInfo>
        where M : struct, IClrRuntimeMethod<M>
    {

    }
}