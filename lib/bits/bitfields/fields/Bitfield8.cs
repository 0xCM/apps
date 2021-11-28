//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    using api = Bitfields;
    using S = System.Byte;

    public struct Bitfield8
    {
        public const byte Width = 8;

        S _State;

        [MethodImpl(Inline)]
        public Bitfield8(S state)
            => _State = state;

        [MethodImpl(Inline)]
        public S Read(byte pos, byte width)
            => api.read(this, pos, width);

        [MethodImpl(Inline)]
        public Bitfield8 Store(S src, byte offset, byte width)
        {
            api.store(src, offset, width, ref this);
            return this;
        }

        public ReadOnlySpan<byte> Bytes
        {
            [MethodImpl(Inline)]
            get => bytes(_State);
        }

        public override string ToString()
            => Format();

        public string Format()
            => api.format(this);

        [MethodImpl(Inline)]
        internal void Overwrite(S src)
            => _State = src;

        internal S State
        {
            [MethodImpl(Inline)]
            get => _State;
        }

        [MethodImpl(Inline)]
        public static implicit operator S(Bitfield8 src)
            => src.State;

        [MethodImpl(Inline)]
        public static implicit operator Bitfield8(S src)
            => new Bitfield8(src);
    }
}