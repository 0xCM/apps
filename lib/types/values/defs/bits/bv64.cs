//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Types
{
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// Defines a 64-bit bitvector
    /// </summary>
    public struct bv64 : IIndexedBits<ulong>
    {
        public const uint Width = 64;

        public ulong Storage;

        [MethodImpl(Inline)]
        public bv64(ulong src)
        {
            Storage = src;
        }

        BitWidth ISizedValue.ContentWidth
            => Width;

        public bit this[uint i]
        {
            [MethodImpl(Inline)]
            get => TV.state(this,i);

            [MethodImpl(Inline)]
            set => TV.state(value,i,ref this);
        }

        [MethodImpl(Inline)]
        public static implicit operator gbv<ulong>(bv64 src)
            => new gbv<ulong>(Width, src.Storage);
    }
}