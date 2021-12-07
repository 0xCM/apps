//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Types
{
    using System.Runtime.CompilerServices;

    using static Root;

    public struct u16 : IUnsignedValue<Cell8>
    {
        public const uint Width = 16;

        public Cell16 Storage;

        [MethodImpl(Inline)]
        public u16(Cell16 src)
        {
            Storage = src;
        }

        BitWidth ISizedValue.ContentWidth
            => Width;

        [MethodImpl(Inline)]
        public static implicit operator u16(u16<byte> src)
            => new u16(src.Storage);

        [MethodImpl(Inline)]
        public static implicit operator u16<ushort>(u16 src)
            => new u16<ushort>(src.Storage);

        [MethodImpl(Inline)]
        public static implicit operator u16(ushort src)
            => new u16(src);

        [MethodImpl(Inline)]
        public static implicit operator ushort(u16 src)
            => src.Storage;
    }
}