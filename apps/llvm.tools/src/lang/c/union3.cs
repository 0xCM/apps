//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Lang.c
{
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    public struct union<K,T0,T1,T2>
        where K : unmanaged
    {
        readonly K Kind;

        readonly dynamic Data;

        [MethodImpl(Inline)]
        public union(T0 src)
        {
            Kind = @as<byte,K>(0);
            Data = src;
        }

        [MethodImpl(Inline)]
        public union(T1 src)
        {
            Kind = @as<byte,K>(1);
            Data = src;
        }

        [MethodImpl(Inline)]
        public union(T2 src)
        {
            Kind = @as<byte,K>(2);
            Data = src;
        }

        [MethodImpl(Inline)]
        public static implicit operator union<K,T0,T1,T2>(T0 value)
            => new union<K,T0,T1,T2>(value);

        [MethodImpl(Inline)]
        public static implicit operator union<K,T0,T1,T2>(T1 value)
            => new union<K,T0,T1,T2>(value);

        [MethodImpl(Inline)]
        public static implicit operator union<K,T0,T1,T2>(T2 value)
            => new union<K,T0,T1,T2>(value);
    }
}