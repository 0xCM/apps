//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Canonical
{
    using System.Runtime.CompilerServices;

    using static Root;

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