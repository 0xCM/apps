//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;

    partial class XedFields
    {
        [MethodImpl(Inline), Op]
        public static FieldSet usage(in InstFields src)
        {
            var dst = FieldSet.create();
            for(var j=0; j<src.Count; j++)
                dst = dst.Include(src[j].FieldKind);
            return dst;
        }
    }
}