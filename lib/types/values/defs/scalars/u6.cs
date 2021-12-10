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
    public struct u6 : IUnsignedInteger<u6>
    {
        public const uint Width = 6;

        public Cell8 Storage;

        [MethodImpl(Inline)]
        public u6(Cell8 src)
        {
            Storage = Cells.trim(src,n6);
        }

        BitWidth ISizedValue.ContentWidth
            => Width;
    }
}