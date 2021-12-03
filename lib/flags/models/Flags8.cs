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

    public struct Flags8<K> : IFlags<Flags8<K>,K,Pow2x8>
        where K : unmanaged
    {
        public const byte Width = 8;

        K Data;

        [MethodImpl(Inline)]
        public Flags8(K value)
            => Data = value;

        public BitWidth DataWidth
            => Width;

        public K State
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public bit this[K flag]
        {
            [MethodImpl(Inline)]
            get => api.state(this, flag);
        }

        public bit this[Pow2x8 flag]
        {
            [MethodImpl(Inline)]
            get => api.state(this, flag);
        }

        [MethodImpl(Inline)]
        internal void Update(K state)
            => Data = state;

        public string Format()
            => api.format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Flags8<K>(K src)
            => new Flags8<K>(src);

        [MethodImpl(Inline)]
        public static implicit operator K(Flags8<K> src)
            => src.Data;
    }
}
