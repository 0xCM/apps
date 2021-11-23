//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.ScalarTypes
{
    using System.Runtime.CompilerServices;

    using static Root;

    public struct u64 : IUnsigned<ulong>
    {
        public const uint Width = 64;

        public ulong Storage;

        [MethodImpl(Inline)]
        public u64(ulong src)
        {
            Storage = src;
        }

        BitWidth IValue.ContentWidth
            => Width;

        public string Format()
            => Storage.ToString();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator u64(ulong src)
            => new u64(src);

        [MethodImpl(Inline)]
        public static implicit operator ulong(u64 src)
            => src.Storage;
    }

    public struct u64<T> : IUnsigned<T>
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

        BitWidth IValue.ContentWidth
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