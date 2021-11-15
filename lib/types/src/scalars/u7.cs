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
    /// Defines an unsigned 7-bit integer over an 8-bit cell
    /// </summary>
    public struct u7 : IUnsigned<u7>
    {
        public const ulong Width = 7;

        public static N7 N => default;

        public Cell8 Storage;

        [MethodImpl(Inline)]
        public u7(Cell8 src)
        {
            Storage = Cells.trim(src,N);
        }

        BitWidth IBlittable.ContentWidth
            => Width;
    }

    /// <summary>
    /// Defines an unsigned 7-bit integer over parametric storage
    /// </summary>
    public struct u7<T> : IUnsigned<T>
        where T : unmanaged
    {
        public static ByteSize SZ = size<u7<T>>();
        public const ulong Width = 7;

        public T Storage;

        [MethodImpl(Inline)]
        public u7(T src)
        {
            Storage = src;
        }

        BitWidth IBlittable.ContentWidth
            => Width;
    }
}