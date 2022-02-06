//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using api = Bitfields;
    using S = System.UInt16;

    /// <summary>
    /// Defines a 16-bit bitfield over a 16-bit integral type
    /// </summary>
    public struct Bitfield16
    {
        public const byte Width = 16;

        S _State;

        [MethodImpl(Inline)]
        public Bitfield16(S state)
            => _State = state;

        [MethodImpl(Inline)]
        public S Extract(byte min, byte max)
            => bits.extract(_State, min, max);

        [MethodImpl(Inline)]
        public void Store(S src, byte min, byte max)
            => bits.store(src, min, max, ref _State);

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