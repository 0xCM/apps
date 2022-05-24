//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class MemDb
    {
        [MethodImpl(Inline), Op]
        public static ColDef col(ushort pos, asci32 name, ReadOnlySpan<byte> widths)
            => new ColDef(pos, name, skip(widths, pos));

        [MethodImpl(Inline), Op]
        public static Index<ColDef> cols(params ColDef[] cols)
            => cols;
    }
}