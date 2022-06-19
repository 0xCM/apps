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
    /// Defines a catalog over <see cref='ApiMember'/> values for a specified <see cref='IApiHost'/>
    /// </summary>
    public readonly struct ApiHostMethods : IIndex<MethodInfo>
    {
        [MethodImpl(Inline), Op]
        public static ApiHostMethods load(IApiHost host, MethodInfo[] methods)
            => new ApiHostMethods(host, methods);

        [MethodImpl(Inline), Op]
        public static ApiHostMethods load(IApiHost src)
            => load(src, src.Methods);

        public IApiHost Host {get;}

        public MethodInfo[] Storage {get;}

        [MethodImpl(Inline)]
        public ApiHostMethods(IApiHost host, MethodInfo[] src)
        {
            Host = host;
            Storage = src;
        }

        public int Length
        {
            [MethodImpl(Inline)]
            get => Storage?.Length ?? 0;
        }

        public uint OpCount
        {
            [MethodImpl(Inline)]
            get => (uint)Length;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Length == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => !IsEmpty;
        }

        public ReadOnlySpan<ClrMethodAdapter> View
        {
            [MethodImpl(Inline)]
            get => recover<MethodInfo,ClrMethodAdapter>(@readonly(Storage));
        }

        public static ApiHostMethods Empty
        {
            [MethodImpl(Inline)]
            get => new ApiHostMethods(ApiHost.Empty, array<MethodInfo>());
        }

        [MethodImpl(Inline)]
        public static implicit operator MethodInfo[](ApiHostMethods src)
            => src.Storage;
    }
}