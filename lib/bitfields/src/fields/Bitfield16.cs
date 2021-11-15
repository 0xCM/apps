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
    using S = System.UInt16;

    public struct Bitfield16
    {
        public const byte Width = 16;

        S _State;

        [MethodImpl(Inline)]
        public Bitfield16(S state)
            => _State = state;

        [MethodImpl(Inline)]
        public S Read(byte offset, byte width)
            => api.read(this, offset, width);

        [MethodImpl(Inline)]
        public Bitfield16 Store(S src, byte offset, byte width)
        {
            api.store(src, offset, width, ref this);
            return this;
        }

        public ReadOnlySpan<byte> Bytes
        {
            [MethodImpl(Inline)]
            get => bytes(_State);
        }

        public Bitfield8 Lo
        {
            [MethodImpl(Inline)]
            get => api.lo(this);
        }

        public Bitfield8 Hi
        {
            [MethodImpl(Inline)]
            get => api.hi(this);
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
        public static implicit operator S(Bitfield16 src)
            => src.State;

        [MethodImpl(Inline)]
        public static implicit operator Bitfield16(S src)
            => new Bitfield16(src);

    }
}