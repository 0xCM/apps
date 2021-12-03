//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Canonical
{
    using System.Runtime.CompilerServices;

    using static Root;

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

        BitWidth ISizedType.ContentWidth
            => Width;

        public bit this[uint i]
        {
            [MethodImpl(Inline)]
            get => TS.state(this,i);

            [MethodImpl(Inline)]
            set => TS.state(value,i,ref this);
        }

        [MethodImpl(Inline)]
        public static implicit operator gbv<uint>(bv32 src)
            => new gbv<uint>(Width, src.Storage);
    }
}