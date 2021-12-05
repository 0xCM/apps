//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface IApiMember : IApiMethod
    {
        MemoryAddress BaseAddress
            => MemoryAddress.Zero;

        ApiMsil Msil {get;}

        CliSig CliSig {get;}

    }

    [Free]
    public interface IApiMember<T> : IApiMember, IEquatable<T>, IComparable<T>
        where T : IApiMember<T>
    {

    }
}