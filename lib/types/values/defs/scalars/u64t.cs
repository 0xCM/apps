//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Types
{
    using System.Runtime.CompilerServices;

    using static Root;

    public struct u64<T> : IUnsignedValue<T>
        where T : unmanaged
    {
        public const uint Width = 64;

        public T Storage;

        [MethodImpl(Inline)]
        public u64(T src)
        {
            Storage = src;
        }

        public string Format()
            => Storage.ToString();

        public override string ToString()
            => Format();

        BitWidth ISizedValue.ContentWidth
            => Width;

        [MethodImpl(Inline)]
        public static implicit operator u64<T>(T src)
            => new u64<T>(src);

        [MethodImpl(Inline)]
        public static implicit operator T(u64<T> src)
            => src.Storage;

        [MethodImpl(Inline)]
        public static implicit operator u64(u64<T> src)
            => core.bw64(src.Storage);
    }
}