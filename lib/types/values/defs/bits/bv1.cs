//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Types
{
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// Defines a 1-bit bitvector
    /// </summary>
    public struct bv1 : IIndexedBits<byte>
    {
        public const uint Width = 1;

        public byte Storage;

        [MethodImpl(Inline)]
        public bv1(byte src)
        {
            Storage = src;
        }

        BitWidth ISizedValue.ContentWidth
            => Width;

        public bit this[uint i]
        {
            [MethodImpl(Inline)]
            get => TV.state(this,i);

            [MethodImpl(Inline)]
            set => TV.state(value, i, ref this);
        }

        [MethodImpl(Inline)]
        public static implicit operator gbv<byte>(bv1 src)
            => new gbv<byte>(Width, src.Storage);
    }
}