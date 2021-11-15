//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Types
{
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// Defines an unsigned 5-bit integer over an 8-bit cell
    /// </summary>
    public struct u6 : IUnsigned<u6>
    {
        public const ulong Width = 6;

        public static N6 N => default;

        public Cell8 Storage;

        [MethodImpl(Inline)]
        public u6(Cell8 src)
        {
            Storage = Cells.trim(src,N);
        }

        BitWidth IBlittable.ContentWidth
            => Width;
    }

    public struct u6<T> : IUnsigned<T>
        where T : unmanaged
    {
        public const ulong Width = 6;

        public T Storage;

        [MethodImpl(Inline)]
        public u6(T src)
        {
            Storage = src;
        }

        BitWidth IBlittable.ContentWidth
            => Width;
    }
}