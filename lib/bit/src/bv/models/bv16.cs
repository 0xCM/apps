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
            public static implicit operator gbv<ushort>(bv16 src)
                => new gbv<ushort>(Width, src.Storage);
        }
    }
}