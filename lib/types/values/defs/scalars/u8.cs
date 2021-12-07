//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Types
{
    using System.Runtime.CompilerServices;

    using static Root;

    public struct u8 : IUnsignedValue<Cell8>
    {
        public const uint Width = 8;

        public Cell8 Storage;

        [MethodImpl(Inline)]
        public u8(Cell8 src)
        {
            Storage = src;
        }

        BitWidth ISizedValue.ContentWidth
            => Width;

        [MethodImpl(Inline)]
        public static implicit operator u8(u8<byte> src)
            => new u8(src.Storage);

        [MethodImpl(Inline)]
        public static implicit operator u8<byte>(u8 src)
            => new u8<byte>(src.Storage);

        [MethodImpl(Inline)]
        public static implicit operator u8(byte src)
            => new u8(src);

        [MethodImpl(Inline)]
        public static implicit operator byte(u8 src)
            => src.Storage;
    }
}