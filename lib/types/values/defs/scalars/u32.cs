//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Types
{
    using System.Runtime.CompilerServices;

    using static Root;

    public struct u32 : IUnsignedInteger<uint>
    {
        public const uint Width = 32;

        public uint Storage;

        [MethodImpl(Inline)]
        public u32(uint src)
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
        public static implicit operator u32(uint src)
            => new u32(src);

        [MethodImpl(Inline)]
        public static implicit operator uint(u32 src)
            => src.Storage;
    }
}