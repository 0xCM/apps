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
    /// Defines an unsigned 5-bit integer over an 8-bit cell
    /// </summary>
    public struct u5 : IUnsigned<u5>
    {
        public const ulong Width = 5;

        public static N5 N => default;

        public Cell8 Storage;

        [MethodImpl(Inline)]
        public u5(Cell8 src)
        {
            Storage = Cells.trim(src,N);
        }

        BitWidth IBlittable.ContentWidth
            => Width;
    }

    /// <summary>
    /// Defines an unsigned 5-bit integer over parametric storage
    /// </summary>
    public struct u5<T> : IUnsigned<T>
        where T : unmanaged
    {
        public static ByteSize SZ = size<u5<T>>();
        public const ulong Width = 5;

        public static N5 N => default;

        public T Storage;

        [MethodImpl(Inline)]
        public u5(T src)
        {
            Storage = src;
        }

        BitWidth IBlittable.ContentWidth
            => Width;
    }
}