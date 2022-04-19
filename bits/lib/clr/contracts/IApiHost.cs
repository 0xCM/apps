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
    public interface IApiHost
    {
        Type HostType {get;}

        bool FindMethod(OpUri uri, out MethodInfo method);

        Identifier HostName
            => HostUri.HostName;

        ApiHostUri HostUri
            => HostType.ApiHostUri();

        PartId PartId
            => HostType.Assembly.Id();

        Index<MethodInfo> Methods
            => HostType.DeclaredMethods();
    }
}