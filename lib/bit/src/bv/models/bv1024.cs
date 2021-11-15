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
        /// Defines a 1024-bit bitvector
        /// </summary>
        public struct bv1024 : IIndexedBits<ByteBlock128>
        {
            public const uint Width = 1024;

            public ByteBlock128 Storage;

            [MethodImpl(Inline)]
            public bv1024(ByteBlock128 src)
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
            public static implicit operator gbv<ByteBlock128>(bv1024 src)
                => new gbv<ByteBlock128>(Width, src.Storage);
        }
    }
}