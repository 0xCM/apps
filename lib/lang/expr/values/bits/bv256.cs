//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Expr
{
    using System.Runtime.CompilerServices;

    using static Root;

    using T = bv256;

    /// <summary>
    /// Defines a 256-bit bitvector
    /// </summary>
    public struct bv256 : IIndexedBits<ByteBlock16>
    {
        public const uint Width = 256;

        public ByteBlock32 Storage;

        [MethodImpl(Inline)]
        public bv256(ByteBlock32 src)
        {
            Storage = src;
        }

        BitWidth ISizedValue.ContentWidth
            => Width;

        public bit this[uint i]
        {
            [MethodImpl(Inline)]
            get => gbits.state(this,i);

            [MethodImpl(Inline)]
            set => gbits.state(value,i,ref this);
        }

        [MethodImpl(Inline)]
        public static implicit operator gbv<ByteBlock32>(bv256 src)
            => new gbv<ByteBlock32>(Width, src.Storage);
    }
}