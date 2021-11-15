//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Types
{
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    /// <summary>
    /// Defines an unsigned 32-bit integer over parametric storage
    /// </summary>
    public struct u32<T> : IUnsigned<T>
        where T : unmanaged
    {
        public static ByteSize SZ = size<u32<T>>();

        public const ulong Width = 32;

        public T Storage;

        [MethodImpl(Inline)]
        public u32(T src)
        {
            Storage = src;
        }

        BitWidth IBlittable.ContentWidth
            => Width;
    }
}