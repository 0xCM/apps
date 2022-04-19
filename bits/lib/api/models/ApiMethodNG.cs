//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct ApiMethodNG : IHostedApiMethod
    {
        /// <summary>
        /// The delcaring host
        /// </summary>
        public IApiHost Host {get;}

        /// <summary>
        /// The operation identity
        /// </summary>
        public OpIdentity Id {get;}

        /// <summary>
        /// The concrete method that defines the operation
        /// </summary>
        public MethodInfo Method {get;}

        /// <summary>
        /// Classifies the method as nongeneric
        /// </summary>
        public bool IsGeneric
            => false;

        [MethodImpl(Inline)]
        public ApiMethodNG(IApiHost host, OpIdentity id, MethodInfo method)
        {
            Host = host;
            Id = id;
            Method = method;
        }

        ApiHostUri IApiMethod.Host
            => Host.HostUri;

        public override string ToString()
            => Id;
    }
}