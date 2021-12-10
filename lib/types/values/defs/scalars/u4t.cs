//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Types
{
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// Defines an unsigned 4-bit integer over parametric storage
    /// </summary>
    public struct u4<T> : IUnsignedInteger<T>
        where T : unmanaged
    {
        public const ulong Width = 4;

        public T Storage;

        [MethodImpl(Inline)]
        public u4(T src)
        {
            Storage = src;
        }

        BitWidth ISizedValue.ContentWidth
            => Width;
    }
}