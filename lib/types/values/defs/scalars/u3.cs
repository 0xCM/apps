//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Types
{
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// Defines an unsigned 3-bit integer over an 8-bit cell
    /// </summary>
    public struct u3 : IUnsignedValue<u3>
    {
        public const ulong Width = 3;

        public static N3 N => default;

        public Cell8 Storage;

        [MethodImpl(Inline)]
        public u3(Cell8 src)
        {
            Storage = Cells.trim(src,N);
        }

        BitWidth ISizedValue.ContentWidth
            => Width;
    }

    /// <summary>
    /// Defines an unsigned 3-bit integer over parametric storage
    /// </summary>
    public struct u3<T> : IUnsignedValue<T>
        where T : unmanaged
    {
        public const ulong Width = 3;

        public T Storage;

        [MethodImpl(Inline)]
        public u3(T src)
        {
            Storage = src;
        }

        BitWidth ISizedValue.ContentWidth
            => Width;
    }
}