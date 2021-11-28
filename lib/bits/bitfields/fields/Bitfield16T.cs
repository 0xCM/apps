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
    using W = W16;

    public struct Bitfield16<T>
        where T : unmanaged
    {
        public const byte Width = 16;

        static W w => default;

        S _State;

        [MethodImpl(Inline)]
        public Bitfield16(T state)
            => _State = uint16(state);

        [MethodImpl(Inline)]
        public Bitfield16(S state)
            => _State = state;

        [MethodImpl(Inline)]
        public T Read(byte offset, byte width)
            => api.read(this, offset, width);

        public Bitfield8<T> Lo
        {
            [MethodImpl(Inline)]
            get => api.lo(this);
        }

        public Bitfield8<T> Hi
        {
            [MethodImpl(Inline)]
            get => api.hi(this);
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
        public static implicit operator Bitfield16<T>(T src)
            => new Bitfield16<T>(src);

        [MethodImpl(Inline)]
        public static implicit operator Bitfield16<T>(S src)
            => new Bitfield16<T>(src);

        [MethodImpl(Inline)]
        public static explicit operator S(Bitfield16<T> src)
            => src._State;

        [MethodImpl(Inline)]
        public static implicit operator Bitfield16(Bitfield16<T> src)
            => api.create(w, src.State);

    }
}