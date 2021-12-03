//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public struct bits<M,T>
        where M : unmanaged, ITypeNat
        where T : unmanaged
    {
        public T Packed;

        [MethodImpl(Inline)]
        public bits(T src)
        {
            Packed = src;
        }

        public uint N
        {
            [MethodImpl(Inline)]
            get => Typed.nat32u<M>();
        }

        [MethodImpl(Inline)]
        public static implicit operator bits<M,T>(T src)
            => new bits<M,T>(src);
    }
}