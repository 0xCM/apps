//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Lang.c
{
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    public struct union
    {
        public static union<byte,T0,T1> instance<T0,T1>()
            => new union<byte,T0,T1>(default(T0));
    }

    public struct union<K,T0,T1>
        where K : unmanaged
    {
        K Kind;

        dynamic Data;

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
        public void store(in T1 src)
        {
            Data = src;
        }

        [MethodImpl(Inline)]
        public void store(in T0 src)
        {
            Data = src;
        }

        [MethodImpl(Inline)]
        public ref T0 stored(N0 n, out T0 dst)
        {
            dst = (T0)Data;
            return ref dst;
        }

        [MethodImpl(Inline)]
        public ref T1 stored(N1 n, out T1 dst)
        {
            dst = (T1)Data;
            return ref dst;
        }

        public override string ToString()
            => Data.ToString();

        [MethodImpl(Inline)]
        public static implicit operator union<K,T0,T1>(T0 value)
            => new union<K,T0,T1>(value);

        [MethodImpl(Inline)]
        public static implicit operator union<K,T0,T1>(T1 value)
            => new union<K,T0,T1>(value);
    }

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