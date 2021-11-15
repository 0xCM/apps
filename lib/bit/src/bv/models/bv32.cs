//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct BV
    {
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

            BitWidth IBlittable.ContentWidth
                => Width;

            public bit this[uint i]
            {
                [MethodImpl(Inline)]
                get => state(this,i);

                [MethodImpl(Inline)]
                set => state(value,i,ref this);
            }

            [MethodImpl(Inline)]
            public static implicit operator gbv<uint>(bv32 src)
                => new gbv<uint>(Width, src.Storage);
        }
    }
}