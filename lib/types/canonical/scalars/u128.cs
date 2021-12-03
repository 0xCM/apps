//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.ScalarTypes
{
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// Defines an unsigned 128-bit integer over parametric storage
    /// </summary>
    public struct u128<T> : IUnsigned<T>
        where T : unmanaged
    {
        public const uint Width = 128;

        public T Storage;

        [MethodImpl(Inline)]
        public u128(T src)
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