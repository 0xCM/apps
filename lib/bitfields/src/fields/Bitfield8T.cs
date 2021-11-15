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

    public struct Bitfield8<T>
        where T : unmanaged
    {
        public const byte Width = 8;

        S _State;

        [MethodImpl(Inline)]
        public Bitfield8(T state)
            => _State = uint8(state);

        [MethodImpl(Inline)]
        public Bitfield8(S state)
            => _State = state;

        [MethodImpl(Inline)]
        public T Read(byte offset, byte width)
            => api.read(this, offset, width);

        public ReadOnlySpan<byte> Bytes
        {
            [MethodImpl(Inline)]
            get => bytes(_State);
        }

        public override string ToString()
            => Format();

        public string Format()
            => api.format(this);

        internal S State
        {
            [MethodImpl(Inline)]
            get => _State;
        }

        [MethodImpl(Inline)]
        internal void Overwrite(S src)
            => _State = src;

        [MethodImpl(Inline)]
        public static implicit operator Bitfield8<T>(T src)
            => new Bitfield8<T>(src);

        [MethodImpl(Inline)]
        public static implicit operator Bitfield8<T>(S src)
            => new Bitfield8<T>(src);

        [MethodImpl(Inline)]
        public static explicit operator S(Bitfield8<T> src)
            => src._State;

        [MethodImpl(Inline)]
        public static implicit operator Bitfield8(Bitfield8<T> src)
            => new Bitfield8(src.State);
    }
}