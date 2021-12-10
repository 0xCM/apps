//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Types
{
    using System.Runtime.CompilerServices;

    using static Root;

    public struct u64 : IUnsignedInteger<ulong>
    {
        public const uint Width = 64;

        public ulong Storage;

        [MethodImpl(Inline)]
        public u64(ulong src)
        {
            Storage = src;
        }

        BitWidth ISizedValue.ContentWidth
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
}