//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Types
{
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// Defines an unsigned 1-bit integer over parametric storage
    /// </summary>
    public struct u1<T> : IUnsignedValue<T>
        where T : unmanaged
    {
        public const uint Width = 1;

        public T Storage;

        [MethodImpl(Inline)]
        public u1(T src)
        {
            Storage = src;
        }

        BitWidth ISizedValue.ContentWidth
            => Width;
    }
}