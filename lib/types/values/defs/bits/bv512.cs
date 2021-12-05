//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Types
{
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// Defines a 512-bit bitvector
    /// </summary>
    public struct bv512 : IIndexedBits<ByteBlock16>
    {
        public const uint Width = 512;

        public ByteBlock64 Storage;

        [MethodImpl(Inline)]
        public bv512(ByteBlock64 src)
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
        public static implicit operator gbv<ByteBlock64>(bv512 src)
            => new gbv<ByteBlock64>(Width, src.Storage);
    }
}