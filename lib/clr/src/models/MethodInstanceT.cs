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
    public readonly struct MethodInstance<T>
    {
        public ClrMethodAdapter Method {get;}

        public T Host {get;}

        [MethodImpl(Inline)]
        public MethodInstance(ClrMethodAdapter method, T host)
        {
            Method = method;
            Host = host;
        }

        [MethodImpl(Inline)]
        public static implicit operator MethodInstance<T>((MethodInfo method, T host) src)
            => new MethodInstance<T>(src.method, src.host);

        [MethodImpl(Inline)]
        public static implicit operator MethodInstance(MethodInstance<T> src)
            => new MethodInstance(src.Method, src.Host);
    }
}