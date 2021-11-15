//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Types
{
    using System.Runtime.CompilerServices;

    using static Root;

    public struct u8 : IUnsigned<Cell8>
    {
        public const ulong Width = 8;

        public Cell8 Storage;

        [MethodImpl(Inline)]
        public u8(Cell8 src)
        {
            Storage = src;
        }

        BitWidth IBlittable.ContentWidth
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

    /// <summary>
    /// Defines an unsigned 8-bit integer over parametric storage
    /// </summary>
    public struct u8<T> : IUnsigned<T>
        where T : unmanaged
    {
        public const ulong Width = 8;

        public T Storage;

        [MethodImpl(Inline)]
        public u8(T src)
        {
            Storage = src;
        }

        BitWidth IBlittable.ContentWidth
            => Width;
    }
}