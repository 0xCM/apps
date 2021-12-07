//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Types
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    public struct u16<T> : IUnsignedValue<T>, IEquatable<u16<T>>
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

        public bool Equals(u16<T> src)
            => bw16(Storage) == bw16(src.Storage);

        BitWidth ISizedValue.ContentWidth
            => Width;
    }
}