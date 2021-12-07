//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Types
{
    using System.Runtime.CompilerServices;

    using static Root;

    using T = bv5;

    /// <summary>
    /// Defines a 5-bit bitvector
    /// </summary>
    public struct bv5 : IIndexedBits<byte>
    {
        public const uint Width = 5;

        public byte Storage;

        [MethodImpl(Inline)]
        public bv5(byte src)
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
        public static implicit operator gbv<byte>(bv5 src)
            => new gbv<byte>(Width, src.Storage);
    }
}