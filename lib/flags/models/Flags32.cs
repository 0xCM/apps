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

    public struct Flags32<K> : IFlags<K>
        where K : unmanaged
    {
        public const byte Width = 32;

        public K State {get;}

        [MethodImpl(Inline)]
        public Flags32(K value)
            => State = value;
        public BitWidth DataWidth
            => Width;

        public bit this[byte index]
        {
            [MethodImpl(Inline)]
            get => api.state(this, index);
        }

        public bit this[Pow2x32 flag]
        {
            [MethodImpl(Inline)]
            get => api.state(this, flag);
        }

        public string Format()
            => api.format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Flags32<K>(K src)
            => new Flags32<K>(src);

        [MethodImpl(Inline)]
        public static implicit operator K(Flags32<K> src)
            => src.State;
    }
}
