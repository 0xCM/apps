//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Expr
{
    using System.Runtime.CompilerServices;

    using static Root;

    using T = bv16;

    /// <summary>
    /// Defines a 16-bit bitvector
    /// </summary>
    public struct bv16 : IIndexedBits<ushort>
    {
        public const uint Width = 16;

        public ushort Storage;

        [MethodImpl(Inline)]
        public bv16(ushort src)
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
        public static implicit operator gbv<ushort>(bv16 src)
            => new gbv<ushort>(Width, src.Storage);
    }
}