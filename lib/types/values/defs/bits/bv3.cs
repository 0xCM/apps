//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Types
{
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// Defines a 3-bit bitvector
    /// </summary>
    public struct bv3 : IIndexedBits<byte>
    {
        public const uint Width = 3;

        public byte Storage;

        [MethodImpl(Inline)]
        public bv3(byte src)
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
            set => TV.state(value,i,ref this);
        }

        [MethodImpl(Inline)]
        public static implicit operator gbv<byte>(bv3 src)
            => new gbv<byte>(Width, src.Storage);

        [MethodImpl(Inline)]
        public static implicit operator bv3(gbv<byte> src)
            => new bv3(src.Storage);
    }
}