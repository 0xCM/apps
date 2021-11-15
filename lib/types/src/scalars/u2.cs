//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Types
{
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// Defines an unsigned 2-bit integer over an 8-bit cell
    /// </summary>
    public struct u2 : IUnsigned<u2>
    {
        public const ulong Width = 2;

        public static N2 N => default;

        public Cell8 Storage;

        [MethodImpl(Inline)]
        public u2(Cell8 src)
        {
            Storage = Cells.trim(src,N);
        }

        BitWidth IBlittable.ContentWidth
            => Width;
    }

    /// <summary>
    /// Defines an unsigned 2-bit integer over parametric storage
    /// </summary>
    public struct u2<T> : IUnsigned<T>
        where T : unmanaged
    {
        public const ulong Width = 2;

        public T Storage;

        [MethodImpl(Inline)]
        public u2(T src)
        {
            Storage = src;
        }

        BitWidth IBlittable.ContentWidth
            => Width;
    }
}