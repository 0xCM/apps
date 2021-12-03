//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Canonical
{
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// Defines a 5-bit bitvector
    /// </summary>
    public struct bv5 : IIndexedBits<byte>
    {
        public const uint Width = 5;

        public byte Storage;

        [MethodImpl(Inline)]
        public bv5(byte src)
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
        public static implicit operator gbv<byte>(bv5 src)
            => new gbv<byte>(Width, src.Storage);
    }
}