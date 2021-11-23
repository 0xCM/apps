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
        /// Defines a 2-bit bitvector
        /// </summary>
        public struct bv2 : IIndexedBits<byte>
        {
            public const uint Width = 2;

            public byte Storage;

            [MethodImpl(Inline)]
            public bv2(byte src)
            {
                Storage = src;
            }

            BitWidth IValue.ContentWidth
                => Width;

            public bit this[uint i]
            {
                [MethodImpl(Inline)]
                get => state(this,i);

                [MethodImpl(Inline)]
                set => state(value,i,ref this);
            }

            [MethodImpl(Inline)]
            public static implicit operator gbv<byte>(bv2 src)
                => new gbv<byte>(Width, src.Storage);

            [MethodImpl(Inline)]
            public static implicit operator bv2(gbv<byte> src)
                => new bv2(src.Storage);
        }
    }
}