//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Expr
{
    using System.Runtime.CompilerServices;

    using static Root;

    using T = bv4;

    /// <summary>
    /// Defines a 4-bit bitvector
    /// </summary>
    public struct bv4 : IIndexedBits<byte>
    {
        public const uint Width = 4;

        public byte Storage;

        [MethodImpl(Inline)]
        public bv4(byte src)
        {
            Storage = src;
        }

        BitWidth ISizedValue.ContentWidth
            => Width;

        public bit this[uint i]
        {
            [MethodImpl(Inline)]
            get => expr.state(this,i);

            [MethodImpl(Inline)]
            set => expr.state(value,i,ref this);
        }

        [MethodImpl(Inline)]
        public static implicit operator gbv<byte>(bv4 src)
            => new gbv<byte>(Width, src.Storage);
    }
}