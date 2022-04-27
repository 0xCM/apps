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
        [MethodImpl(Inline)]
        public static ColDef col(ushort pos, ColKind type, asci32 name, ReadOnlySpan<byte> widths)
            => new ColDef(pos, type, name, skip(widths, pos));

        [MethodImpl(Inline)]
        public static Index<ColDef> cols(params ColDef[] cols)
            => cols;
    }
}