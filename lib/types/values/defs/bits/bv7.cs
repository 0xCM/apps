//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Types
{
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// Defines a 7-bit bitvector
    /// </summary>
    public struct bv7 : IIndexedBits<byte>
    {
        public const uint Width = 7;

        public byte Storage;

        [MethodImpl(Inline)]
        public bv7(byte src)
        {
            Storage = src;
        }

        BitWidth ISizedValue.ContentWidth
            => Width;

        public bit this[uint i]
        {
            [MethodImpl(Inline)]
            get => TS.state(this,i);

            [MethodImpl(Inline)]
            set => TS.state(value,i,ref this);
        }

        [MethodImpl(Inline)]
        public static implicit operator gbv<byte>(bv7 src)
            => new gbv<byte>(Width, src.Storage);
    }
}