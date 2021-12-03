//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    using api = Flags;

    public struct Flags64<K> : IFlags<Flags64<K>,K,Pow2x64>
        where K : unmanaged
    {
        public const byte Width = 64;

        readonly K Data;

        [MethodImpl(Inline)]
        public Flags64(K value)
            => Data = value;

        public BitWidth DataWidth
            => Width;

        public bit this[K flag]
        {
            [MethodImpl(Inline)]
            get => api.state(this, flag);
        }

        public bit this[Pow2x64 flag]
        {
            [MethodImpl(Inline)]
            get => api.state(this, flag);
        }

        public string Format()
            => api.format(this);

        public override string ToString()
            => Format();

        public K State
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        [MethodImpl(Inline)]
        public static implicit operator Flags64<K>(K src)
            => new Flags64<K>(src);

        [MethodImpl(Inline)]
        public static implicit operator K(Flags64<K> src)
            => src.Data;
    }
}
