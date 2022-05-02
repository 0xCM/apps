//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedGrids
    {
        [MethodImpl(Inline), Op]
        public static GridCol col(in GridCell src)
            => new GridCol(src.Logic, src.ColIndex, src.Size, src.Type, src.Field);
    }
}