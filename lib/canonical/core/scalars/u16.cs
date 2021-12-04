//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Canonical
{
    using System.Runtime.CompilerServices;

    using static Root;

    public struct u16 : IUnsigned<Cell8>
    {
        public const uint Width = 16;

        public Cell16 Storage;

        [MethodImpl(Inline)]
        public u16(Cell16 src)
        {
            Storage = src;
        }

        BitWidth ISizedType.ContentWidth
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

    public struct u16<T> : IUnsigned<T>
        where T : unmanaged
    {
        public const ulong Width = 16;

        public T Storage;

        [MethodImpl(Inline)]
        public u16(T src)
        {
            Storage = src;
        }

        public string Format()
            => Storage.ToString();

        public override string ToString()
            => Format();

        BitWidth ISizedType.ContentWidth
            => Width;
    }
}