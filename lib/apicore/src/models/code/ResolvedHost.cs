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

    public readonly struct ResolvedHost : IComparable<ResolvedHost>
    {
        public ApiHostUri Host {get;}

        public Index<ResolvedMethod> Methods {get;}

        public MemoryAddress BaseAddress {get;}

        [MethodImpl(Inline)]
        public ResolvedHost(ApiHostUri uri, MemoryAddress @base, Index<ResolvedMethod> methods)
        {
            Host = uri;
            Methods = methods;
            BaseAddress = @base;
        }

        public Type HostType
        {
            [MethodImpl(Inline)]
            get => IsEmpty ? typeof(void) : Methods.First.HostType;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Host.IsEmpty;
        }

        public Assembly Component
        {
            [MethodImpl(Inline)]
            get => IsEmpty ? typeof(void).Assembly : HostType.Assembly;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Host.IsNonEmpty && Methods.IsNonEmpty;
        }

        public uint MethodCount
        {
            [MethodImpl(Inline)]
            get => Methods.Count;
        }

        [MethodImpl(Inline)]
        public int CompareTo(ResolvedHost src)
            => BaseAddress.CompareTo(src.BaseAddress);

        public string Format()
            => IsEmpty ? "<empty>" : string.Format("{0}::{1}:{2}", BaseAddress.Format(), Component.Format(), HostType.Format());


        public override string ToString()
            => Format();

        public static ResolvedHost Empty
        {
            [MethodImpl(Inline)]
            get => new ResolvedHost(ApiHostUri.Empty, default, sys.empty<ResolvedMethod>());
        }
    }
}