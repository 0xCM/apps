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
            public static implicit operator gbv<ByteBlock32>(bv256 src)
                => new gbv<ByteBlock32>(Width, src.Storage);
        }
    }
}