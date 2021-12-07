//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Types
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    /// <summary>
    /// Defines an unsigned 8-bit integer over parametric storage
    /// </summary>
    public struct u8<T> : IUnsignedValue<T>, IEquatable<u8<T>>
        where T : unmanaged
    {
        public const ulong Width = 8;

        public T Storage;

        [MethodImpl(Inline)]
        public u8(T src)
        {
            Storage = src;
        }

        BitWidth ISizedValue.ContentWidth
            => Width;

        public bool Equals(u8<T> src)
            => bw8(Storage) == bw8(src.Storage);

    }
}