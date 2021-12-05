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
    using static core;

    /// <summary>
    /// Captures an instance method along with a reifying host
    /// </summary>
    public readonly struct MethodInstance
    {
        public ClrMethodAdapter Method {get;}

        public dynamic Host {get;}

        [MethodImpl(Inline)]
        public MethodInstance(ClrMethodAdapter method, dynamic host)
        {
            Method = method;
            Host = host;
        }

        [MethodImpl(Inline)]
        public static implicit operator MethodInstance((MethodInfo method, dynamic host) src)
            => new MethodInstance(src.method, src.host);
    }
}