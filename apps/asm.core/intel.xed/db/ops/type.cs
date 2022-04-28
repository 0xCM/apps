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
        public static DataType type(uint seq, asci32 name, asci32 primitive, DataSize size, asci32 refinement = default)
            => new DataType(seq, name, primitive, size, !refinement.IsNull, refinement);
    }
}