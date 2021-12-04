//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Types
{
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// Defines an unsigned 4-bit integer over an 8-bit cell
    /// </summary>
    public struct u4 : IUnsigned<u4>
    {
        public const uint Width = 4;

        public Cell8 Storage;

        [MethodImpl(Inline)]
        public u4(Cell8 src)
        {
            Storage = Cells.trim(src,n4);
        }

        BitWidth ISizedType.ContentWidth
            => Width;
    }

    /// <summary>
    /// Defines an unsigned 4-bit integer over parametric storage
    /// </summary>
    public struct u4<T> : IUnsigned<T>
        where T : unmanaged
    {
        public const ulong Width = 4;

        public T Storage;

        [MethodImpl(Inline)]
        public u4(T src)
        {
            Storage = src;
        }

        BitWidth ISizedType.ContentWidth
            => Width;
    }
}