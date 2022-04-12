//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static XedModels;

    partial class XedFields
    {
        [MethodImpl(Inline), Op]
        public static RepPrefix @rep(in InstFields src)
        {
            var dst = RepPrefix.None;
            for(var i=0; i<src.Count; i++)
            {
                ref readonly var field = ref src[i];
                if(field.FieldKind == FieldKind.REP)
                {
                    dst = field.ToFieldExpr().Value;
                    break;
                }
            }
            return dst;
        }
    }
}