//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Reflection;

    using static Root;

    /// <summary>
    /// Describes a concrete api
    /// </summary>
    public class ApiMember : IApiMember<ApiMember>
    {
        public readonly OpUri OpUri;

        public readonly MethodInfo Method;

        public readonly ApiClassKind ApiClass;

        public readonly ApiMsil Msil;

        public readonly ClrMethodArtifact Metadata;

        public ApiMember(OpUri uri, MethodInfo method, MemoryAddress address)
        {
            OpUri = uri;
            ApiClass = method.ApiClass();
            Method = Require.notnull(method);
            Msil = ClrDynamic.msil(address, uri, method);
            Metadata = method.Artifact();
        }

        public OpIdentity Id
        {
            [MethodImpl(Inline)]
            get => OpUri.OpId;
        }

        public string Group
        {
            [MethodImpl(Inline)]
            get => Method.ApiGroup();
        }

        public MemoryAddress BaseAddress
        {
            [MethodImpl(Inline)]
            get => Msil.BaseAddress;
        }

        public ApiHostUri Host
        {
            [MethodImpl(Inline)]
            get => OpUri.Host;
        }

        public CliSig CliSig
        {
             [MethodImpl(Inline)]
             get => Msil.CliSig;
        }

        public CliToken Token
        {
            [MethodImpl(Inline)]
            get => Msil.Token;
        }

        [MethodImpl(Inline)]
        public bool Equals(ApiMember src)
        {
            var result = Id.Equals(src.Id);
            result &= OpUri.Equals(src.OpUri);
            result &= Method.Equals(src.Method);
            result &= ApiClass.Equals(src.ApiClass);
            result &= BaseAddress.Equals(src.BaseAddress);
            result &= Host.Equals(src.Host);
            return result;
        }

        [MethodImpl(Inline)]
        public int CompareTo(ApiMember src)
            => BaseAddress.CompareTo(src.BaseAddress);

        public static ApiMember Empty
            => new ApiMember(OpUri.Empty, EmptyVessels.EmptyMethod, 0);

        ApiMsil IApiMember.Msil
            => Msil;

        MethodInfo IApiMethod.Method
            => Method;
    }
}