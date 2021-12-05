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
    public struct u5 : IUnsignedValue<u5>
    {
        public const uint Width = 5;

        public static N5 N => default;

        public Cell8 Storage;

        [MethodImpl(Inline)]
        public u5(Cell8 src)
        {
            Storage = Cells.trim(src,N);
        }

        BitWidth ISizedValue.ContentWidth
            => Width;
    }

    /// <summary>
    /// Defines an unsigned 5-bit integer over parametric storage
    /// </summary>
    public struct u5<T> : IUnsignedValue<T>
        where T : unmanaged
    {
        public const uint Width = 5;

        public T Storage;

        [MethodImpl(Inline)]
        public u5(T src)
        {
            Storage = src;
        }

        BitWidth ISizedValue.ContentWidth
            => Width;
    }
}