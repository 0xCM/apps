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
        /// Defines an 8-bit bitvector
        /// </summary>
        public struct bv8 : IIndexedBits<byte>
        {
            public const uint Width = 8;

            public byte Storage;

            [MethodImpl(Inline)]
            public bv8(byte src)
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
            public static implicit operator gbv<byte>(bv8 src)
                => new gbv<byte>(Width, src.Storage);
        }
    }
}