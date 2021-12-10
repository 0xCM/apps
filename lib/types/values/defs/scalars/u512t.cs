//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Types
{
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// Defines an unsigned 512-bit integer over parametric storage
    /// </summary>
    public struct u512<T> : IUnsignedInteger<T>
        where T : unmanaged
    {
        public const ulong Width = 512;

        public T Storage;

        [MethodImpl(Inline)]
        public u512(T src)
        {
            Storage = src;
        }

        public string Format()
            => Storage.ToString();

        public override string ToString()
            => Format();
        BitWidth ISizedValue.ContentWidth
            => Width;
    }
}