//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Types
{
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// Defines a 128-bit bitvector
    /// </summary>
    public struct bv128 : IIndexedBits<ByteBlock16>
    {
        public const uint Width = 128;

        public ByteBlock16 Storage;

        [MethodImpl(Inline)]
        public bv128(ByteBlock16 src)
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
        public static implicit operator gbv<ByteBlock16>(bv128 src)
            => new gbv<ByteBlock16>(Width, src.Storage);
    }
}