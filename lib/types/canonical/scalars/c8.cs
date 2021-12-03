//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.ScalarTypes
{
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// Represents a character of width 8
    /// </summary>
    public struct c8<T> : IChar<T>
        where T : unmanaged
    {
        public const ulong Width = 8;

        public T Storage;

        [MethodImpl(Inline)]
        public c8(T src)
        {
            Storage = src;
        }

        public string Format()
            => Storage.ToString();

        public override string ToString()
            => Format();
        BitWidth ISizedType.ContentWidth
            => Width;

        [MethodImpl(Inline)]
        public static implicit operator c8<T>(T src)
            => new c8<T>(src);

        [MethodImpl(Inline)]
        public static implicit operator T(c8<T> src)
            => src.Storage;
    }
}