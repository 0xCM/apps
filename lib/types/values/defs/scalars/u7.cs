//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Types
{
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// Defines an unsigned 7-bit integer over an 8-bit cell
    /// </summary>
    public struct u7 : IUnsignedValue<u7>
    {
        public const ulong Width = 7;

        public static N7 N => default;

        public Cell8 Storage;

        [MethodImpl(Inline)]
        public u7(Cell8 src)
        {
            Storage = Cells.trim(src,N);
        }

        BitWidth ISizedValue.ContentWidth
            => Width;
    }
}