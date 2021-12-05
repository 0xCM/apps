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
    public interface IClrRuntimeMember : IClrRuntimeObject
    {
        MemberInfo Definition {get;}

        string IClrArtifact.Name
            => Definition.Name;

        CliToken IClrArtifact.Token
            => Definition.MetadataToken;
    }

    [Free]
    public interface IClrRuntimeMember<D> : IClrRuntimeMember, IClrRuntimeObject<D>
        where D : MemberInfo
    {
        MemberInfo IClrRuntimeMember.Definition
            => (this as IClrRuntimeObject<D>).Definition;
    }

    [Free]
    public interface IClrRuntimeMember<H,D> : IClrRuntimeMember<D>, IClrRuntimeObject<H,D>
        where D : MemberInfo
        where H : struct, IClrRuntimeMember<H,D>
    {

    }
}