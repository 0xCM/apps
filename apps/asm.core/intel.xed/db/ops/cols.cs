//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class XedDb
    {
        [MethodImpl(Inline), Op]
        public static ColDef col(ushort pos, asci32 name, ReadOnlySpan<byte> widths)
            => new ColDef(pos, name, skip(widths, pos));

        [MethodImpl(Inline), Op]
        public static Index<ColDef> cols(params ColDef[] cols)
            => cols;
    }
}