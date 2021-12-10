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
    public struct u3 : IUnsignedInteger<u3>
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
}