//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Root;

    [ApiHost]
    public readonly partial struct vbits
    {
        const NumericKind Closure = UnsignedInts;

        public static BlockedBits<T> blocked<T>(uint bitcount)
            where T : unmanaged
                => new BlockedBits<T>(SpanBlocks.alloc<T>(n64, CellCalcs.bitcover<T>(bitcount)), bitcount);
   }
}