//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Expr
{
    using System.Runtime.CompilerServices;

    using static Root;

    using T = bv6;

    /// <summary>
    /// Defines a 6-bit bitvector
    /// </summary>
    public struct bv6 : IIndexedBits<byte>
    {
        public const uint Width = 6;

        public byte Storage;

        [MethodImpl(Inline)]
        public bv6(byte src)
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
        public static implicit operator gbv<byte>(bv6 src)
            => new gbv<byte>(Width, src.Storage);
    }
}