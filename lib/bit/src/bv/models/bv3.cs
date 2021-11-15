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
        /// Defines a 3-bit bitvector
        /// </summary>
        public struct bv3 : IIndexedBits<byte>
        {
            public const uint Width = 3;

            public byte Storage;

            [MethodImpl(Inline)]
            public bv3(byte src)
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
            public static implicit operator gbv<byte>(bv3 src)
                => new gbv<byte>(Width, src.Storage);

            [MethodImpl(Inline)]
            public static implicit operator bv3(gbv<byte> src)
                => new bv3(src.Storage);
        }
    }
}