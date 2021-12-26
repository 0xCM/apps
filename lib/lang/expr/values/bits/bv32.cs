//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Expr
{
    using System.Runtime.CompilerServices;

    using static Root;

    using T = bv32;

    /// <summary>
    /// Defines a 32-bit bitvector
    /// </summary>
    public struct bv32 : IIndexedBits<uint>
    {
        public const uint Width = 32;

        public uint Storage;

        [MethodImpl(Inline)]
        public bv32(uint src)
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
        public static implicit operator gbv<uint>(bv32 src)
            => new gbv<uint>(Width, src.Storage);
    }
}