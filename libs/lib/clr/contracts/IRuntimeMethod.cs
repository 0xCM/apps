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
    public interface IRuntimeMethod : IRuntimeMember<MethodInfo>
    {
        ClrArtifactKind IClrArtifact.Kind
            => ClrArtifactKind.Method;
    }

    [Free]
    public interface IRuntimeMethod<M> : IRuntimeMethod, IRuntimeMember<M,MethodInfo>
        where M : struct, IRuntimeMethod<M>
    {

    }
}